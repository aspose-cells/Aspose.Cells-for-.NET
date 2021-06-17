using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

namespace Aspose.Cells.Comparison.Controllers
{
    public class ComparisonApiController : CellsApiControllerBase
    {
        private const string AppName = "Comparison";

        public ComparisonApiController(IStorageService storage, IConfiguration configuration, ILogger<ComparisonApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        public async Task<Responses> Compare()
        {
            var sessionId = Guid.NewGuid().ToString();

            try
            {
                var taskUpload = UploadWorkbooks(sessionId, AppName);
                taskUpload.Wait(Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    Logger.LogError(
                        "{AppName} UploadWorkBooks=>{SessionId}=>{Timeout}",
                        AppName,
                        sessionId,
                        Configuration.ProcessingTimeout);
                    throw new TimeoutException(Configuration.ProcessingTimeout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return (Responses) PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return (Responses) MaximumFileLimitsResponse;
                SetDefaultOptions(docs);
                Opts.AppName = "Comparison";
                Opts.MethodName = "Compare";
                Opts.ZipFileName = "Compared files";
                Opts.FolderName = sessionId;
                Opts.CreateZip = false;

                return new Responses
                {
                    StatusCode = 200,
                    Status = "OK",
                    FileName = Path.GetFileName(docs[0].FileName),
                    FileName2 = Path.GetFileName(docs[1].FileName),
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

                return new Responses
                {
                    StatusCode = statusCode,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = AppName
                };
            }
        }

        [HttpGet]
        public async Task<ActionResult> DetailJson(string file1, string file2, string folder)
        {
            var mFile1 = Uri.UnescapeDataString(file1);
            var mFile2 = Uri.UnescapeDataString(file2);

            var mFolder = Uri.UnescapeDataString(folder);

            var awc = new AwsCache(Storage);
            GridJsWorkbook.CacheImp = awc;

            var gridJsWorkbook1 = new GridJsWorkbook();
            var gridJsWorkbook2 = new GridJsWorkbook();

            var gridInterruptMonitor1 = new GridInterruptMonitor();
            var gridInterruptMonitor2 = new GridInterruptMonitor();

            gridJsWorkbook1.SetInterruptMonitorForLoad(gridInterruptMonitor1, Configuration.MillisecondsTimeout);
            gridJsWorkbook2.SetInterruptMonitorForLoad(gridInterruptMonitor2, Configuration.MillisecondsTimeout);

            var thread1 = new Thread(GridInterruptMonitor);
            var thread2 = new Thread(GridInterruptMonitor);

            var interruptMonitor1 = new InterruptMonitor();
            var interruptMonitor2 = new InterruptMonitor();
            var cellsThread1 = new Thread(InterruptMonitor);
            var cellsThread2 = new Thread(InterruptMonitor);

            var compareJson = new CompareJson();
            try
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning("AppName = {AppName} | Method = {Method} | FolderName = {FolderName} | Filename1 = {Filename1} | Filename2 = {Filename2} | Start",
                    AppName, "DetailJson", mFolder, mFile1, mFile2);

                thread1.Start(new object[] {gridInterruptMonitor1, Configuration.MillisecondsTimeout, mFile1});
                thread2.Start(new object[] {gridInterruptMonitor2, Configuration.MillisecondsTimeout, mFile2});

                var objectPath1 = $"{Configuration.SourceFolder}/{mFolder}/{mFile1}";
                var objectPath2 = $"{Configuration.SourceFolder}/{mFolder}/{mFile2}";

                cellsThread1.Start(new object[] {interruptMonitor1, Configuration.MillisecondsTimeout, mFile1});
                cellsThread2.Start(new object[] {interruptMonitor2, Configuration.MillisecondsTimeout, mFile2});

                var workbook1 = await GetWorkbook(objectPath1, interruptMonitor1);
                var workbook2 = await GetWorkbook(objectPath2, interruptMonitor2);

                var worksheets1 = workbook1.Worksheets;
                var worksheets2 = workbook2.Worksheets;

                var sheetCount = worksheets1.Count > worksheets2.Count ? worksheets2.Count : worksheets1.Count;

                for (var i = 0; i < sheetCount; i++)
                {
                    var cells1 = worksheets1[i].Cells;
                    var cells2 = worksheets2[i].Cells;

                    var maxRow = cells1.MaxRow > cells2.MaxRow ? cells1.MaxRow : cells2.MaxRow;
                    var maxColumn = cells1.MaxColumn > cells2.MaxColumn ? cells1.MaxColumn : cells2.MaxColumn;
                    for (var row = 0; row <= maxRow; row++)
                    {
                        for (var column = 0; column <= maxColumn; column++)
                        {
                            var cell1 = cells1[row, column];
                            var cell2 = cells2[row, column];

                            if (cell1.DisplayStringValue.Equals(cell2.DisplayStringValue)) continue;

                            var style2 = cell2.GetStyle();
                            style2.Pattern = BackgroundType.Solid;
                            style2.ForegroundColor = Color.FromArgb(255, 255, 0);
                            style2.BackgroundColor = Color.FromArgb(255, 255, 0);
                            cell2.SetStyle(style2);
                        }
                    }
                }

                var isCompleted = Task.Run(() =>
                {
                    using (var outMs1 = new MemoryStream())
                    {
                        workbook1.Save(outMs1, GetSaveFormatTypeByFilename(mFile1).SaveFormat);
                        gridJsWorkbook1.ImportExcelFile(outMs1, GetGridLoadFormat(Path.GetExtension(mFile1)));
                    }

                    using (var outMs2 = new MemoryStream())
                    {
                        workbook2.Save(outMs2, GetSaveFormatTypeByFilename(mFile2).SaveFormat);
                        gridJsWorkbook2.ImportExcelFile(outMs2, GetGridLoadFormat(Path.GetExtension(mFile2)));
                    }

                    compareJson.File1Json = gridJsWorkbook1.ExportToJson();
                    compareJson.File2Json = gridJsWorkbook2.ExportToJson();
                }).Wait(Configuration.MillisecondsTimeout);

                stopWatch.Stop();
                Logger.LogWarning("AppName = {AppName} | Method = {Method} | FolderName = {FolderName} | Filename1 = {Filename1} | Filename2 = {Filename2} | Cost Seconds = {Seconds}s",
                    AppName, "DetailJson", mFolder, mFile1, mFile2, stopWatch.Elapsed.TotalSeconds);

                if (!isCompleted)
                {
                    Logger.LogError("{AppName} DetailJson=>{SessionId}=>{ProcessingTimeout}",
                        AppName, mFolder, Configuration.ProcessingTimeout);
                    throw new TimeoutException(Configuration.ProcessingTimeout);
                }
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                Logger.LogError("AppName = {AppName} | Method = {Method} | Message = {Message} | SessionId = {SessionId} | File1 = {File1} | File2 = {File2}",
                    AppName, "DetailJson", exception.Message, mFolder, mFile1, mFile2);

                var message = exception.Message;
                if (e is GridCellException {Code: GridExceptionType.Interrupted})
                {
                    message = Configuration.ProcessingTimeout;
                }

                await UploadErrorFile(mFolder, mFile1, AppName);
                await UploadErrorFile(mFolder, mFile2, AppName);

                compareJson.File1Json = gridJsWorkbook1.ErrorJson(message);
                compareJson.File2Json = gridJsWorkbook2.ErrorJson(message);
            }
            finally
            {
                thread1.Interrupt();
                thread2.Interrupt();
                cellsThread1.Interrupt();
                cellsThread2.Interrupt();
            }

            return Json(compareJson);
        }

        [HttpGet]
        public ActionResult ImageUrl(string uid, string id)
        {
            return Content(GridJsWorkbook.GetImageUrl(uid, id, "."));
        }

        public class Responses : Response
        {
            public string FileName2;
        }

        private class CompareJson
        {
            public string File1Json;
            public string File2Json;
        }
    }
}