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
    public class AsposeCellsConversionController : AsposeCellsBaseController
    {
        private const string App = "Conversion";

        [MimeMultipart]
        [HttpPost]
        [ActionName("Convert")]
        public async Task<Response> Convert(string outputType)
        {
            var sessionId = Guid.NewGuid().ToString();
            var action = $"Convert to {outputType}";

            try
            {
                var taskUpload = Task.Run(() => UploadWorkbooks(sessionId));
                taskUpload.Wait(Api.Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    NLogger.LogError($"Convert UploadWorkbooks=>{sessionId}=>{AppSettings.ProcessingTimedout}");
                    throw new TimeoutException(AppSettings.ProcessingTimedout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;
                SetDefaultOptions(docs);
                Opts.AppName = "Conversion";
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
                    NLogger.LogInfo($"Convert to {outputType.Trim().ToLower()}=>{string.Join(",", docs.Select(t => t.FileName))}=>Start");

                    var tasks = docs.Select(doc => Task.Factory.StartNew(() => SaveDocument(doc, outPath, zipOutFolder, saveOpt))).ToArray();
                    var isCompleted = Task.WaitAll(tasks, Api.Configuration.MillisecondsTimeout);
                    if (!isCompleted)
                    {
                        NLogger.LogError($"Convert to {outputType.Trim().ToLower()}=>{string.Join(",", docs.Select(t => t.FileName))}=>{AppSettings.ProcessingTimedout}");
                        throw new TimeoutException(AppSettings.ProcessingTimedout);
                    }

                    stopWatch.Stop();
                    NLogger.LogInfo($"Convert to {outputType.Trim().ToLower()}=>{string.Join(",", docs.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}");
                });
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                var message = $"{exception.Message} | outputType = {outputType}";
                NLogger.LogError(App, "Convert", message, sessionId);

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