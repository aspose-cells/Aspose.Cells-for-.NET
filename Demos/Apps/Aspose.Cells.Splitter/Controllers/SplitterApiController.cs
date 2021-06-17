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

namespace Aspose.Cells.Splitter.Controllers
{
    public class SplitterApiController : CellsApiControllerBase
    {
        private const string AppName = "Splitter";

        public SplitterApiController(IStorageService storage, IConfiguration configuration, ILogger<SplitterApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        public async Task<Response> Split(string outputType)
        {
            var sessionId = Guid.NewGuid().ToString();
            var action = $"Split to {outputType}";
            try
            {
                var taskUpload = Task.Run(() => UploadWorkbooks(sessionId, AppName));
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
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = AppName;
                Opts.MethodName = "Split";
                Opts.ZipFileName = "Splitted files";
                Opts.FolderName = sessionId;

                await Storage.UpdateStatus(Common.Models.Response.Process(Opts.FolderName, Opts.ResultFileName));

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning(
                    "Action = {Action} | Filename = {Filename} | Start",
                    action,
                    string.Join(",", docs.Select(t => t.FileName)));

                var response = await ProcessCellsBlock(docs, outputType);

                stopWatch.Stop();
                Logger.LogWarning(
                    "Action = {Action} | Filename = {Filename} | Cost Seconds = {Seconds}ms",
                    action,
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

                Logger.LogError("Action = {Action} | Message = {Message} | OutputType = {OutputType}",
                    action, exception.Message, outputType);

                return new Response
                {
                    StatusCode = statusCode,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = action
                };
            }
        }

        private async Task<Response> ProcessCellsBlock(DocumentInfo[] docs, string outputType)
        {
            var streams = new Dictionary<string, Stream>();
            var (_, outFilePath) = BeforeAction();
            var catchException = false;
            var exception = new Exception();

            foreach (var doc in docs)
            {
                try
                {
                    var workbook = doc.Workbook;
                    var worksheets = workbook.Worksheets;

                    foreach (var worksheet in worksheets)
                    {
                        var newWorkbook = new Workbook();
                        newWorkbook.Worksheets[0].Copy(worksheet);
                        var documentInfo = new DocumentInfo {Workbook = newWorkbook};

                        var extension = "." + outputType.Trim().ToLower();
                        if (outputType.Equals("-")) extension = Path.GetExtension(doc.FileName);

                        var filename = Path.GetFileNameWithoutExtension(doc.FileName) + "_" + worksheet.Name + extension;
                        documentInfo.FileName = filename;

                        var dictionary = SaveDocument(documentInfo, GetSaveFormatTypeByOutputType(extension?.Substring(1)));
                        foreach (var (key, value) in dictionary)
                        {
                            if (streams.ContainsKey(key)) continue;
                            streams.Add(key, value);
                        }
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
                    break;
                }
            }

            if (!catchException)
                return await AfterAction(outFilePath, streams);

            await Storage.UpdateStatus(Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName, exception.Message));
            throw exception;
        }
    }
}