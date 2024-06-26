﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Aspose.Cells.Common.Services;
using Aspose.Cells.Drawing;
using Aspose.Cells.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Aspose.Cells.Chart.Controllers
{
    public class ChartApiController : CellsApiControllerBase
    {
        private const string AppName = "Chart";

        public ChartApiController(IStorageService storage, IConfiguration configuration, ILogger<ChartApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        [ActionName("Download")]
        public async Task<Response> Download([FromBody] JObject obj)
        {
            var charts = obj["charts"].ToObject<List<PreviewChart>>();
            var outputType = Convert.ToString(obj["outputType"]);
            if (charts == null || outputType == null)
            {
                return new Response
                {
                    Status = "Save failed, please try again",
                    StatusCode = 500
                };
            }

            string outfileName;
            var folderName = Guid.NewGuid().ToString();
            if (outputType is "PDF")
            {
                var index = 0;
                var workbook = new Workbook();

                foreach (var chart in charts)
                {
                    var upperLeftRow = workbook.Worksheets[0].Pictures.Count > 0 ? workbook.Worksheets[0].Pictures[index].LowerRightRow : index;
                    var imgPath = $"{Configuration.ConvertFolder}/{chart.ImgFolderName}/{chart.ImgFileName}";
                    var stream = await Storage.Download(imgPath);
                    index = workbook.Worksheets[0].Pictures.Add(upperLeftRow, 0, stream);
                }

                outfileName = $"{Configuration.ConvertFolder}/{folderName}/charts.pdf";
                await using var memoryStream = new MemoryStream();
                workbook.Save(memoryStream, SaveFormat.Pdf);
                memoryStream.Seek(0, SeekOrigin.Begin);
                await Storage.Upload(outfileName, memoryStream, new AwsMetaInfo
                {
                    OriginalFileName = Path.GetFileName(outfileName),
                    Title = Path.GetFileName(outfileName)
                });
            }
            else
            {
                var streams = new Dictionary<string, Stream>();
                foreach (var chart in charts)
                {
                    var imgPath = $"{Configuration.ConvertFolder}/{chart.ImgFolderName}/{chart.ImgFileName}";
                    var stream = await Storage.Download(imgPath);

                    var filename = $"{Path.GetFileNameWithoutExtension(imgPath)}.{outputType.ToLower()}";
                    var ms = new MemoryStream();
                    switch (outputType)
                    {
                        case "PNG":
                        {
                            await stream.CopyToAsync(ms);
                            break;
                        }
                        case "JPG":
                        case "BMP":
                        case "TIFF":
                        {
                            using var bitmap = new Bitmap(stream);
                            bitmap.Save(ms, _imageFormat(outputType));
                            break;
                        }
                        case "SVG":
                        case "XPS":
                        {
                            var workbook = new Workbook();
                            workbook.Worksheets[0].Pictures.Add(0, 0, stream);
                            workbook.Save(ms, _saveFormat(outputType));
                            break;
                        }
                    }

                    if (ms.Length > 0)
                    {
                        ms.Seek(0, SeekOrigin.Begin);
                        streams.Add(filename, ms);
                    }

                    stream.Close();
                }

                await using var zipStream = new MemoryStream();
                using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                {
                    foreach (var (filename, stream) in streams)
                    {
                        var entry = archive.CreateEntry(filename);
                        await using var entryStream = entry.Open();
                        await stream.CopyToAsync(entryStream);
                        stream.Close();
                    }
                }

                outfileName = $"{Configuration.ConvertFolder}/{folderName}/charts.zip";
                zipStream.Seek(0, SeekOrigin.Begin);
                await Storage.Upload(outfileName, zipStream, new AwsMetaInfo
                {
                    OriginalFileName = Path.GetFileName(outfileName),
                    Title = Path.GetFileName(outfileName)
                });
            }

            if (outfileName.IsNullOrEmpty())
                return new Response
                {
                    Status = "Save failed, please try again",
                    StatusCode = 500
                };

            return new Response
            {
                StatusCode = 200,
                Status = "OK",
                FileName = Path.GetFileName(outfileName),
                FolderName = folderName
            };
        }

        [HttpPost]
        [ActionName("PreChart")]
        public async Task<PreviewChartsResponse> PreChart(string outputType)
        {
            var sessionId = Guid.NewGuid().ToString();
            var action = $"Chart to {outputType}";
            try
            {
                var taskUpload = Task.Run(() => UploadWorkbooks(sessionId, AppName));
                taskUpload.Wait(Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    Logger.LogError(
                        "{AppName} UploadWorkBooks=>{SessionId}=>{Timeout}",
                        AppName,
                        sessionId,
                        Configuration.ProcessingTimeout);
                    throw new TimeoutException(Configuration.ProcessingTimeout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return (PreviewChartsResponse) PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return (PreviewChartsResponse) MaximumFileLimitsResponse;

                var charts = new List<PreviewChart>();
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning(
                    "Chart to {OutputType}=>{Filenames}=>Start",
                    outputType.Trim().ToLower(),
                    string.Join(",", docs.Select(t => t.FileName))
                );

                var tasks = docs.Select(doc =>
                    Task.Run(async () => { charts.AddRange(await PreCharts(doc, sessionId)); })).ToArray();
                var isCompleted = Task.WaitAll(tasks, Configuration.MillisecondsTimeout);

                if (!isCompleted)
                {
                    Logger.LogError(
                        "Chart to {OutputType}=>{FileNames}=>{ProcessingTimeout}",
                        outputType.Trim().ToLower(),
                        string.Join(",", docs.Select(t => t.FileName)),
                        Configuration.ProcessingTimeout
                    );
                    throw new TimeoutException(Configuration.ProcessingTimeout);
                }

                stopWatch.Stop();

                Logger.LogWarning(
                    "Chart to {OutputType}=>{Filenames}=>cost seconds:{TotalSeconds}",
                    outputType.Trim().ToLower(),
                    string.Join(",", docs.Select(t => t.FileName)),
                    stopWatch.Elapsed.TotalSeconds
                );

                if (charts.Count > 0)
                    return new PreviewChartsResponse
                    {
                        StatusCode = 200,
                        Status = "OK",
                        FolderName = sessionId,
                        Charts = charts,
                        OutputType = outputType
                    };

                return new PreviewChartsResponse
                {
                    StatusCode = 404,
                    Status = "There's no chart in the Excel file.",
                    FolderName = sessionId,
                    Text = "There's no chart in the Excel file."
                };
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
                    "Action = {Action} | Message = {Message} | OutputType = {OutputType} | SessionId = {SessionId}",
                    action,
                    exception.Message,
                    outputType,
                    sessionId
                );

                return new PreviewChartsResponse
                {
                    StatusCode = statusCode,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = action
                };
            }
        }

        private async Task<IEnumerable<PreviewChart>> PreCharts(DocumentInfo doc, string folderName)
        {
            var charts = new List<PreviewChart>();
            foreach (var sheet in doc.Workbook.Worksheets)
            {
                foreach (var chart in sheet.Charts)
                {
                    var imgFilename = $"{sheet.Name} {chart.Name}.png";
                    await using (var ms = new MemoryStream())
                    {
                        var objectPath = $"{Configuration.ConvertFolder}/{folderName}/{imgFilename}";
                        chart.ToImage(ms, new ImageOrPrintOptions {ImageType = ImageType.Png});
                        await Storage.Upload(objectPath, ms, new AwsMetaInfo
                        {
                            OriginalFileName = imgFilename,
                            Title = imgFilename
                        });
                    }

                    var previewChart = new PreviewChart
                    {
                        WorkbookHash = doc.GetHashCode(),
                        SheetIndex = sheet.Index,
                        ChartHash = chart.GetHashCode(),
                        ChartName = Path.GetFileNameWithoutExtension(imgFilename),
                        ImgFolderName = folderName,
                        ImgFileName = imgFilename
                    };
                    charts.Add(previewChart);
                }
            }

            return charts;
        }

        private static SaveFormat _saveFormat(string outputType)
        {
            return outputType switch
            {
                "SVG" => SaveFormat.SVG,
                "XPS" => SaveFormat.XPS,
                _ => SaveFormat.Unknown
            };
        }

        private static ImageFormat _imageFormat(string outputType)
        {
            return outputType switch
            {
                "JPG" => ImageFormat.Jpeg,
                "PNG" => ImageFormat.Png,
                "BMP" => ImageFormat.Bmp,
                "TIFF" => ImageFormat.Tiff,
                _ => ImageFormat.Jpeg
            };
        }
    }
}