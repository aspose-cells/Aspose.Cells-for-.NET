using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Aspose.Cells.Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Search.Controllers
{
    public class SearchApiController : CellsApiControllerBase
    {
        private const string AppName = "Search";

        public SearchApiController(IStorageService storage, IConfiguration configuration, ILogger<SearchApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        public async Task<Response> Search(string query)
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
                Opts.AppName = "Search";
                Opts.MethodName = "Search";
                Opts.ZipFileName = "SearchResults files";
                Opts.FolderName = sessionId;
                Opts.OutputType = ".xlsx";
                Opts.ResultFileName = "SearchResults.txt";
                Opts.CreateZip = false;

                await Storage.UpdateStatus(Common.Models.Response.Process(Opts.FolderName, Opts.ResultFileName));

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning("AppName = {AppName} | Filename = {Filename} | Start",
                    AppName, string.Join(",", docs.Select(t => t.FileName)));

                var taskProcessCellsBlock = ProcessCellsBlock(docs, query);
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

                Logger.LogError("AppName = {AppName} | Method = {Method} | Message = {Message} | Query = {Query}",
                    AppName, "Search", exception.Message, query);

                return new Response
                {
                    StatusCode = statusCode,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = AppName
                };
            }
        }

        private async Task<Response> ProcessCellsBlock(DocumentInfo[] docs, string query)
        {
            var streams = new Dictionary<string, Stream>();
            var (_, outFilePath) = BeforeAction();
            var catchException = false;
            var exception = new Exception();

            foreach (var doc in docs)
            {
                try
                {
                    var dictionary = await SearchQuery(doc, query);
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
                    break;
                }
            }

            if (!catchException)
                return await AfterAction(outFilePath, streams);

            if (exception is KeyNotFoundException)
            {
                var response = Common.Models.Response.NoSearchResults(Opts.FolderName, Opts.ResultFileName);
                await Storage.UpdateStatus(response);
                return response;
            }

            await Storage.UpdateStatus(Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName, exception.Message));
            throw exception;
        }

        public async Task<Dictionary<string, Stream>> SearchQuery(DocumentInfo doc, string query)
        {
            var streams = new Dictionary<string, Stream>();
            var interruptMonitor = new InterruptMonitor();
            var thread = new Thread(InterruptMonitor);
            try
            {
                Opts.FileName = doc.FileName;
                Opts.FolderName = doc.FolderName;

                // Load the input Excel file.
                thread.Start(new object[] {interruptMonitor, Configuration.MillisecondsTimeout, Opts.FileName});
                var wb = await GetWorkbook(interruptMonitor);

                // Specify the find options.
                // var opts = new FindOptions {LookAtType = LookAtType.Contains, LookInType = LookInType.Values};

                var found = new StringBuilder();

                found.AppendLine("Searched Text: " + query);
                found.AppendLine("===========================================");
                found.AppendLine();

                // Check if found nothing
                var mFoundNothing = true;

                Cell cell = null;

                foreach (var ws in wb.Worksheets)
                {
                    found.AppendLine("Sheet Name: " + ws.Name);
                    found.AppendLine();

                    do
                    {
                        cell = ws.Cells.Find(query, cell);

                        if (cell == null)
                            break;

                        mFoundNothing = false;
                        found.AppendLine("Cell Name: " + cell.Name);
                        found.AppendLine("Cell Value: " + cell.StringValue);
                        found.AppendLine();
                    } while (true);

                    found.AppendLine("===========================================");
                    found.AppendLine();
                }

                if (mFoundNothing)
                {
                    throw new KeyNotFoundException();
                }

                var memoryStream = new MemoryStream();
                var requestWriter = new StreamWriter(memoryStream);
                await requestWriter.WriteAsync(found.ToString());
                await requestWriter.FlushAsync();
                streams.Add(Opts.ResultFileName, memoryStream);
                return streams;
            }
            finally
            {
                thread.Interrupt();
            }
        }
    }
}