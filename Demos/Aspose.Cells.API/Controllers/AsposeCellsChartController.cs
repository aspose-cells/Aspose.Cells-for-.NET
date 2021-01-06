using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebPages;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Models;
using Newtonsoft.Json.Linq;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    public class AsposeCellsChartController : AsposeCellsBaseController
    {
        [HttpPost]
        [ActionName("Download")]
        public HttpResponseMessage Download(JObject obj)
        {
            var charts = obj["charts"].ToObject<List<PreviewChart>>();
            var outputType = Convert.ToString(obj["outputType"]);
            string guid;

            string outfileName;
            if (outputType.Equals("PDF"))
            {
                var index = 0;
                var workbook = new Workbook();

                foreach (var chart in charts)
                {
                    var imgPath = AppSettings.OutputDirectory + chart.ImgFolderName + "/" + chart.ImgFileName;
                    var upperLeftRow = workbook.Worksheets[0].Pictures.Count > 0 ? workbook.Worksheets[0].Pictures[index].LowerRightRow : index;
                    index = workbook.Worksheets[0].Pictures.Add(upperLeftRow, 0, imgPath);
                }

                guid = Guid.NewGuid().ToString();
                var zipOutFolder = AppSettings.OutputDirectory + guid;
                if (!Directory.Exists(zipOutFolder))
                {
                    Directory.CreateDirectory(zipOutFolder);
                }

                outfileName = $"{zipOutFolder}/charts.pdf";
                workbook.Save(outfileName);
            }
            else
            {
                guid = Guid.NewGuid().ToString();
                var outputDirectory = AppSettings.OutputDirectory + guid;
                var zipOutFolder = outputDirectory + "/zip/";
                Directory.CreateDirectory(zipOutFolder);

                foreach (var chart in charts)
                {
                    var imgPath = AppSettings.OutputDirectory + chart.ImgFolderName + "/" + chart.ImgFileName;
                    var outPath = $"{zipOutFolder}{Path.GetFileNameWithoutExtension(imgPath)}.{outputType.ToLower()}";

                    if (File.Exists(outPath)) continue;

                    switch (outputType)
                    {
                        case "JPG":
                        case "PNG":
                        case "EMF":
                        case "WMF":
                        case "BMP":
                        case "TIFF":
                            using (var bitmap = new Bitmap(imgPath))
                            {
                                bitmap.Save(outPath, _imageFormat(outputType));
                            }

                            break;
                        case "SVG":
                        case "XPS":
                            var workbook = new Workbook();
                            workbook.Worksheets[0].Pictures.Add(0, 0, imgPath);
                            workbook.Save(outPath);
                            break;
                    }
                }

                outfileName = outputDirectory + "/" + "charts.zip";
                if (File.Exists(outfileName))
                {
                    File.Delete(outfileName);
                }

                ZipFile.CreateFromDirectory(zipOutFolder, outfileName);
                Directory.Delete(zipOutFolder, true);
            }

            if (outfileName.IsEmpty()) return Request.CreateResponse(HttpStatusCode.InternalServerError);

            return Request.CreateResponse(HttpStatusCode.OK, new Response
            {
                FileName = Path.GetFileName(outfileName),
                FolderName = guid,
                Status = "OK",
                StatusCode = 200
            });
        }

        [MimeMultipart]
        [HttpPost]
        [ActionName("PreChart")]
        public async Task<HttpResponseMessage> PreChart(string outputType)
        {
            var sessionId = Guid.NewGuid().ToString();
            var action = $"Chart to {outputType.Trim().ToLower()}";

            try
            {
                var docs = await UploadWorkBooks(sessionId);
                if (docs == null)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, PasswordProtectedResponse.Status);
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, MaximumFileLimitsResponse.Status);

                var guid = Guid.NewGuid().ToString();
                var outFolder = AppSettings.OutputDirectory + guid;
                if (!Directory.Exists(outFolder))
                {
                    Directory.CreateDirectory(outFolder);
                }

                var charts = new List<PreviewChart>();
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                NLogger.LogInfo($"Chart to {outputType.Trim().ToLower()}=>{string.Join(",", docs.Select(t => t.FileName))}=>Start", AsposeCells, ProductFamilyNameKeysEnum.cells, outFolder);

                var tasks = docs.Select(doc => Task.Factory.StartNew(() => { charts.AddRange(PreCharts(doc, outFolder, guid)); })).ToArray();
                Task.WaitAll(tasks);

                stopWatch.Stop();
                NLogger.LogInfo($"Chart to {outputType.Trim().ToLower()}=>{string.Join(",", docs.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}", AsposeCells, ProductFamilyNameKeysEnum.cells, outFolder);

                return charts.Count <= 0
                    ? Request.CreateResponse(HttpStatusCode.InternalServerError, AppErrorResponse("There's no chart in the Excel file.", sessionId, action))
                    : Request.CreateResponse(HttpStatusCode.OK, new {charts, outputType});
            }
            catch (AppException ex)
            {
                NLogger.LogError(ex, $"{sessionId}-{action}");
                return Request.CreateResponse(HttpStatusCode.InternalServerError, AppErrorResponse(ex.Message, sessionId, action));
            }
            catch (Exception ex)
            {
                NLogger.LogError(ex, $"{sessionId}-{action}");
                return Request.CreateResponse(HttpStatusCode.InternalServerError, InternalServerErrorResponse(sessionId, action));
            }
        }

        private static IEnumerable<PreviewChart> PreCharts(DocumentInfo doc, string zipOutPath, string folderName)
        {
            var charts = new List<PreviewChart>();
            foreach (var sheet in doc.Workbook.Worksheets)
            {
                foreach (var chart in sheet.Charts)
                {
                    var imgFileName = $"{sheet.Name} {chart.Name}.png";
                    var imgPath = $"{zipOutPath}/{imgFileName}";
                    chart.ToImage(imgPath);

                    var previewChart = new PreviewChart
                    {
                        WorkbookHash = doc.GetHashCode(),
                        SheetIndex = sheet.Index,
                        ChartHash = chart.GetHashCode(),
                        ChartName = Path.GetFileNameWithoutExtension(imgPath),
                        ImgFolderName = folderName,
                        ImgFileName = imgFileName
                    };
                    charts.Add(previewChart);
                }
            }

            return charts;
        }

        private static ImageFormat _imageFormat(string outputType)
        {
            switch (outputType)
            {
                case "JPG":
                    return ImageFormat.Jpeg;
                case "PNG":
                    return ImageFormat.Png;
                case "EMF":
                    return ImageFormat.Emf;
                case "WMF":
                    return ImageFormat.Wmf;
                case "BMP":
                    return ImageFormat.Bmp;
                case "TIFF":
                    return ImageFormat.Tiff;
                default:
                    return ImageFormat.Jpeg;
            }
        }
    }
}