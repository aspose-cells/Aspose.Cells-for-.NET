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
    public class AsposeCellsProtectController : AsposeCellsBaseController
    {
        [HttpGet]
        [ActionName("Protect")]
        public async Task<Response> Protect(string password)
        {
            var sessionId = Guid.NewGuid().ToString();
            const string action = "Protect";

            try
            {
                var workbooks = await UploadWorkBooks(sessionId);
                if (workbooks.Length == 0 || workbooks.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(workbooks);
                Opts.AppName = ProtectApp;
                Opts.MethodName = "Protect";
                Opts.ZipFileName = workbooks.Length > 1 ? "Protected files" : Path.GetFileNameWithoutExtension(workbooks[0].FileName);

                return await Process((inFilePath, outPath, zipOutFolder) =>
                {
                    foreach (var docInfo in workbooks)
                    {
                        var workbook = docInfo.Workbook;
                        workbook.Settings.Password = password;
                    }

                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    NLogger.LogInfo($"Excel Protect=>{string.Join(",", workbooks.Select(t => t.FileName))}=>Start", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);

                    var tasks = workbooks.Select(doc => Task.Factory.StartNew(() => SaveDocument(doc, outPath, zipOutFolder, GetSaveFormatType(doc.FileName)))).ToArray();
                    Task.WaitAll(tasks);

                    stopWatch.Stop();
                    NLogger.LogInfo($"Excel Protect=>{string.Join(",", workbooks.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);
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