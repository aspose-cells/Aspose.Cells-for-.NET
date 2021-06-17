using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Aspose.Cells.Common.Services;
using Aspose.Cells.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Watermark.Controllers
{
    public class WatermarkApiController : CellsApiControllerBase
    {
        private const string AppName = "Watermark";

        public WatermarkApiController(IStorageService storage, IConfiguration configuration, ILogger<WatermarkApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        [ActionName("AddTextWatermark")]
        public async Task<Response> AddTextWatermark(string watermarkText, string watermarkColor)
        {
            var sessionId = Guid.NewGuid().ToString();
            try
            {
                var taskUpload = UploadWorkbooks(sessionId, AppName);
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
                    return PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;
                SetDefaultOptions(docs);
                Opts.AppName = "Watermark";
                Opts.MethodName = "AddTextWatermark";
                Opts.ZipFileName = "Watermark files";
                Opts.FolderName = sessionId;

                await Storage.UpdateStatus(Common.Models.Response.Process(Opts.FolderName, Opts.ResultFileName));

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Logger.LogWarning(
                    "AppName = {AppName} | Filename = {Filename} | Start",
                    AppName,
                    string.Join(",", docs.Select(t => t.FileName)));

                var taskProcessCellsBlock = ProcessCellsBlock(docs, watermarkText, watermarkColor);
                taskProcessCellsBlock.Wait(Configuration.MillisecondsTimeout);
                if (!taskProcessCellsBlock.IsCompleted)
                {
                    Logger.LogError(
                        "{AppName} ProcessCellsBlock=>{SessionId}=>{ProcessingTimeout}",
                        AppName,
                        sessionId,
                        Configuration.ProcessingTimeout);
                    throw new TimeoutException(Configuration.ProcessingTimeout);
                }

                stopWatch.Stop();
                Logger.LogWarning(
                    "AppName = {AppName} | Filename = {Filename} | Cost Seconds = {Seconds}s",
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

                Logger.LogError("AppName = {AppName} | Message = {Message} | WatermarkText = {WatermarkText} | WatermarkColor = {WatermarkColor}",
                    AppName, exception.Message, watermarkText, watermarkColor);

                return new Response
                {
                    StatusCode = statusCode,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = AppName
                };
            }
        }

        private async Task<Response> ProcessCellsBlock(DocumentInfo[] docs, string watermarkText, string watermarkColor)
        {
            var streams = new Dictionary<string, Stream>();
            var (_, outFilePath) = BeforeAction();
            var catchException = false;
            var exception = new Exception();

            foreach (var doc in docs)
            {
                try
                {
                    foreach (var sheet in doc.Workbook.Worksheets)
                    {
                        //// Add Watermark
                        var addTextEffect = sheet.Shapes.AddTextEffect(MsoPresetTextEffect.TextEffect1,
                            watermarkText, "Arial Black", 60, true, true
                            , 18, 8, 1, 1, 130, 800);
                        addTextEffect.Fill.FillType = FillType.Solid;
                        addTextEffect.Fill.SolidFill.Color = GetColor(watermarkColor);
                    }

                    var dictionary = SaveDocument(doc, GetSaveFormatTypeByFilename(doc.FileName));
                    foreach (var (key, value) in dictionary)
                    {
                        if (streams.ContainsKey(key)) continue;
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
                    break;
                }
            }

            if (!catchException)
                return await AfterAction(outFilePath, streams);

            await Storage.UpdateStatus(Common.Models.Response.Error(Opts.FolderName, Opts.ResultFileName, exception.Message));
            throw exception;
        }

        private static Color GetColor(string watermarkColor)
        {
            if (watermarkColor == "") return Color.Black;
            if (!watermarkColor.StartsWith("#"))
            {
                watermarkColor = "#" + watermarkColor;
            }

            return ColorTranslator.FromHtml(watermarkColor);
        }
    }
}