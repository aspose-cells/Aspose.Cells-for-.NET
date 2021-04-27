using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Models;
using Aspose.Cells.GridJs;
using Tools.Foundation.Helpers;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    public class AsposeCellsComparisonController : AsposeCellsBaseController
    {
        private const string App = "Comparison";

        [MimeMultipart]
        [HttpPost]
        [ActionName("Compare")]
        public async Task<Responses> Compare()
        {
            var sessionId = Guid.NewGuid().ToString();

            try
            {
                var taskUpload = Task.Run(() => UploadWorkbooks(sessionId));
                taskUpload.Wait(Api.Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    NLogger.LogError($"Comparison UploadWorkbooks=>{sessionId}=>{AppSettings.ProcessingTimedout}");
                    throw new TimeoutException(AppSettings.ProcessingTimedout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return (Responses) PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return (Responses) MaximumFileLimitsResponse;
                SetDefaultOptions(docs);
                Opts.CreateZip = false;

                Directory.CreateDirectory(AppSettings.OutputDirectory + sessionId);
                foreach (var doc in docs)
                {
                    var outFileName = Path.GetFileName(doc.FileName);
                    var outPath = AppSettings.OutputDirectory + sessionId + "/" + outFileName;
                    SaveDocument(doc, outPath, sessionId, GetSaveFormatType(doc.FileName));
                }

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
                NLogger.LogError(App, "Compare", exception.Message, sessionId);

                return new Responses
                {
                    StatusCode = 500,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = "Compare"
                };
            }
        }

        [HttpGet]
        [ActionName("DetailJson")]
        public HttpResponseMessage DetailJson(string file1, string file2, string folderName)
        {
            file1 = Uri.UnescapeDataString(file1);
            file2 = Uri.UnescapeDataString(file2);
            folderName = Uri.UnescapeDataString(folderName);

            var gridJsWorkbook1 = new GridJsWorkbook();
            var gridJsWorkbook2 = new GridJsWorkbook();

            var gridInterruptMonitor1 = new GridInterruptMonitor();
            gridJsWorkbook1.SetInterruptMonitorForLoad(gridInterruptMonitor1, Api.Configuration.MillisecondsTimeout);
            var thread1 = new Thread(GridInterruptMonitor);

            var gridInterruptMonitor2 = new GridInterruptMonitor();
            gridJsWorkbook2.SetInterruptMonitorForLoad(gridInterruptMonitor2, Api.Configuration.MillisecondsTimeout);
            var thread2 = new Thread(GridInterruptMonitor);
            try
            {
                thread1.Start(new object[] {gridInterruptMonitor1, Api.Configuration.MillisecondsTimeout, file1});
                thread2.Start(new object[] {gridInterruptMonitor2, Api.Configuration.MillisecondsTimeout, file2});
                var filename1 = File.Exists(AppSettings.WorkingDirectory + folderName + "/" + file1) ? AppSettings.WorkingDirectory + folderName + "/" + file1 : AppSettings.OutputDirectory + folderName + "/" + file1;
                var filename2 = File.Exists(AppSettings.WorkingDirectory + folderName + "/" + file2) ? AppSettings.WorkingDirectory + folderName + "/" + file2 : AppSettings.OutputDirectory + folderName + "/" + file2;

                var workbook1 = new Workbook(filename1);
                var workbook2 = new Workbook(filename2);

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

                workbook1.Save(filename1);
                workbook2.Save(filename2);

                if (!Directory.Exists(AppSettings.OutputDirectory + folderName))
                    Directory.CreateDirectory(AppSettings.OutputDirectory + folderName);

                var compareJson = new CompareJson();

                var isCompleted = Task.Run(() =>
                {
                    gridJsWorkbook1.ImportExcelFile(filename1);
                    compareJson.File1Json = gridJsWorkbook1.ExportToJson();

                    gridJsWorkbook2.ImportExcelFile(filename2);
                    compareJson.File2Json = gridJsWorkbook2.ExportToJson();
                }).Wait(Api.Configuration.MillisecondsTimeout);

                if (!isCompleted)
                {
                    NLogger.LogError($"Compare DetailJson {folderName}=>{AppSettings.ProcessingTimedout}");
                    throw new TimeoutException(AppSettings.ProcessingTimedout);
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(compareJson.ToJson())};
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
                return result;
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                var message = $"{exception.Message} | File1 = {file1} | File2 = {file2}";
                NLogger.LogError(App, "DetailJson", message, folderName);

                var status = exception.Message;
                if (e is GridCellException gridCellException && gridCellException.Code == GridExceptionType.Interrupted)
                {
                    status = AppSettings.ProcessingTimedout;
                }

                var response = new Response
                {
                    StatusCode = 500,
                    Status = status,
                    FolderName = folderName,
                    Text = "Compare Detail"
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
            finally
            {
                thread1.Interrupt();
                thread2.Interrupt();
            }
        }

        [HttpGet]
        [ActionName("Image")]
        public HttpResponseMessage Image(string id, string uid)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    var img = GridJsWorkbook.GetImageFromFile(uid, id);
                    img.Save(ms, ImageFormat.Png);

                    var result = new HttpResponseMessage(HttpStatusCode.OK) {Content = new ByteArrayContent(ms.ToArray())};
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                    return result;
                }
            }
            catch (Exception e)
            {
                var message = $"{e.Message} | PicId = {id} | UId = {uid}";
                NLogger.LogError(App, "Image", message, "null");

                var response = new Response
                {
                    StatusCode = 500,
                    Status = e.Message,
                    Text = "Compare Image"
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }
    }

    public class Responses : Response
    {
        public string FileName2;
    }

    public class CompareJson
    {
        public string File1Json;
        public string File2Json;
    }
}