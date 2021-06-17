using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Aspose.Cells.Common.Services;
using Aspose.Cells.GridJs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Viewer.Controllers
{
    public class ViewerApiController : CellsApiControllerBase
    {
        private const string AppName = "Viewer";

        public ViewerApiController(IStorageService storage, IConfiguration configuration, ILogger<ViewerApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        public async Task<Response> UploadFile()
        {
            var sessionId = Guid.NewGuid().ToString();

            try
            {
                var taskUpload = UploadWorkbooks(sessionId, AppName);
                taskUpload.Wait(Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    Logger.LogError("{AppName} UploadWorkbooks=>{SessionId}=>{Timeout}",
                        AppName, sessionId, Configuration.ProcessingTimeout);
                    throw new TimeoutException(Configuration.ProcessingTimeout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = "Viewer";
                Opts.MethodName = "UploadFile";
                Opts.ZipFileName = "Viewer documents";
                Opts.FolderName = sessionId;

                return new Response
                {
                    StatusCode = 200,
                    Status = "OK",
                    FileName = Path.GetFileName(docs[0].FileName),
                    FolderName = sessionId
                };
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                var statusCode = 500;
                if (exception is CellsException {Code: ExceptionType.IncorrectPassword})
                {
                    statusCode = 403;
                }

                if (exception is CellsException {Code: ExceptionType.FileFormat})
                {
                    statusCode = 415;
                }

                Logger.LogError("AppName = {AppName} | Message = {Message} | SessionId = {SessionId}",
                    AppName, exception.Message, sessionId);

                return new Response
                {
                    StatusCode = statusCode,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = AppName
                };
            }
        }

        [HttpGet]
        public async Task<ActionResult> DetailJson(string file, string folder)
        {
            var mFile = Uri.UnescapeDataString(file);
            var mFolder = Uri.UnescapeDataString(folder);
            var gridJsWorkbook = new GridJsWorkbook();
            var awc = new AwsCache(Storage);
            GridJsWorkbook.CacheImp = awc;
            string json = null;

            var gridInterruptMonitor = new GridInterruptMonitor();
            gridJsWorkbook.SetInterruptMonitorForLoad(gridInterruptMonitor, Configuration.MillisecondsTimeout);
            var thread = new Thread(GridInterruptMonitor);
            try
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning("{AppName} DetailJson Start: {SessionId} {FileName}", AppName, mFolder, mFile);

                thread.Start(new object[] {gridInterruptMonitor, Configuration.MillisecondsTimeout, mFile});
                var isCompleted = Task.Run(() =>
                {
                    var objectPath = $"{Configuration.SourceFolder}/{mFolder}/{mFile}";
                    using var stream = Storage.Download(objectPath).Result;
                    gridJsWorkbook.ImportExcelFile(stream, GetGridLoadFormat(Path.GetExtension(mFile)));
                    json = gridJsWorkbook.ExportToJson();
                }).Wait(Configuration.MillisecondsTimeout);

                stopWatch.Stop();
                Logger.LogWarning("{AppName} DetailJson End: {SessionId} {FileName} costs {Ts}s",
                    AppName, mFolder, mFile, Math.Round(stopWatch.Elapsed.TotalSeconds, 1));

                if (isCompleted && !string.IsNullOrEmpty(json))
                    return Content(json, "text/plain", Encoding.UTF8);

                Logger.LogError("{AppName} DetailJson=>{SessionId}=>{ProcessingTimeout}",
                    AppName, mFolder, Configuration.ProcessingTimeout);
                throw new TimeoutException(Configuration.ProcessingTimeout);
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                Logger.LogError("AppName = {AppName} | Method = {Method} | Message = {Message} | SessionId = {SessionId} | File = {File}",
                    AppName, "DetailJson", exception.Message, mFolder, mFile);

                var message = exception.Message;
                if (e is GridCellException {Code: GridExceptionType.Interrupted})
                {
                    message = Configuration.ProcessingTimeout;
                }

                await UploadErrorFile(mFolder, mFile, AppName);

                return Content(gridJsWorkbook.ErrorJson(message), "text/plain", Encoding.UTF8);
            }
            finally
            {
                thread.Interrupt();
            }
        }

        [HttpGet]
        public ActionResult ImageUrl(string uid, string id)
        {
            return Content(GridJsWorkbook.GetImageUrl(uid, id, "."));
        }

        [HttpGet]
        public async Task<ActionResult> DownloadDocument(string file, string folder, bool isImage)
        {
            var mFile = Uri.UnescapeDataString(file);
            var mFolder = Uri.UnescapeDataString(folder);

            var interruptMonitor = new InterruptMonitor();
            var thread = new Thread(InterruptMonitor);
            try
            {
                Opts.FileName = Convert.ToString(mFile);
                Opts.OutputType = isImage ? ".png" : ".html";
                Opts.ResultFileName = Path.GetFileNameWithoutExtension(Opts.FileName) + Opts.OutputType;
                Opts.ZipFileName = Path.GetFileNameWithoutExtension(Opts.FileName);
                Opts.FolderName = Convert.ToString(mFolder);

                thread.Start(new object[] {interruptMonitor, Configuration.MillisecondsTimeout, Opts.FileName});
                var workbook = await GetWorkbook(interruptMonitor);

                var doc = new DocumentInfo {Workbook = workbook, FileName = Opts.ResultFileName, FolderName = Opts.FolderName};
                var dictionary = SaveDocument(doc, GetSaveFormatTypeByFilename(Opts.ResultFileName));
                if (dictionary.Count > 1)
                {
                    Opts.ResultFileName = $"{Path.GetFileNameWithoutExtension(Opts.ResultFileName)}.zip";
                }

                var outStream = await GetOutStream(dictionary);
                return File(outStream, "application/octet-stream", Opts.ResultFileName);
            }
            catch (Exception e)
            {
                await UploadErrorFile(mFolder, mFile, AppName);
                return Problem();
            }
            finally
            {
                thread.Interrupt();
            }
        }

        private async Task<Stream> GetOutStream(Dictionary<string, Stream> streams)
        {
            var outStream = new MemoryStream();
            if (streams.Count > 1)
            {
                Opts.ResultFileName = $"{Opts.ZipFileName}.zip";
                await using var zipStream = new MemoryStream();
                using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                {
                    foreach (var (filename, stream) in streams)
                    {
                        var entry = archive.CreateEntry(filename);
                        await using var entryStream = entry.Open();
                        stream.Seek(0, SeekOrigin.Begin);
                        await stream.CopyToAsync(entryStream);
                        stream.Close();
                    }
                }

                zipStream.Seek(0, SeekOrigin.Begin);
                await zipStream.CopyToAsync(outStream);
            }
            else
            {
                await using var sourceStream = streams.First().Value;
                sourceStream.Seek(0, SeekOrigin.Begin);
                await sourceStream.CopyToAsync(outStream);
            }

            outStream.Position = 0;
            return outStream;
        }
    }
}