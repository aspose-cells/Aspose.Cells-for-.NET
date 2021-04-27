using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Models;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    public class AsposeCellsUnlockController : AsposeCellsBaseController
    {
        private const string App = "Unlock";

        [HttpGet]
        [ActionName("Unlock")]
        public async Task<Response> Unlock(string passw)
        {
            var sessionId = Guid.NewGuid().ToString();
            const string action = "Unlock";
            try
            {
                var taskUpload = Task.Run(() => UploadFiles(sessionId, passw));
                taskUpload.Wait(Api.Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    NLogger.LogError($"Unlock UploadWorkbooks=>{sessionId}=>{AppSettings.ProcessingTimedout}");
                    throw new TimeoutException(AppSettings.ProcessingTimedout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return new Response
                    {
                        Status = "Invalid password.",
                        StatusCode = 201
                    };
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = "Unlock";
                Opts.MethodName = "Unlock";
                Opts.ZipFileName = "Unlocked files";

                return await Process((inFilePath, outPath, zipOutFolder) =>
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    NLogger.LogInfo($"Unlock=>{string.Join(",", docs.Select(t => t.FileName))}=>Start");

                    var task = Task.Run(() =>
                    {
                        foreach (var doc in docs)
                        {
                            doc.Workbook.Settings.Password = "";
                            SaveDocument(doc, outPath, zipOutFolder, GetSaveFormatType(doc.FileName));
                        }
                    });
                    var isCompleted = task.Wait(Api.Configuration.MillisecondsTimeout);

                    if (!isCompleted)
                    {
                        NLogger.LogError($"Unlock=>{string.Join(",", docs.Select(t => t.FileName))}=>{AppSettings.ProcessingTimedout}");
                        throw new TimeoutException(AppSettings.ProcessingTimedout);
                    }

                    stopWatch.Stop();
                    NLogger.LogInfo($"Unlock=>{string.Join(",", docs.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}");
                });
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                var message = $"{exception.Message} | password = {passw}";
                NLogger.LogError(App, "Unlock", message, sessionId);

                return new Response
                {
                    StatusCode = 201,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = action
                };
            }
        }
    }
}