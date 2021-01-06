using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Models;
using Aspose.Cells.GridJs;
using Newtonsoft.Json.Linq;
using Tools.Foundation.Helpers;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    [Compress]
    public class AsposeCellsEditorController : AsposeCellsBaseController
    {
        [MimeMultipart]
        [HttpPost]
        [ActionName("Editor")]
        public async Task<Response> Editor()
        {
            var sessionId = Guid.NewGuid().ToString();
            const string action = "Edit Excel";

            try
            {
                var docs = await UploadWorkBooks(sessionId);
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;
                SetDefaultOptions(docs);
                Opts.AppName = ConversionApp;
                Opts.MethodName = "Editor";
                Opts.ZipFileName = docs.Length > 1 ? "Editor documents" : Path.GetFileNameWithoutExtension(docs[0].FileName);

                return await Process((inFilePath, outPath, zipOutFolder) =>
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    NLogger.LogInfo($"Edit Excel=>{string.Join(",", docs.Select(t => t.FileName))}=>Start", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);

                    var tasks = docs.Select(doc => Task.Factory.StartNew(() => { SaveDocument(doc, outPath, zipOutFolder, GetSaveFormatType(doc.FileName)); })).ToArray();
                    Task.WaitAll(tasks);

                    stopWatch.Stop();
                    NLogger.LogInfo($"Edit Excel=>{string.Join(",", docs.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);
                });
            }
            catch (AppException ex)
            {
                NLogger.LogError(ex, $"{sessionId}-{action}");
                return AppErrorResponse(ex.Message, sessionId, action);
            }
            catch (Exception ex)
            {
                NLogger.LogError(ex, $"{sessionId}-{action}");
                return InternalServerErrorResponse(sessionId, action);
            }
        }

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

        [HttpGet]
        [ActionName("DownloadDocument")]
        public HttpResponseMessage DownloadDocument(string file, string folderName, string outputType)
        {
            file = Uri.UnescapeDataString(file);
            folderName = Uri.UnescapeDataString(folderName);
            outputType = Uri.UnescapeDataString(outputType);
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

            string ext;
            switch (outputType)
            {
                case "Original":
                    ext = Path.GetExtension(file).ToLower();
                    break;
                case "XLSX":
                    ext = ".xlsx";
                    break;
                case "PDF":
                    ext = ".pdf";
                    break;
                case "HTML":
                    ext = ".html";
                    break;
                default:
                    ext = Path.GetExtension(file).ToLower();
                    break;
            }

            var outfileName = outFolderName + "/" + Path.GetFileNameWithoutExtension(file) + ext;

            var createZip = false;

            if (ext.Equals(".html"))
            {
                var worksheetsCount = workbook.Worksheets.Count;
                createZip = worksheetsCount > 1;

                if (createZip) outfileName = zipOutFolder + "/" + Path.GetFileNameWithoutExtension(file) + ".html";
                var htmlSaveOptions = new HtmlSaveOptions {Encoding = Encoding.UTF8, ExportImagesAsBase64 = true};
                workbook.Save(outfileName, htmlSaveOptions);
            }
            else
            {
                workbook.Save(outfileName);
            }

            if (createZip)
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

        [HttpPost]
        public HttpResponseMessage UpdateCell(JObject obj)
        {
            try
            {
                var p = Convert.ToString(obj["p"]);
                var uid = Convert.ToString(obj["uid"]);

                var gwb = new GridJsWorkbook();
                var ret = gwb.UpdateCell(p, uid);

                return new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(ret)};
            }
            catch (Exception e)
            {
                NLogger.LogError(e);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public HttpResponseMessage NewWorkbook()
        {
            var folderName = Guid.NewGuid().ToString();
            const string outfileName = "book1.xlsx";
            var outputDirectory = AppSettings.OutputDirectory + folderName;
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            var outPath = outputDirectory + "/" + outfileName;
            var workbook = new Workbook();
            workbook.Save(outPath);

            var response = new Response {FileName = outfileName, FolderName = folderName};
            return new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(response.ToJson())};
        }

        [HttpPost]
        public HttpResponseMessage Download(JObject obj)
        {
            try
            {
                var p = Convert.ToString(obj["p"]);
                var uid = Convert.ToString(obj["uid"]);
                var file = Convert.ToString(obj["file"]);

                var wb = new GridJsWorkbook();

                wb.MergeExcelFileFromJson(uid, p);

                var folderName = Guid.NewGuid().ToString();
                var outPath = AppSettings.OutputDirectory + folderName;
                Directory.CreateDirectory(outPath);

                var fullPath = outPath + "/" + file;
                wb.SaveToExcelFile(fullPath);

                var response = new Response {FileName = file, FolderName = folderName};
                return new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(response.ToJson())};
            }
            catch (Exception e)
            {
                NLogger.LogError(e);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}