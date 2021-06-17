using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Aspose.Cells.Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Merger.Controllers
{
    public class MergerApiController : CellsApiControllerBase
    {
        private const string AppName = "Merger";

        public MergerApiController(IStorageService storage, IConfiguration configuration, ILogger<MergerApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        public async Task<Response> Merge(string outputType, string mergerType)
        {
            var sessionId = Guid.NewGuid().ToString();
            var action = $"Merge to {outputType}";
            try
            {
                var taskUpload = Task.Run(() => UploadWorkbooks(sessionId, AppName));
                taskUpload.Wait(Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    Logger.LogError(
                        "{AppName} UploadWorkbooks=>{SessionId}=>{Timeout}",
                        AppName,
                        sessionId,
                        Configuration.ProcessingTimeout);
                    throw new TimeoutException(Configuration.ProcessingTimeout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length <= 1 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = "Merger";
                Opts.MethodName = "Merge";
                Opts.ZipFileName = "Merged file";
                Opts.FolderName = sessionId;
                Opts.ResultFileName = $"Merged file{Opts.OutputType}";

                await Storage.UpdateStatus(Common.Models.Response.Process(Opts.FolderName, Opts.ResultFileName));

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning(
                    "AppName = {AppName} | Filename = {Filename} | Start",
                    AppName,
                    string.Join(",", docs.Select(t => t.FileName)));

                var response = await ProcessCellsBlock(docs, mergerType);

                stopWatch.Stop();
                Logger.LogWarning(
                    "AppName = {AppName} | Filename = {Filename} | Cost Seconds = {Seconds}ms",
                    AppName,
                    string.Join(",", docs.Select(t => t.FileName)),
                    stopWatch.Elapsed.TotalSeconds);

                return response;
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

                Logger.LogError("AppName = {AppName} | Message = {Message} | OutputType = {OutputType} | MergerType = {MergerType}",
                    AppName, exception.Message, outputType, mergerType);

                return new Response
                {
                    StatusCode = statusCode,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = action
                };
            }
        }

        private async Task<Response> ProcessCellsBlock(DocumentInfo[] docs, string mergerType)
        {
            var streams = new Dictionary<string, Stream>();
            var (_, outFilePath) = BeforeAction();
            var catchException = false;
            var exception = new Exception();

            var outWorkbook = new Workbook();
            outWorkbook.Worksheets.RemoveAt(0);
            foreach (var doc in docs)
            {
                outWorkbook.Combine(doc.Workbook);
            }

            if (mergerType.Equals("s"))
            {
                outWorkbook = MergeToSheet(outWorkbook);
            }

            try
            {
                var filename = Opts.ZipFileName + Opts.OutputType;
                var documentInfo = new DocumentInfo {FileName = filename, FolderName = Opts.FolderName, Workbook = outWorkbook};
                var dictionary = SaveDocument(documentInfo, GetSaveFormatTypeByFilename(documentInfo.FileName));
                foreach (var (key, value) in dictionary)
                {
                    if (streams.ContainsKey(key)) continue;
                    streams.Add(key, value);
                }
            }
            catch (Exception e)
            {
                catchException = true;

                foreach (var (_, stream) in streams)
                {
                    stream.Close();
                }

                await UploadErrorFiles(docs, AppName);

                exception = e.InnerException ?? e;
                Logger.LogError("{Message}", exception.Message);
            }

            if (!catchException)
                return await AfterAction(outFilePath, streams);

            await Storage.UpdateStatus(Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName, exception.Message));
            throw exception;
        }

        private static Workbook MergeToSheet(Workbook workbook)
        {
            var destWorkbook = new Workbook();
            var destSheet = destWorkbook.Worksheets[0];

            var totalRowCount = 0;

            foreach (var sourceSheet in workbook.Worksheets)
            {
                var sourceRange = sourceSheet.Cells.MaxDisplayRange;

                if (sourceRange == null) continue;

                if (sourceRange.RowCount + totalRowCount > Configuration.MaxRow) break;

                var destRange = destSheet.Cells.CreateRange(sourceRange.FirstRow + totalRowCount,
                    sourceRange.FirstColumn,
                    sourceRange.RowCount, sourceRange.ColumnCount);

                destRange.Copy(sourceRange);

                totalRowCount = sourceRange.RowCount + totalRowCount;
            }

            return destWorkbook;
        }
    }
}