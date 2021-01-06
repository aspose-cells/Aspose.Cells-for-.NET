using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Cells.API.Models;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    /// <summary>
    /// AsposeCellsUnlockController
    /// </summary>
    public class AsposeCellsUnlockController : AsposeCellsBaseController
    {
        /// <summary>
        /// Unlock
        /// </summary>
        /// <param name="passw"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Unlock")]
        public async Task<Response> Unlock(string passw)
        {
            var sessionId = Guid.NewGuid().ToString();
            const string action = "Unlock";

            try
            {
                var docs = await UploadFiles(sessionId, passw);
                if (docs == null)
                    return new Response
                    {
                        Status = "Invalid password.",
                        StatusCode = 500
                    };
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = UnlockApp;
                Opts.MethodName = "Unlock";
                Opts.ZipFileName = "Unlocked files";

                return await Process((inFilePath, outPath, zipOutFolder) =>
                {
                    foreach (var docInfo in docs)
                    {
                        var workbook = docInfo.Workbook;
                        workbook.Settings.Password = "";
                    }

                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    NLogger.LogInfo($"Unlock=>{string.Join(",", docs.Select(t => t.FileName))}=>Start", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);

                    var tasks = docs.Select(doc => Task.Factory.StartNew(() => SaveDocument(doc, outPath, zipOutFolder, GetSaveFormatType(doc.FileName)))).ToArray();
                    Task.WaitAll(tasks);

                    stopWatch.Stop();
                    NLogger.LogInfo($"Unlock=>{string.Join(",", docs.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);
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