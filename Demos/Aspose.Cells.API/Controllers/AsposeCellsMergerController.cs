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
    /// <summary>
    ///
    /// </summary>
    public class AsposeCellsMergerController : AsposeCellsBaseController
    {
        private const string App = "Merger";

        ///<Summary>
        /// Merge method to call merger controller based on product name
        ///</Summary>
        [HttpGet]
        [ActionName("Merge")]
        public async Task<Response> Merge(string outputType, string mergerType)
        {
            var sessionId = Guid.NewGuid().ToString();
            var action = $"Merge to {outputType}";
            try
            {
                var taskUpload = Task.Run(() => UploadWorkbooks(sessionId));
                taskUpload.Wait(Api.Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    NLogger.LogError($"Merge UploadWorkbooks=>{sessionId}=>{AppSettings.ProcessingTimedout}");
                    throw new TimeoutException(AppSettings.ProcessingTimedout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length <= 1 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = "Merger";
                Opts.MethodName = "Merge";
                Opts.ResultFileName = $"Merged file{Opts.OutputType}";
                Opts.CreateZip = Opts.OutputType.Equals(".html");
                Opts.ZipFileName = "Merged file";
                Opts.FolderName = docs[0].FolderName;
                Opts.DeleteSourceFolder = true;

                var saveOpt = GetSaveOptions(outputType.Trim().ToLower());
                return await Process((inFilePath, outPath, zipOutFolder) =>
                {
                    var outWorkbook = new Workbook();
                    if (!IsImage(docs[0].FileName)) outWorkbook.Worksheets.RemoveAt(0);

                    var index = 0;
                    foreach (var doc in docs)
                    {
                        switch (Path.GetExtension(doc.FileName))
                        {
                            case ".jpg":
                            case ".png":
                                var upperLeftRow = outWorkbook.Worksheets[0].Pictures.Count > 0
                                    ? outWorkbook.Worksheets[0].Pictures[index].LowerRightRow
                                    : index;
                                index = outWorkbook.Worksheets[0].Pictures.Add(upperLeftRow, 0, doc.FileName);
                                break;
                            case ".html":
                            case ".mht":
                            case ".mhtml":
                            case ".xlsx":
                            case ".xls":
                            case ".xlsm":
                            case ".xlsb":
                            case ".ods":
                            case ".csv":
                            case ".tsv":
                                outWorkbook.Combine(new Workbook(doc.FileName));
                                break;
                        }
                    }

                    if (mergerType.Equals("s"))
                    {
                        outWorkbook = MergeToSheet(outWorkbook);
                    }

                    var documentInfo = new DocumentInfo {FileName = outPath, FolderName = Path.GetDirectoryName(outPath), Workbook = outWorkbook};

                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    NLogger.LogInfo($"Merge to {outputType.Trim().ToLower()}=>{string.Join(",", docs.Select(t => t.FileName))}=>Start");

                    var task = Task.Run(() => { SaveDocument(documentInfo, outPath, zipOutFolder, saveOpt); });
                    var isCompleted = task.Wait(Api.Configuration.MillisecondsTimeout);

                    if (!isCompleted)
                    {
                        NLogger.LogError($"Merge to {outputType.Trim().ToLower()}=>{string.Join(",", docs.Select(t => t.FileName))}=>{AppSettings.ProcessingTimedout}");
                        throw new TimeoutException(AppSettings.ProcessingTimedout);
                    }

                    stopWatch.Stop();
                    NLogger.LogInfo($"Merge to {outputType.Trim().ToLower()}=>{string.Join(",", docs.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}");
                });
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                var message = $"{exception.Message} | outputType = {outputType} | mergerType = {mergerType}";
                NLogger.LogError(App, "Merge", message, sessionId);

                return new Response
                {
                    StatusCode = 500,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = action
                };
            }
        }

        private static Workbook MergeToSheet(Workbook workbook)
        {
            var destWorkbook = new Workbook();
            var destSheet = destWorkbook.Worksheets[0];

            var totalRowCount = 0;

            foreach (var sourceSheet in workbook.Worksheets)
            {
                var sourceRange = sourceSheet.Cells.MaxDisplayRange;

                var destRange = destSheet.Cells.CreateRange(sourceRange.FirstRow + totalRowCount,
                    sourceRange.FirstColumn,
                    sourceRange.RowCount, sourceRange.ColumnCount);

                destRange.Copy(sourceRange);

                totalRowCount = sourceRange.RowCount + totalRowCount;
            }

            return destWorkbook;
        }
    }
}