using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Models;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    public class AsposeCellsProtectController : AsposeCellsBaseController
    {
        private const string App = "Protect";

        [HttpGet]
        [ActionName("Protect")]
        public async Task<Response> Protect(string password)
        {
            var sessionId = Guid.NewGuid().ToString();
            const string action = "Protect";
            try
            {
                var taskUpload = Task.Run(() => UploadWorkbooks(sessionId));
                taskUpload.Wait(Api.Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    NLogger.LogError($"Protect UploadWorkbooks=>{sessionId}=>{AppSettings.ProcessingTimedout}");
                    throw new TimeoutException(AppSettings.ProcessingTimedout);
                }

                var docs = taskUpload.Result;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = "Protect";
                Opts.MethodName = "Protect";
                Opts.ZipFileName = docs.Length > 1 ? "Protected files" : Path.GetFileNameWithoutExtension(docs[0].FileName);

                return await Process((inFilePath, outPath, zipOutFolder) =>
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    NLogger.LogInfo($"Excel Protect=>{string.Join(",", docs.Select(t => t.FileName))}=>Start");

                    var task = Task.Run(() =>
                    {
                        foreach (var doc in docs)
                        {
                            doc.Workbook.Settings.Password = password;
                            SaveDocument(doc, outPath, zipOutFolder, GetSaveFormatType(doc.FileName));
                        }
                    });
                    var isCompleted = task.Wait(Api.Configuration.MillisecondsTimeout);

                    if (!isCompleted)
                    {
                        NLogger.LogError($"Excel Protect=>{string.Join(",", docs.Select(t => t.FileName))}=>{AppSettings.ProcessingTimedout}");
                        throw new TimeoutException(AppSettings.ProcessingTimedout);
                    }

                    stopWatch.Stop();
                    NLogger.LogInfo($"Excel Protect=>{string.Join(",", docs.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}");
                });
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                var message = $"{exception.Message} | password = {password}";
                NLogger.LogError(App, "Protect", message, sessionId);

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