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

namespace Aspose.Cells.Parser.Controllers
{
    public class ParserApiController : CellsApiControllerBase
    {
        private const string AppName = "Parser";

        public ParserApiController(IStorageService storage, IConfiguration configuration, ILogger<ParserApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        public async Task<Response> Parse()
        {
            var sessionId = Guid.NewGuid().ToString();
            try
            {
                var taskUpload = UploadWorkbooks(sessionId, AppName);
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
                Opts.AppName = "Parser";
                Opts.MethodName = "Parse";
                Opts.ZipFileName = "Parsed files";
                Opts.FolderName = sessionId;
                Opts.OutputType = ".txt";

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

        private void ExtractImages(DocumentInfo doc, Dictionary<string, Stream> streams)
        {
            var wb = doc.Workbook;
            var sheetCount = wb.Worksheets.Count;

            var strSheetIndexFormat = sheetCount < 10 ? "0" : sheetCount < 100 ? "00" : sheetCount < 1000 ? "000" : "0000";

            for (var i = 0; i < sheetCount; i++)
            {
                wb.Worksheets.ActiveSheetIndex = i;

                var sheetName = wb.Worksheets[i].Name;
                var filename = $"{Path.GetFileNameWithoutExtension(doc.FileName)}__{(i + 1).ToString(strSheetIndexFormat)}_{sheetName}.txt";
                var memoryStream = new MemoryStream();
                wb.Save(memoryStream, new TxtSaveOptions(SaveFormat.Tsv) {Encoding = Encoding.UTF8});

                streams.Add(filename, memoryStream);
            }

            for (var i = 0; i < sheetCount; i++)
            {
                var ws = wb.Worksheets[i];
                var picsCount = ws.Pictures.Count;

                for (var j = 0; j < picsCount; j++)
                {
                    var pic = ws.Pictures[j];
                    var picData = pic.Data;
                    var fmt = pic.ImageType.ToString().ToLower();

                    var outFilePath = $"{Path.GetFileNameWithoutExtension(doc.FileName)}__{(i + 1).ToString(strSheetIndexFormat)}_{ws.Name}__Pic{j}.{fmt}";

                    var memoryStream = new MemoryStream();
                    memoryStream.Write(picData, 0, picData.Length);

                    streams.Add(outFilePath, memoryStream);
                }
            }
        }

        private async Task<Response> ProcessCellsBlock(DocumentInfo[] docs)
        {
            var streams = new Dictionary<string, Stream>();
            var (_, outFilePath) = BeforeAction();
            var catchException = false;
            var exception = new Exception();

            foreach (var doc in docs)
            {
                try
                {
                    var filename = $"{Path.GetFileNameWithoutExtension(outFilePath)}.txt";
                    var memoryStream = new MemoryStream();
                    doc.Workbook.Save(memoryStream, new TxtSaveOptions(SaveFormat.Tsv) {Encoding = Encoding.UTF8});
                    streams.Add(filename, memoryStream);
                    ExtractImages(doc, streams);
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