using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
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
        private async Task<Response> ProcessTask(string fileName, string folderName, string outFileExtension, bool createZip, bool checkNumberofPages, ActionDelegate action)
        {
            return await Process(GetType().Name, fileName, folderName, outFileExtension, createZip, checkNumberofPages, AsposeCells + WatermarkApp, ProductFamilyNameKeysEnum.cells, new StackTrace().GetFrame(5).GetMethod().Name, action);
        }

        private static SaveFormat GetSaveFormat(string outputType)
        {
            switch (outputType)
            {
                case "csv":
                    return SaveFormat.CSV;
                case "xlsb":
                    return SaveFormat.Xlsb;
                case "xlsm":
                    return SaveFormat.Xlsm;
                case "xlsx":
                    return SaveFormat.Xlsx;
                case "xltm":
                    return SaveFormat.Xltm;
                case "xltx":
                    return SaveFormat.Xltx;
                case "pdf":
                    return SaveFormat.Pdf;
                case "xls":
                    return SaveFormat.Xlsx;
                case "tiff":
                    return SaveFormat.TIFF;
                case "ods":
                    return SaveFormat.ODS;
            }

            return SaveFormat.Xlsx;
        }

        private Color GetColor(string watermarkColor)
        {
            if (watermarkColor == "") return Color.Black;
            if (!watermarkColor.StartsWith("#"))
            {
                watermarkColor = "#" + watermarkColor;
            }

            return ColorTranslator.FromHtml(watermarkColor);
        }

        ///<Summary>
        /// AddWatermarktoChart method to add watermark to chart
        ///</Summary>
        [HttpGet]
        [ActionName("AddWatermarktoChart")]
        private async Task<Response> AddWatermarktoChart(string fileName, string folderName, string watermarkText, string userEmail, string outputType, string watermarkColor)
        {
            return await ProcessTask(fileName, folderName, "." + outputType, false, false, delegate(string inFilePath, string outPath, string zipOutFolder)
            {
                var workbook = new Workbook(inFilePath);

                foreach (var sheet in workbook.Worksheets)
                {
                    foreach (var chart in sheet.Charts)
                    {
                        // Add a WordArt watermark (shape) to the chart's plot area.
                        var wordart = chart.Shapes.AddTextEffectInChart(MsoPresetTextEffect.TextEffect2,
                            watermarkText, "Arial Black", 66, false, false, 1200, 500, 2000, 3000);

                        // Get the shape's fill format.
                        var wordArtFormat = wordart.Fill;

                        // Set the transparency.
                        wordArtFormat.Transparency = 0.9;

                        // Get the line format.
                        var lineFormat = wordart.Line;

                        // Set Line format to invisible.
                        lineFormat.Weight = 0.0;
                    }
                }

                if (outputType == "xls")
                {
                    workbook.Save(outPath);
                }
                else
                {
                    workbook.Save(outPath, GetSaveFormat(outputType));
                }
            });
        }

        ///<Summary>
        /// AddWatermarktoWorksheet method to add watermark to worksheet
        ///</Summary>
        [HttpPost]
        [ActionName("AddTextWatermark")]
        public async Task<Response> AddTextWatermark(string watermarkText, string watermarkColor)
        {
            var sessionId = Guid.NewGuid().ToString();
            const string action = "AddTextWatermark";

            try
            {
                var workbooks = await UploadWorkBooks(sessionId);
                if (workbooks == null)
                    return PasswordProtectedResponse;
                if (workbooks.Length == 0 || workbooks.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;
                var color = GetColor(watermarkColor);
                SetDefaultOptions(workbooks);
                Opts.AppName = WatermarkApp;
                Opts.MethodName = "AddTextWatermark";
                Opts.ZipFileName = workbooks.Length > 1 ? "Watermark files" : Path.GetFileNameWithoutExtension(workbooks[0].FileName);

                return await Process((inFilePath, outPath, zipOutFolder) =>
                {
                    foreach (var docInfo in workbooks)
                    {
                        var workbook = docInfo.Workbook;
                        foreach (var sheet in workbook.Worksheets)
                        {
                            //// Add Watermark
                            var wordart = sheet.Shapes.AddTextEffect(MsoPresetTextEffect.TextEffect1,
                                watermarkText, "Arial Black", 60, true, true
                                , 18, 8, 1, 1, 130, 800);
                            wordart.Fill.FillType = FillType.Solid;
                            wordart.Fill.SolidFill.Color = color;
                        }
                    }

                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    NLogger.LogInfo($"Watermark=>{string.Join(",", workbooks.Select(t => t.FileName))}=>Start", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);

                    var tasks = workbooks.Select(doc => Task.Factory.StartNew(() => SaveDocument(doc, outPath, zipOutFolder, GetSaveFormatType(doc.FileName)))).ToArray();
                    Task.WaitAll(tasks);

                    stopWatch.Stop();
                    NLogger.LogInfo($"Watermark =>{string.Join(",", workbooks.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);
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
    }
}