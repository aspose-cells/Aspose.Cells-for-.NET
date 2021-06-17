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

namespace Aspose.Cells.Assembly.Controllers
{
    public class AssemblyApiController : CellsApiControllerBase
    {
        private const string AppName = "Assembly";

        public AssemblyApiController(IStorageService storage, IConfiguration configuration, ILogger<AssemblyApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        public async Task<Response> Assemble(string datasourceName)
        {
            var sessionId = Guid.NewGuid().ToString();

            try
            {
                var taskUpload = UploadWorkbooks(sessionId, AppName);
                taskUpload.Wait(Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    Logger.LogError("{AppName} UploadWorkBooks=>{SessionId}=>{ProcessingTimeout}",
                        AppName, sessionId, Configuration.ProcessingTimeout);
                    throw new TimeoutException(Configuration.ProcessingTimeout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = "Assembly";
                Opts.MethodName = "Assemble";
                Opts.ZipFileName = "Assembled Result";
                Opts.FolderName = sessionId;
                Opts.OutputType = ".xlsx";
                Opts.ResultFileName = "Assembled Result.xlsx";
                Opts.CreateZip = false;

                await Storage.UpdateStatus(Common.Models.Response.Process(Opts.FolderName, Opts.ResultFileName));

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning("AppName = {AppName} | Filename = {Filename} | Start",
                    AppName, string.Join(",", docs.Select(t => t.FileName)));

                var taskProcessCellsBlock = ProcessCellsBlock(docs, datasourceName);
                taskProcessCellsBlock.Wait(Configuration.MillisecondsTimeout);
                if (!taskProcessCellsBlock.IsCompleted)
                {
                    Logger.LogError("{AppName} ProcessCellsBlock=>{SessionId}=>{ProcessingTimeout}",
                        AppName, sessionId, Configuration.ProcessingTimeout);
                    throw new TimeoutException(Configuration.ProcessingTimeout);
                }

                stopWatch.Stop();
                Logger.LogWarning("AppName = {AppName} | Filename = {Filename} | Cost Seconds = {Seconds}s",
                    AppName, string.Join(",", docs.Select(t => t.FileName)), stopWatch.Elapsed.TotalSeconds);

                if (!taskProcessCellsBlock.IsFaulted && taskProcessCellsBlock.Exception == null)
                    return taskProcessCellsBlock.Result;

                return Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName, taskProcessCellsBlock.Exception?.Message ?? "500");
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

                Logger.LogError("AppName = {AppName} | Method = {Method} | Message = {Message}",
                    AppName, "Assemble", exception.Message);

                return new Response
                {
                    StatusCode = statusCode,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = AppName
                };
            }
        }

        private async Task<Response> ProcessCellsBlock(DocumentInfo[] docs, string datasourceName)
        {
            var streams = new Dictionary<string, Stream>();
            var (_, outFilePath) = BeforeAction();
            var catchException = false;
            var exception = new Exception();

            try
            {
                var wbData = docs[0].Workbook;

                var wsData = wbData.Worksheets[0];

                var totalRows = wsData.Cells.LastCell.Row + 1;
                var totalColumns = wsData.Cells.LastCell.Column + 1;

                var dt = wsData.Cells.ExportDataTable(0, 0, totalRows, totalColumns, true);
                dt.TableName = datasourceName;

                var wbTemplate = docs[1].Workbook;

                var wbd = new WorkbookDesigner(wbTemplate);
                wbd.SetDataSource(dt);
                wbd.Process();

                var memoryStream = new MemoryStream();
                wbTemplate.Save(memoryStream, SaveFormat.Xlsx);

                streams.Add(Opts.ResultFileName, memoryStream);
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
            }

            if (!catchException)
                return await AfterAction(outFilePath, streams);

            await Storage.UpdateStatus(Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName, exception.Message));
            throw exception;
        }
    }
}