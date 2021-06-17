using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Aspose.Cells.Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Annotation.Controllers
{
    public class AnnotationApiController : CellsApiControllerBase
    {
        private const string AppName = "Annotation";

        public AnnotationApiController(IStorageService storage, IConfiguration configuration, ILogger<AnnotationApiController> logger) : base(storage, configuration, logger)
        {
        }

        ///<Summary>
        /// Remove method to remove annotation from file based on product name
        ///</Summary>
        [HttpPost]
        public async Task<Response> Remove()
        {
            var sessionId = Guid.NewGuid().ToString();

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
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = "Annotation";
                Opts.MethodName = "Remove";
                Opts.ZipFileName = "Removed Annotations";
                Opts.FolderName = sessionId;

                if (Opts.CreateZip)
                    Opts.ResultFileName = $"{Opts.ZipFileName}.zip";

                await Storage.UpdateStatus(Common.Models.Response.Process(Opts.FolderName, Opts.ResultFileName));

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning(
                    "AppName = {AppName} | Filename = {Filename} | Start",
                    AppName,
                    string.Join(",", docs.Select(t => t.FileName)));

                var response = await ProcessCellsBlock(docs);

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

                Logger.LogError("AppName = {AppName} | Message = {Message}", AppName, exception.Message);

                return new Response
                {
                    StatusCode = statusCode,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = AppName
                };
            }
        }

        private async Task<Response> ProcessCellsBlock(DocumentInfo[] docs)
        {
            var streams = new Dictionary<string, Stream>();
            var (_, outFilePath) = BeforeAction();
            var catchException = false;
            var exception = new Exception();
            var memoryStream = new MemoryStream();

            foreach (var doc in docs)
            {
                try
                {
                    var wb = doc.Workbook;

                    var sb = new StringBuilder();

                    foreach (var ws in wb.Worksheets)
                    {
                        foreach (var cm in ws.Comments)
                        {
                            var cellName = CellsHelper.CellIndexToName(cm.Row, cm.Column);

                            var str = $"Sheet Name: \"{ws.Name}\", Cell Name: {cellName}, Comment Note: \r\n\"{cm.Note}\"";

                            sb.AppendLine(str);
                            sb.AppendLine();
                        }
                    }

                    var requestWriter = new StreamWriter(memoryStream);
                    await requestWriter.WriteAsync(sb.ToString());
                    await requestWriter.FlushAsync();

                    foreach (var ws in wb.Worksheets)
                    {
                        ws.Comments.Clear();
                    }

                    var dictionary = SaveDocument(doc, GetSaveFormatTypeByFilename(doc.FileName));
                    foreach (var (key, value) in dictionary)
                    {
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

            if (memoryStream.Length > 0)
            {
                streams.Add("comments.txt", memoryStream);
            }

            if (!catchException)
                return await AfterAction(outFilePath, streams);

            await Storage.UpdateStatus(Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName, exception.Message));
            throw exception;
        }
    }
}