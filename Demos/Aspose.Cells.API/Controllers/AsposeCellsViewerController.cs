using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Helpers;
using Aspose.Cells.API.Models;
using Aspose.Cells.Drawing;
using Aspose.Cells.GridJs;
using Aspose.Cells.Rendering;
using Newtonsoft.Json.Linq;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    [Compress]
    public class AsposeCellsViewerController : AsposeCellsBaseController
    {
        ///<Summary>
        /// GetDocumentPage method to get document page
        ///</Summary>
        [HttpGet]
        [ActionName("GetDocumentPage")]
        public HttpResponseMessage GetDocumentPage(string product, string file, string folderName, string userEmail, int currentPage)
        {
            var outfileName = Path.GetFileNameWithoutExtension(file) + "_{0}";
            var outPath = AppSettings.OutputDirectory + folderName + "/" + outfileName;

            currentPage -= 1;

            var htmlPath = string.Format(outPath, currentPage) + ".html";
            Directory.CreateDirectory(AppSettings.OutputDirectory + folderName);

            return File.Exists(htmlPath) ? GetHtml(htmlPath) : null;
        }

        private void GetProductAppFamily(out string productName, out ProductFamilyNameKeysEnum productFamily)
        {
            productName = AsposeCells;
            productFamily = ProductFamilyNameKeysEnum.cells;

            productName += ViewerApp;
        }

        ///<Summary>
        /// DocumentPages method to get document pages
        ///</Summary>
        [HttpGet]
        [ActionName("DocumentPages")]
        public List<ViewerResult> DocumentPages(string product, string file, string folderName, string userEmail, int currentPage)
        {
            var logMsg = "ControllerName = " + "AsposeCellsViewerController" + ", " + "MethodName = " + "DocumentPages" + ", " + "Folder = " + folderName;
            List<ViewerResult> output;
            GetProductAppFamily(out var productName, out var productFamily);
            try
            {
                output = GetDocumentPages(productFamily.ToString(), file, folderName, currentPage);

                NLogger.LogInfo(logMsg, productName, productFamily, file);
            }
            catch (Exception ex)
            {
                NLogger.LogError(ex, logMsg, productName, productFamily, file);
                throw;
            }

            return output;
        }

        ///<Summary>
        /// DocumentPages method to get document pages
        ///</Summary>
        [HttpGet]
        [ActionName("DocumentPage")]
        public ViewerResult DocumentPage(string file, string folderName, int currentPage)
        {
            var output = GetDocumentPage(file, folderName, currentPage);

            return output;
        }

        [HttpGet]
        [ActionName("GetWorksheetsNames")]
        public List<ViewerResult> GetWorksheetsNames(string file, string folderName)
        {
            var filename = File.Exists(AppSettings.WorkingDirectory + folderName + "/" + file)
                ? AppSettings.WorkingDirectory + folderName + "/" + file
                : AppSettings.OutputDirectory + folderName + "/" + file;
            var doc = new Workbook(filename);

            return doc.Worksheets.Select(docWorksheet => new ViewerResult {WorksheetIndex = docWorksheet.Index, WorksheetName = docWorksheet.Name}).ToList();
        }

        private static List<ViewerResult> GetDocumentPages(string product, string file, string folderName, int currentPage)
        {
            var lstOutput = new List<ViewerResult>();
            const string outfileName = "page_{0}";
            var outPath = AppSettings.OutputDirectory + folderName + "/" + outfileName;

            currentPage -= 1;
            Directory.CreateDirectory(AppSettings.OutputDirectory + folderName);

            var htmlPath = string.Format(outPath, currentPage) + ".html";
            var worksheetPath = folderName + "/" + string.Format(outfileName, currentPage) + ".html";

            if (File.Exists(htmlPath) && currentPage > 0)
            {
                var viewerResult = new ViewerResult {WorksheetIndex = currentPage, WorksheetPath = worksheetPath};
                lstOutput.Add(viewerResult);
                return lstOutput;
            }

            var filename = File.Exists(AppSettings.WorkingDirectory + folderName + "/" + file)
                ? AppSettings.WorkingDirectory + folderName + "/" + file
                : AppSettings.OutputDirectory + folderName + "/" + file;

            using (FilePathLock.Use(filename))
            {
                if (!product.ToLower().Equals("cells")) return null;

                var doc = new Workbook(filename);
                doc.Worksheets.ActiveSheetIndex = currentPage;
                var so = new HtmlSaveOptions(SaveFormat.Html) {ExportImagesAsBase64 = true, Encoding = UTF8WithoutBom, ExportActiveWorksheetOnly = true};
                doc.Save(htmlPath, so);

                var viewerResult = new ViewerResult {WorksheetCount = doc.Worksheets.Count, WorksheetIndex = doc.Worksheets.ActiveSheetIndex, WorksheetName = doc.Worksheets[doc.Worksheets.ActiveSheetIndex].Name, WorksheetPath = worksheetPath};

                lstOutput.Add(viewerResult);

                return lstOutput;
            }
        }

        private static ViewerResult GetDocumentPage(string file, string folderName, int currentPage)
        {
            ViewerResult viewerResult;
            const string outfileName = "page_{0}";
            var outPath = AppSettings.OutputDirectory + folderName + "/" + outfileName;

            Directory.CreateDirectory(AppSettings.OutputDirectory + folderName);

            var htmlPath = string.Format(outPath, currentPage) + ".html";
            var worksheetPath = folderName + "/" + string.Format(outfileName, currentPage) + ".html";

            if (File.Exists(htmlPath))
            {
                viewerResult = new ViewerResult
                {
                    WorksheetIndex = currentPage,
                    WorksheetPath = worksheetPath
                };
                return viewerResult;
            }

            var filename = File.Exists(AppSettings.WorkingDirectory + folderName + "/" + file)
                ? AppSettings.WorkingDirectory + folderName + "/" + file
                : AppSettings.OutputDirectory + folderName + "/" + file;

            using (FilePathLock.Use(filename))
            {
                var workbook = new Workbook(filename);
                workbook.Worksheets.ActiveSheetIndex = currentPage;
                var so = new HtmlSaveOptions(SaveFormat.Html) {ExportImagesAsBase64 = true, Encoding = UTF8WithoutBom, ExportActiveWorksheetOnly = true};
                workbook.Save(htmlPath, so);

                viewerResult = new ViewerResult
                {
                    WorksheetCount = workbook.Worksheets.Count,
                    WorksheetIndex = workbook.Worksheets.ActiveSheetIndex,
                    WorksheetName = workbook.Worksheets[workbook.Worksheets.ActiveSheetIndex].Name,
                    WorksheetPath = worksheetPath
                };

                return viewerResult;
            }
        }

        ///<Summary>
        /// DownloadDocument method to download document
        ///</Summary>
        [HttpGet]
        [ActionName("DownloadDocument")]
        public HttpResponseMessage DownloadDocument(string file, string folderName, bool isImage)
        {
            file = Uri.UnescapeDataString(file);
            folderName = Uri.UnescapeDataString(folderName);
            string outfileName;
            var outFolderName = AppSettings.OutputDirectory + folderName + "/";

            string fullPath;
            if (File.Exists(AppSettings.WorkingDirectory + folderName + "/" + file))
                fullPath = AppSettings.WorkingDirectory + folderName + "/" + file;
            else
                fullPath = AppSettings.OutputDirectory + folderName + "/" + file;
            var workbook = new Workbook(fullPath);

            var zipOutFolder = outFolderName + Path.GetFileNameWithoutExtension(file);
            if (!Directory.Exists(zipOutFolder))
            {
                Directory.CreateDirectory(zipOutFolder);
            }

            var worksheetsCount = workbook.Worksheets.Count;
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

        ///<Summary>
        /// PageImage method to get page image
        ///</Summary>
        [HttpGet]
        [ActionName("PageImage")]
        public HttpResponseMessage PageImage(string imagePath)
        {
            return GetImageFromPath(imagePath);
        }

        ///<Summary>
        /// PageImage method to get page image
        ///</Summary>
        [HttpGet]
        [ActionName("PageHtml")]
        public HttpResponseMessage PageHtml(string htmlPath)
        {
            return GetHtml(htmlPath);
        }

        private static HttpResponseMessage GetImageFromPath(string imagePath)
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            var image = System.Drawing.Image.FromStream(fileStream);
            var memoryStream = new MemoryStream();

            image.Save(memoryStream, ImageFormat.Jpeg);
            result.Content = new ByteArrayContent(memoryStream.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            fileStream.Close();

            return result;
        }

        ///<Summary>
        /// GetHTML method to get HTML
        ///</Summary>
        private static HttpResponseMessage GetHtml(string fileName)
        {
            try
            {
                fileName = HttpUtility.UrlDecode(fileName);

                var filePath = File.Exists(AppSettings.WorkingDirectory + fileName)
                    ? AppSettings.WorkingDirectory + fileName
                    : AppSettings.OutputDirectory + fileName;

                if (!File.Exists(filePath)) return new HttpResponseMessage(HttpStatusCode.InternalServerError);

                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var ms = new MemoryStream())
                    {
                        fileStream.CopyTo(ms);

                        var result = new HttpResponseMessage(HttpStatusCode.OK) {Content = new ByteArrayContent(ms.ToArray())};
                        result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

                        return result;
                    }
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        /**
         * ================================================================
         * ========================== GridJs ==============================
         * ================================================================
         */
        [HttpGet]
        [ActionName("DetailJson")]
        public HttpResponseMessage DetailJson(string file, string folderName)
        {
            try
            {
                file = Uri.UnescapeDataString(file);
                folderName = Uri.UnescapeDataString(folderName);
                var filename = File.Exists(AppSettings.WorkingDirectory + folderName + "/" + file) ? AppSettings.WorkingDirectory + folderName + "/" + file : AppSettings.OutputDirectory + folderName + "/" + file;
                var imageCacheDir = AppSettings.OutputDirectory + folderName + "/ImageCache";
                var fileCacheDir = AppSettings.OutputDirectory + folderName + "/FileCache";

                Directory.CreateDirectory(AppSettings.OutputDirectory + folderName);
                Directory.CreateDirectory(imageCacheDir);
                Directory.CreateDirectory(fileCacheDir);

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                NLogger.LogInfo($"View=>{filename}=>Start", AsposeCells, ProductFamilyNameKeysEnum.cells, folderName);

                var wbj = new GridJsWorkbook();
                var task = Task.Run(() =>
                {
                    GridJs.Config.PictureCacheDirectory = imageCacheDir;
                    GridJs.Config.FileCacheDirectory = fileCacheDir;
                    wbj.ImportExcelFile(filename);
                });
                Task.WaitAll(task);

                stopWatch.Stop();
                NLogger.LogInfo($"View=>{filename}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}", AsposeCells, ProductFamilyNameKeysEnum.cells, folderName);

                var result = new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(wbj.ExportToJson())};
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

                return result;
            }
            catch (AppException ex)
            {
                NLogger.LogError(ex, $"{folderName}-View");
                return Request.CreateResponse(HttpStatusCode.InternalServerError, AppErrorResponse(ex.Message, folderName, "View"));
            }
            catch (Exception ex)
            {
                NLogger.LogError(ex, $"{folderName}-View");
                return Request.CreateResponse(HttpStatusCode.InternalServerError, InternalServerErrorResponse(folderName, "View"));
            }
        }

        // GET: /GridJs2/image/uid?id=
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
                NLogger.LogError(e);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // post: /GridJs2/Download1
        [HttpPost]
        [ActionName("Download1")]
        public Response Download1(JObject obj)
        {
            var json = Convert.ToString(obj["json"]);
            var folderName = Convert.ToString(obj["folderName"]);
            var file = Convert.ToString(obj["file"]);

            var wb = new GridJsWorkbook();
            wb.ImportExcelFileFromJson(json);

            var fileName = Path.GetFileNameWithoutExtension(file) + ".xlsb";

            var outfileName = AppSettings.OutputDirectory + folderName + "/" + fileName;
            wb.SaveToExcelFile(outfileName);

            return new Response
            {
                FileName = fileName,
                FolderName = folderName,
                Status = "OK",
                StatusCode = 200,
            };
        }
    }
}