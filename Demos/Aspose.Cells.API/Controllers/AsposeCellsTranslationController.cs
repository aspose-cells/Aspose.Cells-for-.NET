using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Cells.API.Api;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Models;
using Aspose.Cells.API.Models.Requests;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    public class AsposeCellsTranslationController : AsposeCellsBaseController
    {
        private const string App = "Translation";

        [MimeMultipart]
        [HttpPost]
        [ActionName("Translate")]
        public async Task<Response> Translate(string outputType, string translateFrom, string translateTo)
        {
            var sessionId = Guid.NewGuid().ToString();
            var action = $"Translate {outputType} from {translateFrom} to {translateTo}";
            try
            {
                var taskUpload = Task.Run(() => UploadWorkbooks(sessionId));
                taskUpload.Wait(Api.Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    NLogger.LogError($"Translation UploadWorkbooks=>{sessionId}=>{AppSettings.ProcessingTimedout}");
                    throw new TimeoutException(AppSettings.ProcessingTimedout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;
                SetDefaultOptions(docs);

                var sourceWorkbook = docs[0].Workbook;
                var convertWorkbook = new Workbook();

                if (convertWorkbook.Worksheets.Count == 1)
                    convertWorkbook.Worksheets.RemoveAt(0);

                foreach (var sourceWorksheet in sourceWorkbook.Worksheets)
                {
                    convertWorkbook.Worksheets.Add(sourceWorksheet.Name);
                    foreach (Cell cell in sourceWorksheet.Cells)
                    {
                        var convertCells = convertWorkbook.Worksheets[sourceWorksheet.Name].Cells;

                        if (!cell.IsFormula && cell.Type == CellValueType.IsString)
                            convertCells[cell.Row, cell.Column].PutValue(cell.Value);
                    }
                }

                var dir = AppSettings.OutputDirectory + sessionId;
                Directory.CreateDirectory(dir);
                var filePath = dir + "/" + Path.GetFileNameWithoutExtension(docs[0].FileName) + ".xlsx";
                convertWorkbook.Save(filePath);

                var task = Task.Run(() => Translate(sourceWorkbook, sessionId, filePath, outputType, translateFrom, translateTo));
                var isCompleted = task.Wait(Api.Configuration.MillisecondsTimeout);

                if (!isCompleted)
                    throw new TimeoutException(AppSettings.ProcessingTimedout);

                if (!task.IsFaulted && task.Exception == null) return await task;

                var msg = task.Exception?.Message ?? "500";

                return await Task.FromResult(new Response
                {
                    StatusCode = 500,
                    Status = msg,
                    FolderName = sessionId,
                    Text = action
                });
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                var message = $"{exception.Message} | outputType = {outputType} | translateFrom = {translateFrom} | translateTo = {translateTo}";
                NLogger.LogError(App, "Translate", message, sessionId);

                return await Task.FromResult(new Response
                {
                    StatusCode = 500,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = action
                });
            }
        }

        private Response Translate(Workbook sourceWorkbook, string sessionId, string filePath, string outputType, string translateFrom, string translateTo)
        {
            var conf = new Configuration
            {
                ClientId = "ClientId",
                ClientSecret = "ClientSecret"
            };

            var name = sessionId + "_" + Path.GetFileNameWithoutExtension(filePath) + ".xlsx";

            const string folder = "";

            var pair = $"{translateFrom}-{translateTo}";

            const string format = "xlsx";

            const string outFormat = "xlsx";

            const string storage = "";

            var saveFile = "translated_" + name;

            const string savePath = "";

            const bool masters = false;

            var elements = new List<int>();

            var workingDirectoryPath = AppSettings.OutputDirectory + sessionId + "/" + Path.GetFileName(filePath);

            var fileApi = new FileApi(conf);

            using (var stream = File.Open(workingDirectoryPath, FileMode.Open))
            {
                var uploadRequest = new UploadFileRequest {File = stream, Path = name, StorageName = storage};
                fileApi.UploadFile(uploadRequest);
            }

            var translationApi = new TranslationApi(conf);
            var request = translationApi.CreateDocumentRequest(name, folder, pair, format, outFormat, storage, saveFile, savePath, masters, elements);
            translationApi.RunTranslationTask(request);

            var downloadRequest = new DownloadFileRequest {StorageName = storage, Path = saveFile};
            var result = fileApi.DownloadFile(downloadRequest);

            Directory.CreateDirectory(AppSettings.OutputDirectory + sessionId);
            var outFileName = "translated_" + Path.GetFileName(filePath);
            var outputDirectoryPath = AppSettings.OutputDirectory + sessionId + "/" + outFileName;

            using (var file = new FileStream(outputDirectoryPath, FileMode.Create, FileAccess.Write))
            {
                result.CopyTo(file);
            }

            var convertWorkbook = new Workbook(outputDirectoryPath);
            var convertWorksheets = convertWorkbook.Worksheets;
            var sourceWorksheets = sourceWorkbook.Worksheets;
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

            var filename = Path.GetFileNameWithoutExtension(outFileName) + "." + outputType.ToLower();
            var doc = new DocumentInfo
            {
                FileName = filename,
                FolderName = sessionId,
                Workbook = sourceWorkbook
            };
            SaveDocument(doc, outputDirectoryPath, sessionId, GetSaveFormatType(filename));

            return new Response
            {
                StatusCode = 200,
                Status = "OK",
                FileName = filename,
                FolderName = sessionId
            };
        }
    }
}