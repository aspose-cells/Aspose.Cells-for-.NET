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
    public class AsposeCellsSplitterController : AsposeCellsBaseController
    {
        private const string App = "Splitter";

        ///<Summary>
        /// Split method
        ///</Summary>
        [MimeMultipart]
        [HttpPost]
        [ActionName("Split")]
        public async Task<Response> Split(string outputType)
        {
            var sessionId = Guid.NewGuid().ToString();
            var action = $"Split to {outputType}";
            try
            {
                var taskUpload = Task.Run(() => UploadWorkbooks(sessionId));
                taskUpload.Wait(Api.Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    NLogger.LogError($"Splitter UploadWorkbooks=>{sessionId}=>{AppSettings.ProcessingTimedout}");
                    throw new TimeoutException(AppSettings.ProcessingTimedout);
                }

                var docs = taskUpload.Result;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = "Splitter";
                Opts.MethodName = "Split";
                Opts.CreateZip = true;
                Opts.ZipFileName = "Splitted files";
                Opts.OutputType = outputType.Trim().ToLower();

                var saveOpt = GetSaveOptions(outputType.Trim().ToLower());
                return await Process((inFilePath, outPath, zipOutFolder) =>
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    NLogger.LogInfo($"Split to {outputType.Trim().ToLower()}=>{string.Join(",", docs.Select(t => t.FileName))}=>Start");

                    var task = Task.Run(() =>
                    {
                        foreach (var doc in docs)
                        {
                            var workbook = doc.Workbook;
                            var worksheetCollection = workbook.Worksheets;
                            var i = worksheetCollection.Count;

                            for (var j = 0; j < i; j++)
                            {
                                var sheet = worksheetCollection[j];
                                var newWorkbook = new Workbook();
                                newWorkbook.Worksheets[0].Copy(sheet);
                                var documentInfo = new DocumentInfo {Workbook = newWorkbook};

                                string ext;
                                if (outputType.Equals("-"))
                                {
                                    ext = Path.GetExtension(doc.FileName);
                                }
                                else
                                {
                                    ext = "." + outputType.Trim().ToLower();
                                }

                                var l = outPath.Split('.');
                                var newOutPath = l[0] + "_" + sheet.Name + ext;
                                newOutPath = NewOutPath(newOutPath);
                                newWorkbook.Save(newOutPath);
                                documentInfo.FileName = Path.GetFileName(newOutPath);

                                SaveDocument(documentInfo, newOutPath, zipOutFolder, saveOpt);
                            }
                        }
                    });
                    var isCompleted = task.Wait(Api.Configuration.MillisecondsTimeout);

                    if (!isCompleted)
                    {
                        NLogger.LogError($"Split to {outputType.Trim().ToLower()}=>{string.Join(",", docs.Select(t => t.FileName))}=>{AppSettings.ProcessingTimedout}");
                        throw new TimeoutException(AppSettings.ProcessingTimedout);
                    }

                    stopWatch.Stop();
                    NLogger.LogInfo($"Split to {outputType.Trim().ToLower()}=>{string.Join(",", docs.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}");
                });
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                var message = $"{exception.Message} | outputType = {outputType}";
                NLogger.LogError(App, "Split", message, sessionId);

                return new Response
                {
                    StatusCode = 500,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = action
                };
            }
        }

        public string NewOutPath(string path)
        {
            var directory = Path.GetDirectoryName(path);
            var filename = Path.GetFileNameWithoutExtension(path);
            var extension = Path.GetExtension(path);
            var counter = 1;
            var newFilename = $"{filename}{extension}";
            var newFullPath = Path.Combine(directory, newFilename);
            while (File.Exists(path))
            {
                newFilename = $"{filename}({counter}){extension}";
                newFullPath = Path.Combine(directory, newFilename);
                counter++;
            }

            path = newFullPath;

            return path;
        }
    }
}