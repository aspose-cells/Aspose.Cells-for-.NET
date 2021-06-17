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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Aspose.Cells.Editor.Controllers
{
    public class EditorApiController : CellsApiControllerBase
    {
        private const string AppName = "Editor";

        public EditorApiController(IStorageService storage, IConfiguration configuration, ILogger<EditorApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        public async Task<Response> Editor()
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
                Opts.AppName = "Editor";
                Opts.MethodName = "Editor";
                Opts.ZipFileName = "Editor documents";
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
            var awsCache = new AwsCache(Storage);
            GridJsWorkbook.CacheImp = awsCache;
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
        public async Task<ActionResult> DownloadDocument(string file, string folder, string outputType)
        {
            var mFile = Uri.UnescapeDataString(file);
            var mFolder = Uri.UnescapeDataString(folder);

            var extension = outputType switch
            {
                "Original" => Path.GetExtension(file).ToLower(),
                "XLSX" => ".xlsx",
                "PDF" => ".pdf",
                "HTML" => ".html",
                _ => Path.GetExtension(file).ToLower()
            };

            var interruptMonitor = new InterruptMonitor();
            var thread = new Thread(InterruptMonitor);
            try
            {
                Opts.FileName = Convert.ToString(mFile);
                Opts.OutputType = extension;
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
                return Problem();
            }
            finally
            {
                thread.Interrupt();
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateCell(IFormCollection fm)
        {
            var gridJsWorkbook = new GridJsWorkbook();
            var awsCache = new AwsCache(Storage);
            GridJsWorkbook.CacheImp = awsCache;
            string json = null;

            var gridInterruptMonitor = new GridInterruptMonitor();
            gridJsWorkbook.SetInterruptMonitorForLoad(gridInterruptMonitor, Configuration.MillisecondsTimeout);
            var thread = new Thread(GridInterruptMonitor);
            try
            {
                thread.Start(new object[] {gridInterruptMonitor, Configuration.MillisecondsTimeout, fm["uid"]});
                var isCompleted = Task.Run(() => { json = gridJsWorkbook.UpdateCell(fm["p"], fm["uid"]); }).Wait(Configuration.MillisecondsTimeout);

                if (isCompleted && !string.IsNullOrEmpty(json))
                    return Content(json, "text/plain", Encoding.UTF8);

                Logger.LogError("{AppName} UpdateCell=>{Uid}=>{ProcessingTimeout}", AppName, fm["uid"], Configuration.ProcessingTimeout);
                throw new TimeoutException(Configuration.ProcessingTimeout);
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                Logger.LogError("AppName = {AppName} | Method = {Method} | Message = {Message} |" +
                                "FolderName = {FolderName} | FileName = {FileName} | UId = {UId}",
                    AppName, "UpdateCell", exception.Message, fm["folderName"], fm["fileName"], fm["uid"]);
                await UploadGridJsErrorJson(fm["p"], fm["uid"]);
                await UploadUidFile(fm["folderName"], fm["uid"], AppName);
                return Content(gridJsWorkbook.ErrorJson(exception.Message), "text/plain", Encoding.UTF8);
            }
            finally
            {
                thread.Interrupt();
            }
        }

        [HttpGet]
        public async Task<ActionResult> NewWorkbook()
        {
            const string outfileName = "book1.xlsx";
            var folderName = Guid.NewGuid().ToString();

            var interruptMonitor = new InterruptMonitor();
            var thread = new Thread(InterruptMonitor);
            try
            {
                thread.Start(new object[] {interruptMonitor, Configuration.MillisecondsTimeout, outfileName});
                var workbook = new Workbook();

                workbook.Worksheets[0].Cells["A50"].PutValue("");
                workbook.Worksheets[0].Cells.StandardHeight = 20;

                var memoryStream = new MemoryStream();
                workbook.Save(memoryStream, SaveFormat.Xlsx);

                var objectPath = $"{Configuration.SourceFolder}/{folderName}/{outfileName}";
                memoryStream.Seek(0, SeekOrigin.Begin);
                await Storage.Upload(objectPath, memoryStream, new AwsMetaInfo {OriginalFileName = outfileName, Title = outfileName});

                var response = new Response {StatusCode = 200, Status = "OK", FileName = outfileName, FolderName = folderName};
                return Json(response);
            }
            catch (Exception e)
            {
                Logger.LogError("AppName = {AppName} | Method = {Method} | Message = {Message} | FolderName = {FolderName}", AppName, "NewWorkbook", e.Message, folderName);
                return Problem(e.Message);
            }
            finally
            {
                thread.Interrupt();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Download()
        {
            var memoryStream = new MemoryStream();
            await Request.Body.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            var decompressString = Encoding.UTF8.GetString(Decompress(memoryStream));

            var obj = JObject.Parse(decompressString);

            var p = Convert.ToString(obj["p"]);
            var uid = Convert.ToString(obj["uid"]);
            var file = Convert.ToString(obj["file"]);
            var folderName = Convert.ToString(obj["folderName"]);
            var outputType = Convert.ToString(obj["outputType"]);

            var extension = outputType switch
            {
                "Original" => Path.GetExtension(file)?.ToLower(),
                "XLSX" => ".xlsx",
                "PDF" => ".pdf",
                "HTML" => ".html",
                _ => Path.GetExtension(file)?.ToLower()
            };

            var outFileName = Path.GetFileNameWithoutExtension(file) + extension;

            var gridJsWorkbook = new GridJsWorkbook();

            var gridInterruptMonitor = new GridInterruptMonitor();
            gridJsWorkbook.SetInterruptMonitorForSave(gridInterruptMonitor);
            var thread = new Thread(GridInterruptMonitor);
            try
            {
                thread.Start(new object[] {gridInterruptMonitor, Configuration.MillisecondsTimeout, outFileName});
                gridJsWorkbook.MergeExcelFileFromJson(uid, p);
                gridJsWorkbook.SaveToCacheWithFileName(uid, outFileName);

                if (outFileName.EndsWith(".html"))
                {
                    outFileName += ".zip";
                }

                var downloadUrl = GridJsWorkbook.GetImageUrl(uid, outFileName, "/");

                var response = new Response {StatusCode = 200, Status = "OK", FileName = outFileName, DownloadFileLink = downloadUrl};
                return Json(response);
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                Logger.LogError("AppName = {AppName} | Method = {Method} | Message = {Message} |" +
                                "FolderName = {FolderName} | FileName = {FileName} | UId = {UId}",
                    AppName, "Download", exception.Message, folderName, file, uid);
                await UploadGridJsErrorJson(p, uid);
                await UploadUidFile(folderName, uid, AppName);
                return Problem();
            }
            finally
            {
                memoryStream.Close();
                thread.Interrupt();
            }
        }

        private static byte[] Decompress(Stream stream)
        {
            using var compressedStream = new GZipStream(stream, CompressionMode.Decompress);
            using var outBuffer = new MemoryStream();
            compressedStream.CopyTo(outBuffer);
            return outBuffer.ToArray();
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