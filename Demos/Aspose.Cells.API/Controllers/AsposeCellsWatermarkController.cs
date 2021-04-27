using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Models;
using Aspose.Cells.Drawing;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    ///<Summary>
    /// AsposeCellsWatermarkController class to add or remove watermark from excel file
    ///</Summary>
    public class AsposeCellsWatermarkController : AsposeCellsBaseController
    {
        private const string App = "Watermark";

        private static Color GetColor(string watermarkColor)
        {
            if (watermarkColor == "") return Color.Black;
            if (!watermarkColor.StartsWith("#"))
            {
                watermarkColor = "#" + watermarkColor;
            }

            return ColorTranslator.FromHtml(watermarkColor);
        }

        ///<Summary>
        /// Add Watermark to Worksheet method to add watermark to worksheet
        ///</Summary>
        [HttpPost]
        [ActionName("AddTextWatermark")]
        public async Task<Response> AddTextWatermark(string watermarkText, string watermarkColor)
        {
            var sessionId = Guid.NewGuid().ToString();
            const string action = "AddTextWatermark";
            try
            {
                var taskUpload = Task.Run(() => UploadWorkbooks(sessionId));
                taskUpload.Wait(Api.Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    NLogger.LogError($"Watermark UploadWorkbooks=>{sessionId}=>{AppSettings.ProcessingTimedout}");
                    throw new TimeoutException(AppSettings.ProcessingTimedout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;
                var color = GetColor(watermarkColor);
                SetDefaultOptions(docs);
                Opts.AppName = "Watermark";
                Opts.MethodName = "AddTextWatermark";
                Opts.ZipFileName = docs.Length > 1 ? "Watermark files" : Path.GetFileNameWithoutExtension(docs[0].FileName);

                return await Process((inFilePath, outPath, zipOutFolder) =>
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    NLogger.LogInfo($"Watermark=>{string.Join(",", docs.Select(t => t.FileName))}=>Start");

                    var task = Task.Run(() =>
                    {
                        foreach (var doc in docs)
                        {
                            var workbook = doc.Workbook;
                            foreach (var sheet in workbook.Worksheets)
                            {
                                //// Add Watermark
                                var addTextEffect = sheet.Shapes.AddTextEffect(MsoPresetTextEffect.TextEffect1,
                                    watermarkText, "Arial Black", 60, true, true
                                    , 18, 8, 1, 1, 130, 800);
                                addTextEffect.Fill.FillType = FillType.Solid;
                                addTextEffect.Fill.SolidFill.Color = color;
                            }

                            SaveDocument(doc, outPath, zipOutFolder, GetSaveFormatType(doc.FileName));
                        }
                    });
                    var isCompleted = task.Wait(Api.Configuration.MillisecondsTimeout);

                    if (!isCompleted)
                    {
                        NLogger.LogError($"Watermark=>{string.Join(",", docs.Select(t => t.FileName))}=>{AppSettings.ProcessingTimedout}");
                        throw new TimeoutException(AppSettings.ProcessingTimedout);
                    }

                    stopWatch.Stop();
                    NLogger.LogInfo($"Watermark =>{string.Join(",", docs.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}");
                });
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                var message = $"{exception.Message} | watermarkText = {watermarkText} | watermarkColor = {watermarkColor}";
                NLogger.LogError(App, "AddTextWatermark", message, sessionId);

                return new Response
                {
                    StatusCode = 500,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = action
                };
            }
        }
    }
}