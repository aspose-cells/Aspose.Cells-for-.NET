using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Cells.API.Models;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    ///<Summary>
    /// AsposeCellsConversionController class to convert cells files to different formats
    ///</Summary>
    public class AsposeCellsConversionController : AsposeCellsBaseController
    {
        [MimeMultipart]
        [HttpPost]
        [ActionName("Convert")]
        public async Task<Response> Convert(string outputType)
        {
            var sessionId = Guid.NewGuid().ToString();
            var action = $"Convert to {outputType.Trim().ToLower()}";

            try
            {
                var docs = await UploadWorkBooks(sessionId);
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;
                SetDefaultOptions(docs);
                Opts.AppName = ConversionApp;
                Opts.MethodName = "Convert";
                Opts.ZipFileName = docs.Length > 1 ? "Converted files" : Path.GetFileNameWithoutExtension(docs[0].FileName);
                Opts.OutputType = outputType.Trim().ToLower();

                if (Opts.OutputType.Equals(".html"))
                {
                    if (docs.Length > 1)
                    {
                        Opts.CreateZip = true;
                    }
                    else
                    {
                        Opts.CreateZip = docs[0].Workbook.Worksheets.Count > 1;
                    }
                }

                var saveOpt = GetSaveOptions(outputType.Trim().ToLower());
                return await Process((inFilePath, outPath, zipOutFolder) =>
                {
                    var stopWatch = new Stopwatch();

                    stopWatch.Start();
                    NLogger.LogInfo($"Convert to {outputType.Trim().ToLower()}=>{string.Join(",", docs.Select(t => t.FileName))}=>Start", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);

                    var tasks = docs.Select(doc => Task.Factory.StartNew(() => SaveDocument(doc, outPath, zipOutFolder, saveOpt))).ToArray();
                    Task.WaitAll(tasks);

                    stopWatch.Stop();
                    NLogger.LogInfo($"Convert to {outputType.Trim().ToLower()}=>{string.Join(",", docs.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);
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