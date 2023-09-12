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

namespace Aspose.Cells.Repair.Controllers
{
    public class RepairApiController : CellsApiControllerBase
    {
        private const string AppName = "Repair";

        public RepairApiController(IStorageService storage, IConfiguration configuration, ILogger<RepairApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        public async Task<Response> Repair(bool filter)
        {
            var sessionId = Guid.NewGuid().ToString();
            try
            {
         
                var taskUpload = UploadWorkbooks(sessionId, AppName);
                if (!taskUpload.Wait(Configuration.MillisecondsTimeout))
                {
                    throw new TimeoutException(Configuration.ProcessingTimeout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > Configuration.MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = "Repair";
                Opts.MethodName = "Repair";
                Opts.ZipFileName = "RepairResults files";
                Opts.FolderName = sessionId;

                await Storage.UpdateStatus(Common.Models.Response.Process(Opts.FolderName, Opts.ResultFileName));

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning("AppName = {AppName} | Filename = {Filename}  | Start",
                    AppName, string.Join(",", docs.Select(t => t.FileName)));

                var taskProcessCellsBlock = ProcessCellsBlock(docs);
                if (!taskProcessCellsBlock.Wait(Configuration.MillisecondsTimeout))
                {
                    throw new TimeoutException(Configuration.ProcessingTimeout);
                }

                stopWatch.Stop();
                Logger.LogWarning("AppName = {AppName} | Filename = {Filename} | Cost Seconds = {Seconds}s",
                    AppName, string.Join(",", docs.Select(t => t.FileName)), stopWatch.Elapsed.TotalSeconds);

                if (!taskProcessCellsBlock.IsFaulted && taskProcessCellsBlock.Exception == null)
                    return taskProcessCellsBlock.Result;

                return Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName,
                    taskProcessCellsBlock.Exception?.Message ?? "500");
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

                Logger.LogError("AppName = {AppName} | Message = {Message} | Password = {Password}",
                    AppName, exception.Message );

                return new Response
                {
                    StatusCode = statusCode,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = AppName
                };
            }
        }
        protected readonly Response MaximumFileLimitsResponse = new Response
        {
            Status = $"Number of files should be less {Configuration.MaximumUploadFiles}",
            StatusCode = 403
        };
        private async Task<Response> ProcessCellsBlock(DocumentInfo[] docs)
        {
            var streams = new Dictionary<string, Stream>();
            var (_, outFilePath) = BeforeAction();
            var catchException = false;
            var exception = new Exception();

            try
            {
                foreach (var doc in docs)
                {
                    var dictionary = SaveDocument(doc, GetSaveFormatTypeByOutputType(Path.GetExtension(doc.FileName)));
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
            }

            if (!catchException)
                return await AfterAction(outFilePath, streams);

            if (exception is KeyNotFoundException)
            {
                var response = Common.Models.Response.NoSearchResults(Opts.FolderName, Opts.ResultFileName);
                await Storage.UpdateStatus(response);
                return response;
            }

            await Storage.UpdateStatus(Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName,
                exception.Message));
            throw exception;
        }
    }
}