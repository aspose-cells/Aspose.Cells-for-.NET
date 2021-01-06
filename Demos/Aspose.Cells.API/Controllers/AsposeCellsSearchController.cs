using System;
using System.Diagnostics;
using System.IO;
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
    /// AsposeCellsSearchController class to perform search on excel files
    ///</Summary>
    public class AsposeCellsSearchController : AsposeCellsBaseController
    {
        /// <summary>
        /// Search method call search controller based on product name
        /// </summary>
        [HttpGet]
        [ActionName("Search")]
        public async Task<Response> Search(string query)
        {
            var sessionId = Guid.NewGuid().ToString();
            const string action = "Search text";

            try
            {
                var docs = await UploadWorkBooks(sessionId);
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = SearchApp;
                Opts.MethodName = "Search";
                Opts.OutputType = ".xlsx";
                Opts.ResultFileName = "Search Results";
                Opts.CreateZip = false;

                var fileName = Path.GetFileName(docs[0].FileName);
                var folderName = docs[0].FolderName;

                return await Search(fileName, folderName, query);
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

        /// <summary>
        /// MFoundNothing
        /// </summary>
        public bool MFoundNothing = true;

        ///<Summary>
        /// SearchQuery
        ///</Summary>
        public void SearchQuery(string fileName, string folderName, string query, string outPath)
        {
            var fn = AppSettings.WorkingDirectory + folderName + "/" + fileName;

            // Load the input Excel file.
            var wb = new Workbook(fn);

            // Specify the find options.
            var opts = new FindOptions {LookAtType = LookAtType.Contains, LookInType = LookInType.Values};

            var findText = query;
            var found = new StringBuilder();

            found.AppendLine("Searched Text: " + query);
            found.AppendLine("===========================================");
            found.AppendLine();

            //Check if found nothing
            MFoundNothing = true;

            Cell cell = null;

            foreach (var ws in wb.Worksheets)
            {
                found.AppendLine("Sheet Name: " + ws.Name);
                found.AppendLine();

                do
                {
                    cell = ws.Cells.Find(findText, cell);

                    if (cell == null)
                        break;

                    MFoundNothing = false;
                    found.AppendLine("Cell Name: " + cell.Name);
                    found.AppendLine("Cell Value: " + cell.StringValue);
                    found.AppendLine();
                } while (true);

                found.AppendLine("===========================================");
                found.AppendLine();
            }

            if (MFoundNothing)
            {
                var dn = Path.GetDirectoryName(outPath);
                if (dn != null) Directory.Delete(dn);
                return;
            }

            var strFound = found.ToString();
            File.WriteAllText(outPath, strFound);
        }

        ///<Summary>
        /// Search method to perform search
        ///</Summary>
        public async Task<Response> Search(string fileName, string folderName, string query)
        {
            var taskResp = Process(GetType().Name, "SearchResults", folderName, ".txt", false, false,
                AsposeCells + SearchApp, ProductFamilyNameKeysEnum.cells, "Search",
                (inFilePath, outPath, zipOutFolder) =>
                {
                    var fn = AppSettings.WorkingDirectory + folderName + "/" + fileName;
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    NLogger.LogInfo($"Search {query}=>{fn}=>Start", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);

                    var task = Task.Run(() => { SearchQuery(fileName, folderName, query, outPath); });
                    Task.WaitAll(task);

                    stopWatch.Stop();
                    NLogger.LogInfo($"Search {query}=>{fn}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);
                });

            if (MFoundNothing)
            {
                taskResp.Result.FileProcessingErrorCode = FileProcessingErrorCode.NoSearchResults;
            }

            return await taskResp;
        }
    }
}