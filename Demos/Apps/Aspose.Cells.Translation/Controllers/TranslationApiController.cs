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
using Aspose.Cells.Translation.Api;
using Aspose.Cells.Translation.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Translation.Controllers
{
    public class TranslationApiController : CellsApiControllerBase
    {
        private const string AppName = "Translation";

        public TranslationApiController(IStorageService storage, IConfiguration configuration, ILogger<TranslationApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        public async Task<Response> Translate(string outputType, string translateFrom, string translateTo)
        {
            var sessionId = Guid.NewGuid().ToString();
            var action = $"Translate {outputType} from {translateFrom} to {translateTo}";
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
                Opts.AppName = AppName;
                Opts.MethodName = "Translate";
                Opts.ZipFileName = "Translate files";
                Opts.FolderName = sessionId;

                await Storage.UpdateStatus(Common.Models.Response.Process(Opts.FolderName, Opts.ResultFileName));

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning(
                    "AppName = {AppName} | Filename = {Filename} | Start",
                    AppName,
                    string.Join(",", docs.Select(t => t.FileName)));

                var convertWorkbook = new Workbook();

                if (convertWorkbook.Worksheets.Count == 1)
                    convertWorkbook.Worksheets.RemoveAt(0);

                foreach (var sourceWorksheet in docs[0].Workbook.Worksheets)
                {
                    convertWorkbook.Worksheets.Add(sourceWorksheet.Name);
                    foreach (Cell cell in sourceWorksheet.Cells)
                    {
                        var convertCells = convertWorkbook.Worksheets[sourceWorksheet.Name].Cells;

                        if (!cell.IsFormula && cell.Type == CellValueType.IsString)
                            convertCells[cell.Row, cell.Column].PutValue(cell.Value);
                    }
                }

                var convertStream = new MemoryStream();
                convertWorkbook.Save(convertStream, SaveFormat.Xlsx);

                var taskProcessCellsBlock = ProcessCellsBlock(docs, convertStream, outputType, translateFrom, translateTo);
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

                Logger.LogError(
                    "AppName = {AppName} | Message = {Message} | OutputType = {OutputType} | TranslateFrom = {TranslateFrom} | TranslateTo = {TranslateTo}",
                    AppName, exception.Message, outputType, translateFrom, translateTo);

                return await Task.FromResult(new Response
                {
                    StatusCode = statusCode,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = action
                });
            }
        }

        private async Task<Response> ProcessCellsBlock(DocumentInfo[] docs, Stream inputStream, string outputType, string translateFrom, string translateTo)
        {
            var streams = new Dictionary<string, Stream>();
            var (_, outFilePath) = BeforeAction();
            var catchException = false;
            var exception = new Exception();

            try
            {
                var doc = await Translate(docs[0], inputStream, outputType, translateFrom, translateTo);
                var dictionary = SaveDocument(doc, GetSaveFormatTypeByOutputType(outputType));
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
            }

            if (!catchException)
                return await AfterAction(outFilePath, streams);

            await Storage.UpdateStatus(Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName, exception.Message));
            throw exception;
        }

        private static async Task<DocumentInfo> Translate(DocumentInfo documentInfo, Stream inputStream, string outputType, string translateFrom, string translateTo)
        {
            var sessionId = documentInfo.FolderName;
            var inputFilename = documentInfo.FileName;

            var conf = new TranslationConfiguration
            {
                ClientId = Configuration.TranslationClientId,
                ClientSecret = Configuration.TranslationClientSecret
            };

            var name = sessionId + "_" + Path.GetFileNameWithoutExtension(inputFilename) + ".xlsx";

            const string folder = "";

            var pair = $"{translateFrom}-{translateTo}";

            const string format = "xlsx";

            const string outFormat = "xlsx";

            const string storage = "";

            var saveFile = "translated_" + name;

            const string savePath = "";

            const bool masters = false;

            var elements = new List<int>();

            var api = new FileApi(conf);

            inputStream.Seek(0, SeekOrigin.Begin);
            var uploadRequest = new UploadFileRequest {File = inputStream, Path = name, StorageName = storage};
            var filesUploadResult = api.UploadFile(uploadRequest);

            var translationApi = new TranslationApi(conf);
            var request = translationApi.CreateDocumentRequest(name, folder, pair, format, outFormat, storage, saveFile, savePath, masters, elements);
            var translationResponse = translationApi.RunTranslationTask(request);

            var downloadRequest = new DownloadFileRequest {StorageName = storage, Path = saveFile};
            var downloadFileStream = api.DownloadFile(downloadRequest);

            var sourceWorkbook = documentInfo.Workbook;
            var convertWorkbook = new Workbook(downloadFileStream);
            var sourceWorksheets = sourceWorkbook.Worksheets;
            var convertWorksheets = convertWorkbook.Worksheets;
            foreach (var convertWorksheet in convertWorksheets)
            {
                var sourceWorksheet = sourceWorksheets[convertWorksheet.Index];
                var convertCells = convertWorksheet.Cells;
                var sourceCells = sourceWorksheet.Cells;

                foreach (Cell convertCell in convertCells)
                {
                    if (!convertCell.IsFormula && convertCell.Type == CellValueType.IsString)
                        sourceCells[convertCell.Row, convertCell.Column].PutValue(convertCell.Value);
                }
            }

            var outputFilename = Path.GetFileNameWithoutExtension(inputFilename) + "." + outputType.ToLower();
            var doc = new DocumentInfo
            {
                FileName = outputFilename,
                FolderName = sessionId,
                Workbook = sourceWorkbook
            };
            return doc;
        }
    }
}