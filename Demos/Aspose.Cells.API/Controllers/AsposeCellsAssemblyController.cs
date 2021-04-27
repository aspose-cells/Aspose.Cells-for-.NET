using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Models;
using Tools.Foundation.Models;
using File = System.IO.File;

namespace Aspose.Cells.API.Controllers
{
    ///<Summary>
    /// AsposeCellsAssemblyController class to assemble excel file
    ///</Summary>
    public class AsposeCellsAssemblyController : AsposeCellsBaseController
    {
        private const string App = "Assembly";

        ///<Summary>
        /// Upload
        ///</Summary>
        [HttpPost]
        [MimeMultipart]
        [ActionName("Upload")]
        public async Task<HttpResponseMessage> Upload(string folderName)
        {
            try
            {
                var provider = new MultipartFormDataStreamProvider(AppSettings.WorkingDirectory);
                await Request.Content.ReadAsMultipartAsync(provider);

                Directory.CreateDirectory(Path.Combine(AppSettings.WorkingDirectory, folderName));

                foreach (var file in provider.FileData)
                {
                    var name = file.Headers.ContentDisposition.FileName.Trim('"');
                    var path = Path.Combine(AppSettings.WorkingDirectory, folderName, name);
                    File.Copy(file.LocalFileName, path, true);
                    File.Delete(file.LocalFileName);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                NLogger.LogError(App, "Upload", e.Message, folderName);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        ///<Summary>
        /// UploadCORS
        ///</Summary>
        [HttpOptions]
        [ActionName("Upload")]
        public HttpResponseMessage UploadCors(string folderName)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        ///<Summary>
        /// Assemble
        ///</Summary>
        [HttpPost]
        [ActionName("Assemble")]
        public async Task<Response> Assemble(string datasourceName)
        {
            var sessionId = Guid.NewGuid().ToString();
            const string action = "Assemble data";
            try
            {
                var taskUpload = Task.Run(() => UploadWorkbooks(sessionId));
                taskUpload.Wait(Api.Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    NLogger.LogError($"Assembly UploadWorkbooks=>{sessionId}=>{AppSettings.ProcessingTimedout}");
                    throw new TimeoutException(AppSettings.ProcessingTimedout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = "Assembly";
                Opts.MethodName = "Assemble";
                Opts.OutputType = ".xlsx";
                Opts.ResultFileName = "Assembled Result";
                Opts.CreateZip = false;

                var templateFilename = Path.GetFileName(docs[0].FileName);
                var datasourceFilename = Path.GetFileName(docs[1].FileName);
                var folderName = docs[1].FolderName;

                return await Assemble(folderName, templateFilename, datasourceFilename, datasourceName);
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                NLogger.LogError(App, "Assemble", exception.Message, sessionId);
                return new Response
                {
                    StatusCode = 500,
                    Status = exception.Message,
                    FolderName = sessionId,
                    Text = action
                };
            }
        }

        ///<Summary>
        /// AssembleCORS
        ///</Summary>
        [HttpOptions]
        [ActionName("Assemble")]
        public HttpResponseMessage AssembleCors(string productName, string folderName, string templateFilename, string datasourceFilename, string datasourceName, int datasourceTableIndex = 0, string delimiter = ",")
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        ///<Summary>
        /// Assemble method to assemble file
        ///</Summary>
        public async Task<Response> Assemble(string folderName, string templateFilename, string datasourceFilename, string datasourceName, int datasourceTableIndex = 0, string delimiter = ",")
        {
            Opts.AppName = "Assembly";
            Opts.MethodName = "AsposeCellsAssemblyController.Assemble()";
            Opts.FolderName = folderName;
            Opts.FileName = datasourceFilename;
            Opts.OutputType = Path.GetExtension(templateFilename);
            Opts.ResultFileName = Path.GetFileNameWithoutExtension(templateFilename) + " Assembled";
            Opts.DeleteSourceFolder = false;
            Opts.ZipFileName = "";
            Opts.CalculateZipFileName = false;

            return await Process((inFilePath, outPath, zipOutFolder) => { AssembleCellsData(inFilePath, outPath, templateFilename, datasourceFilename, datasourceName); });
        }

        private static void AssembleCellsData(string inFilePath, string outPath, string templateFilename, string datasourceFilename, string datasourceName)
        {
            var dirPath = Path.GetDirectoryName(inFilePath) + "/";

            var dataXlsx = dirPath + datasourceFilename;

            // var dataDir = Path.GetDirectoryName(dataFolderName) + "/";
            // var dataXlsx = dataDir + datasourceFilename;

            var wb = new Workbook(dataXlsx);

            var ws = wb.Worksheets[0];

            var totalRows = ws.Cells.LastCell.Row + 1;
            var totalColumns = ws.Cells.LastCell.Column + 1;

            var dt = ws.Cells.ExportDataTable(0, 0, totalRows, totalColumns, true);
            dt.TableName = datasourceName;

            var templateXlsx = dirPath + templateFilename;

            // var tempDir = Path.GetDirectoryName(tempFolderName) + '/';
            // var templateXlsx = tempDir + templateFilename;

            var wbTemplate = new Workbook(templateXlsx);
            var wbd = new WorkbookDesigner(wbTemplate);

            wbd.SetDataSource(dt);

            wbd.Process();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            NLogger.LogInfo($"Assemble=>dataXlsx:{dataXlsx}||templateXlsx:{templateXlsx}=>Start");

            var task = Task.Run(() => { wbTemplate.Save(outPath); });
            var isCompleted = task.Wait(Api.Configuration.MillisecondsTimeout);

            if (!isCompleted)
            {
                NLogger.LogError($"Assemble=>dataXlsx:{dataXlsx}||templateXlsx:{templateXlsx}=>{AppSettings.ProcessingTimedout}");
                throw new TimeoutException(AppSettings.ProcessingTimedout);
            }

            stopWatch.Stop();
            NLogger.LogInfo($"Assemble=>dataXlsx:{dataXlsx}||templateXlsx:{templateXlsx}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}");
        }
    }
}