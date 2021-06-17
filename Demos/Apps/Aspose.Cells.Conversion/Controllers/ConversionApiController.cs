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

namespace Aspose.Cells.Conversion.Controllers
{
    public class ConversionApiController : CellsApiControllerBase
    {
        private const string AppName = "Conversion";

        public ConversionApiController(IStorageService storage, IConfiguration configuration, ILogger<ConversionApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        public async Task<Response> Convert(string outputType)
        {
            var sessionId = Guid.NewGuid().ToString();

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
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;
                SetDefaultOptions(docs);
                Opts.AppName = "Conversion";
                Opts.MethodName = "Convert";
                Opts.ZipFileName = "Converted files";
                Opts.FolderName = sessionId;

                await Storage.UpdateStatus(Common.Models.Response.Process(Opts.FolderName, Opts.ResultFileName));

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning(
                    "AppName = {AppName} | Filename = {Filename} | Start",
                    AppName,
                    string.Join(",", docs.Select(t => t.FileName)));

                var taskProcessCellsBlock = ProcessCellsBlock(docs, outputType);
                taskProcessCellsBlock.Wait(Configuration.MillisecondsTimeout);
                if (!taskProcessCellsBlock.IsCompleted)
                {
                    Logger.LogError(
                        "{AppName} ProcessCellsBlock=>{SessionId}=>{Timeout}",
                        AppName,
                        sessionId,
                        Configuration.ProcessingTimeout);
                    throw new TimeoutException(Configuration.ProcessingTimeout);
                }

                stopWatch.Stop();
                Logger.LogWarning(
                    "AppName = {AppName} | Filename = {Filename} | Cost Seconds = {Seconds}ms",
                    AppName,
                    string.Join(",", docs.Select(t => t.FileName)),
                    stopWatch.Elapsed.TotalSeconds);

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

                Logger.LogError("AppName = {AppName} | Message = {Message} | OutputType = {OutputType}",
                    AppName, exception.Message, outputType);

                return new Response
                {
                    StatusCode = statusCode,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = AppName
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
                    doc.FileName = Path.GetFileNameWithoutExtension(doc.FileName) + Opts.OutputType;
                    var dictionary = SaveDocument(doc, GetSaveFormatTypeByOutputType(outputType));
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