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
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Models;
using Aspose.Cells.GridJs;
using Newtonsoft.Json.Linq;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    [Compress]
    public class AsposeCellsEditorController : AsposeCellsBaseController
    {
        private const string App = "Editor";

        [MimeMultipart]
        [HttpPost]
        [ActionName("Editor")]
        public async Task<Response> Editor()
        {
            var sessionId = Guid.NewGuid().ToString();

            try
            {
                var taskUpload = Task.Run(() => UploadWorkbooks(sessionId));
                taskUpload.Wait(Api.Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    NLogger.LogError($"Editor UploadWorkbooks=>{sessionId}=>{AppSettings.ProcessingTimedout}");
                    throw new TimeoutException(AppSettings.ProcessingTimedout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;
                SetDefaultOptions(docs);
                Opts.AppName = "Editor";
                Opts.MethodName = "Editor";
                Opts.ZipFileName = docs.Length > 1 ? "Editor documents" : Path.GetFileNameWithoutExtension(docs[0].FileName);

                return await Process((inFilePath, outPath, zipOutFolder) =>
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    NLogger.LogInfo($"{App}=>{string.Join(",", docs.Select(t => t.FileName))}=>Start");

                    var tasks = docs.Select(doc => Task.Factory.StartNew(() => { SaveDocument(doc, outPath, zipOutFolder, GetSaveFormatType(doc.FileName)); })).ToArray();
                    Task.WaitAll(tasks);

                    stopWatch.Stop();
                    NLogger.LogInfo($"{App}=>{string.Join(",", docs.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}");
                });
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                NLogger.LogError(App, "Editor", exception.Message, sessionId);

                return new Response
                {
                    StatusCode = 500,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = "Editor"
                };
            }
        }

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
                    NLogger.LogError($"Editor DetailJson {folderName}=>{AppSettings.ProcessingTimedout}");
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
                    Text = "Editor Detail"
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
                    Text = "Editor Image"
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
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
            catch (Exception e)
            {
                var message = $"{e.Message} | File = {file} | OutputType = {outputType}";
                NLogger.LogError(App, "DownloadDocument", message, folderName);

                var response = new Response
                {
                    StatusCode = 500,
                    Status = e.Message,
                    FileName = file,
                    FolderName = folderName,
                    Text = "Editor Download"
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpPost]
        public HttpResponseMessage UpdateCell(JObject obj)
        {
            var p = Convert.ToString(obj["p"]);
            var uid = Convert.ToString(obj["uid"]);
            string ret = null;

            try
            {
                var isCompleted = Task.Run(() =>
                {
                    var gwb = new GridJsWorkbook();
                    ret = gwb.UpdateCell(p, uid);
                }).Wait(Api.Configuration.MillisecondsTimeout);

                if (!isCompleted || string.IsNullOrEmpty(ret))
                {
                    NLogger.LogError($"Editor UpdateCell {uid}=>{AppSettings.ProcessingTimedout}");
                    throw new TimeoutException(AppSettings.ProcessingTimedout);
                }

                return new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(ret)};
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                var message = $"{exception.Message} | UId = {uid} | P = {p}";
                NLogger.LogError(App, "UpdateCell", message, "null");

                var response = new Response
                {
                    StatusCode = 500,
                    Status = exception.Message,
                    Text = "Editor Update"
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpGet]
        public HttpResponseMessage NewWorkbook()
        {
            var folderName = Guid.NewGuid().ToString();

            try
            {
                const string outfileName = "book1.xlsx";
                var outputDirectory = AppSettings.OutputDirectory + folderName;
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                var outPath = outputDirectory + "/" + outfileName;
                var workbook = new Workbook();
                workbook.Worksheets[0].Cells["A50"].PutValue("");
                workbook.Worksheets[0].Cells.StandardHeight = 20;
                workbook.Save(outPath);

                var response = new Response
                {
                    StatusCode = 200,
                    Status = "OK",
                    FileName = outfileName,
                    FolderName = folderName
                };
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                NLogger.LogError(App, "NewWorkbook", e.Message, folderName);

                var response = new Response
                {
                    StatusCode = 500,
                    Status = e.Message,
                    Text = "Editor New Workbook"
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpPost]
        public HttpResponseMessage Download()
        {
            var zippedData = Request.Content.ReadAsByteArrayAsync().Result;
            var decompressString = Encoding.UTF8.GetString(Decompress(zippedData));
            var obj = JObject.Parse(decompressString);
            var p = Convert.ToString(obj["p"]);
            var uid = Convert.ToString(obj["uid"]);
            var file = Convert.ToString(obj["file"]);
            var gridJsWorkbook = new GridJsWorkbook();
            var folderName = Guid.NewGuid().ToString();
            var outPath = AppSettings.OutputDirectory + folderName;
            var fullPath = outPath + "/" + file;

            var gridInterruptMonitor = new GridInterruptMonitor();
            gridJsWorkbook.SetInterruptMonitorForSave(gridInterruptMonitor);
            var thread = new Thread(GridInterruptMonitor);
            try
            {
                thread.Start(new object[] {gridInterruptMonitor, Api.Configuration.MillisecondsTimeout, file});
                gridJsWorkbook.MergeExcelFileFromJson(uid, p);
                Directory.CreateDirectory(outPath);
                gridJsWorkbook.SaveToExcelFile(fullPath);

                var response = new Response
                {
                    StatusCode = 200,
                    Status = "OK",
                    FileName = file,
                    FolderName = folderName
                };
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                var message = $"{e.Message} | File = {file} | UId = {uid} | P = {p}";
                NLogger.LogError(App, "Download", message, folderName);

                var status = exception.Message;
                if (e is GridCellException gridCellException && gridCellException.Code == GridExceptionType.Interrupted)
                {
                    NLogger.LogError($"Editor Download=>{folderName}=>{AppSettings.ProcessingTimedout}");
                    status = AppSettings.ProcessingTimedout;
                }

                var response = new Response
                {
                    StatusCode = 500,
                    Status = status,
                    Text = "Editor Download"
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
            finally
            {
                thread.Interrupt();
            }
        }

        private static byte[] Decompress(byte[] zippedData)
        {
            using (var ms = new MemoryStream(zippedData))
            {
                using (var compressedStream = new GZipStream(ms, CompressionMode.Decompress))
                {
                    using (var outBuffer = new MemoryStream())
                    {
                        compressedStream.CopyTo(outBuffer);
                        return outBuffer.ToArray();
                    }
                }
            }
        }
    }
}