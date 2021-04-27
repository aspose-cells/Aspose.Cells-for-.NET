using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Models;
using Tools.Foundation.Models;
using File = System.IO.File;

namespace Aspose.Cells.API.Controllers
{
    ///<Summary>
    /// AsposeCellsAnnotationController class to add or remove annotation
    ///</Summary>
    public class AsposeCellsAnnotationController : AsposeCellsBaseController
    {
        private const string App = "Annotation";

        ///<Summary>
        /// Remove method to remove annotation from file based on product name
        ///</Summary>
        [HttpGet]
        [ActionName("Remove")]
        public async Task<Response> Remove()
        {
            var sessionId = Guid.NewGuid().ToString();
            const string action = "Remove annotation";

            try
            {
                var taskUpload = Task.Run(() => UploadWorkbooks(sessionId));
                taskUpload.Wait(Api.Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    NLogger.LogError($"Annotation UploadWorkbooks=>{sessionId}=>{AppSettings.ProcessingTimedout}");
                    throw new TimeoutException(AppSettings.ProcessingTimedout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = "Annotation";
                Opts.MethodName = "Remove";
                Opts.ZipFileName = docs.Length > 1 ? "Removed Annotations" : Path.GetFileNameWithoutExtension(docs[0].FileName);
                Opts.CreateZip = true;

                return await Process((inFilePath, outPath, zipOutFolder) =>
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    NLogger.LogInfo($"Remove Annotations=>{string.Join(",", docs.Select(t => t.FileName))}=>Start");

                    var tasks = docs.Select(doc => Task.Factory.StartNew(() => RemoveAnnotations(doc, zipOutFolder))).ToArray();
                    var isCompleted = Task.WaitAll(tasks, Api.Configuration.MillisecondsTimeout);

                    if (!isCompleted)
                    {
                        NLogger.LogError($"Remove Annotations=>{string.Join(",", docs.Select(t => t.FileName))}=>{AppSettings.ProcessingTimedout}");
                        throw new TimeoutException(AppSettings.ProcessingTimedout);
                    }

                    stopWatch.Stop();
                    NLogger.LogInfo($"Remove Annotations=>{string.Join(",", docs.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}");
                });
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                NLogger.LogError(App, "Remove", exception.Message, sessionId);

                return new Response
                {
                    StatusCode = 500,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = action
                };
            }
        }

        /// <summary>
        /// Remove annotations in document
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="outPath"></param>
        private static void RemoveAnnotations(DocumentInfo doc, string outPath)
        {
            try
            {
                var (filename, folder) = PrepareFolder(doc, outPath);
                // doc.Workbook.Save($"{folder}/{filename}");

                var wb = doc.Workbook;

                var sb = new StringBuilder();

                foreach (var ws in wb.Worksheets)
                {
                    foreach (var cm in ws.Comments)
                    {
                        var cellName = CellsHelper.CellIndexToName(cm.Row, cm.Column);

                        var str = $"Sheet Name: \"{ws.Name}\", Cell Name: {cellName}, Comment Note: \r\n\"{cm.Note}\"";

                        sb.AppendLine(str);
                        sb.AppendLine();
                    }
                }

                File.WriteAllText($"{folder}/comments.txt", sb.ToString());

                foreach (var ws in wb.Worksheets)
                {
                    ws.Comments.Clear();
                }

                // wb.Save(outPath);
                wb.Save($"{folder}/{filename}");
            }
            catch (Exception e)
            {
                NLogger.LogError(App, "RemoveAnnotations", e.Message, outPath);
            }
        }

        ///<Summary>
        /// Remove method to remove annotation from excel file
        ///</Summary>
        public async Task<Response> Remove(string fileName, string folderName)
        {
            Opts.AppName = "Annotation";
            Opts.MethodName = MethodBase.GetCurrentMethod().Name;
            Opts.FolderName = folderName;
            Opts.FileName = fileName;
            Opts.CreateZip = true;
            Opts.OutputType = Path.GetExtension(fileName);
            Opts.ResultFileName = Path.GetFileNameWithoutExtension(fileName) + " Removed Annotations";

            return await Process((inFilePath, outPath, zipOutFolder) => { RemoveAnnotationFromExcelFile(outPath, zipOutFolder); });
        }

        private void RemoveAnnotationFromExcelFile(string outPath, string zipOutFolder)
        {
            var wb = new Workbook(Opts.WorkingFileName);

            var sb = new StringBuilder();

            foreach (var ws in wb.Worksheets)
            {
                foreach (var cm in ws.Comments)
                {
                    var cellName = CellsHelper.CellIndexToName(cm.Row, cm.Column);

                    var str = $"Sheet Name: \"{ws.Name}\", Cell Name: {cellName}, Comment Note: \r\n\"{cm.Note}\"";

                    sb.AppendLine(str);
                    sb.AppendLine();
                }
            }

            File.WriteAllText(zipOutFolder + "\\comments.txt", sb.ToString());


            foreach (var ws in wb.Worksheets)
            {
                ws.Comments.Clear();
            }

            wb.Save(outPath);
        }
    }
}