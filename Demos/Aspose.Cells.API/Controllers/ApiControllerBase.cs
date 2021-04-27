using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Web.Http;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Models;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    ///<Summary>
    /// ApiControllerBase class to have base methods
    ///</Summary>
    // [EnableCors("*", "*", "*")]
    public abstract class ApiControllerBase : ApiController
    {
        ///<Summary>
        /// ActionDelegate
        ///</Summary>
        protected delegate void ActionDelegate(string inFilePath, string outPath, string zipOutFolder);

        ///<Summary>
        /// Process
        ///</Summary>
        //[Obsolete("Similar functionality can be released through the CustomSingleOrZipFileProcessor class.", false)]
        protected async Task<Response> Process(string fileName, string folderName, string outFileExtension, bool createZip,
            ActionDelegate action,
            bool deleteSourceFolder = true, string zipFileName = null)
        {
            var guid = Guid.NewGuid().ToString();
            var outFolder = "";
            var sourceFolder = AppSettings.WorkingDirectory + folderName;
            fileName = sourceFolder + "/" + fileName;

            var outfileName = Path.GetFileNameWithoutExtension(fileName) + outFileExtension;
            string outPath;

            var zipOutFolder = AppSettings.OutputDirectory + guid;
            string zipOutfileName, zipOutPath;
            if (string.IsNullOrEmpty(zipFileName))
            {
                zipOutfileName = guid + ".zip";
                zipOutPath = AppSettings.OutputDirectory + zipOutfileName;
            }
            else
            {
                var guid2 = Guid.NewGuid().ToString();
                outFolder = guid2;
                zipOutfileName = zipFileName + ".zip";
                zipOutPath = AppSettings.OutputDirectory + guid2;
                Directory.CreateDirectory(zipOutPath);
                zipOutPath += "/" + zipOutfileName;
            }

            if (createZip)
            {
                outfileName = Path.GetFileNameWithoutExtension(fileName) + outFileExtension;
                outPath = zipOutFolder + "/" + outfileName;
                Directory.CreateDirectory(zipOutFolder);
            }
            else
            {
                outFolder = guid;
                outPath = AppSettings.OutputDirectory + outFolder;
                Directory.CreateDirectory(outPath);

                outPath += "/" + outfileName;
            }

            var statusValue = "OK";
            var statusCodeValue = 200;

            try
            {
                action(fileName, outPath, zipOutFolder);

                if (createZip)
                {
                    ZipFile.CreateFromDirectory(zipOutFolder, zipOutPath);
                    Directory.Delete(zipOutFolder, true);
                    outfileName = zipOutfileName;
                }

                if (deleteSourceFolder)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Directory.Delete(sourceFolder, true);
                }
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;

                statusCodeValue = 500;
                statusValue = exception.Message;

                if (!(e is TimeoutException))
                {
                    NLogger.LogError("Api", "Process", exception.Message, outFolder);
                }
            }

            return await Task.FromResult(new Response
            {
                FileName = outfileName,
                FolderName = outFolder,
                Status = statusValue,
                StatusCode = statusCodeValue,
            });
        }
    }
}