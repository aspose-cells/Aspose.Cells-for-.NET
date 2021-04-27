using System;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Models;
using Aspose.Cells.Drawing;
using Aspose.Cells.GridJs;
using Aspose.Cells.Rendering;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    [Compress]
    public class AsposeCellsViewerController : AsposeCellsBaseController
    {
        private const string App = "Viewer";

        [HttpGet]
        [ActionName("DetailJson")]
        public HttpResponseMessage DetailJson(string file, string folderName)
        {
            file = Uri.UnescapeDataString(file);
            folderName = Uri.UnescapeDataString(folderName);
            var filePath = File.Exists(AppSettings.WorkingDirectory + folderName + "/" + file) ? AppSettings.WorkingDirectory + folderName + "/" + file : AppSettings.OutputDirectory + folderName + "/" + file;
            var gridJsWorkbook = new GridJsWorkbook();
            string stringContent = null;

            var gridInterruptMonitor = new GridInterruptMonitor();
            gridJsWorkbook.SetInterruptMonitorForLoad(gridInterruptMonitor, Api.Configuration.MillisecondsTimeout);
            var thread = new Thread(GridInterruptMonitor);
            try
            {
                thread.Start(new object[] {gridInterruptMonitor, Api.Configuration.MillisecondsTimeout, filePath});
                Directory.CreateDirectory(AppSettings.OutputDirectory + folderName);
                var isCompleted = Task.Run(() =>
                {
                    gridJsWorkbook.ImportExcelFile(filePath);
                    stringContent = gridJsWorkbook.ExportToJson();
                }).Wait(Api.Configuration.MillisecondsTimeout);

                if (!isCompleted || string.IsNullOrEmpty(stringContent))
                {
                    NLogger.LogError($"Viewer DetailJson {folderName}=>{AppSettings.ProcessingTimedout}");
                    throw new TimeoutException(AppSettings.ProcessingTimedout);
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(stringContent)};
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
                return result;
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                var message = $"{exception.Message} | File = {file}";
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
                    Text = "Viewer Detail"
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
            finally
            {
                thread.Interrupt();
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
                    Text = "Viewer Image"
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpGet]
        [ActionName("DownloadDocument")]
        public HttpResponseMessage DownloadDocument(string file, string folderName, bool isImage)
        {
            file = Uri.UnescapeDataString(file);
            folderName = Uri.UnescapeDataString(folderName);
            var outFolderName = AppSettings.OutputDirectory + folderName + "/";

            try
            {
                string fullPath;
                if (File.Exists(AppSettings.WorkingDirectory + folderName + "/" + file))
                    fullPath = AppSettings.WorkingDirectory + folderName + "/" + file;
                else
                    fullPath = AppSettings.OutputDirectory + folderName + "/" + file;

                var options = new LoadOptions {CheckExcelRestriction = false};
                var workbook = new Workbook(fullPath, options);

                var zipOutFolder = outFolderName + Path.GetFileNameWithoutExtension(file);
                if (!Directory.Exists(zipOutFolder))
                {
                    Directory.CreateDirectory(zipOutFolder);
                }

                var worksheetsCount = workbook.Worksheets.Count;
                string outfileName;
                if (isImage)
                {
                    outfileName = Path.GetFileNameWithoutExtension(file) + ".png";
                    var imgOptions = new ImageOrPrintOptions {ImageType = ImageType.Png, OnePagePerSheet = true};

                    foreach (var sheet in workbook.Worksheets)
                    {
                        var sr = new SheetRender(sheet, imgOptions);
                        var srPageCount = sr.PageCount;
                        for (var i = 0; i < sr.PageCount; i++)
                        {
                            if (worksheetsCount > 1 || srPageCount > 1)
                            {
                                outfileName = zipOutFolder + "/" + sheet.Name + "_" + (i + 1) + ".png";
                            }
                            else
                            {
                                outfileName = zipOutFolder + "/" + Path.GetFileNameWithoutExtension(file) + ".png";
                            }

                            sr.ToImage(i, outfileName);
                        }
                    }
                }
                else
                {
                    if (worksheetsCount > 1)
                    {
                        outfileName = zipOutFolder + "/" + Path.GetFileNameWithoutExtension(file) + ".html";
                    }
                    else
                    {
                        outfileName = outFolderName + "/" + Path.GetFileNameWithoutExtension(file) + ".html";
                    }

                    var htmlSaveOptions = new HtmlSaveOptions {ExportImagesAsBase64 = true, Encoding = UTF8WithoutBom};
                    workbook.Save(outfileName, htmlSaveOptions);
                }

                if (isImage || worksheetsCount > 1)
                {
                    outfileName = outFolderName + Path.GetFileNameWithoutExtension(file) + ".zip";
                    if (File.Exists(outfileName))
                    {
                        File.Delete(outfileName);
                    }

                    ZipFile.CreateFromDirectory(zipOutFolder, outfileName);
                    Directory.Delete(zipOutFolder, true);
                }

                using (var fileStream = new FileStream(outfileName, FileMode.Open, FileAccess.Read))
                {
                    using (var ms = new MemoryStream())
                    {
                        fileStream.CopyTo(ms);
                        var result = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new ByteArrayContent(ms.ToArray())
                        };
                        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            FileName = Path.GetFileName(outfileName)
                        };
                        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                var message = $"{e.Message} | File = {file}";
                NLogger.LogError(App, "DownloadDocument", message, folderName);

                var response = new Response
                {
                    StatusCode = 500,
                    Status = e.Message,
                    FileName = file,
                    FolderName = folderName,
                    Text = "Viewer Download"
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }
    }
}