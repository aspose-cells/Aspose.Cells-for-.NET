using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Web.Http;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Models;
using Aspose.Cells.Rendering;
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
        protected async Task<Response> Process(string controllerName, string fileName, string folderName, string outFileExtension, bool createZip, bool checkPagesNumber, string productName, ProductFamilyNameKeysEnum productFamily, string methodName,
            ActionDelegate action,
            bool deleteSourceFolder = true, string zipFileName = null)
        {
            var logMsg = "ControllerName = " + controllerName + ", " + "MethodName = " + methodName + ", " + "Folder = " + folderName;
            var guid = Guid.NewGuid().ToString();
            var outFolder = "";
            var sourceFolder = AppSettings.WorkingDirectory + folderName;
            var logFileName = fileName;
            fileName = sourceFolder + "/" + fileName;

            switch (checkPagesNumber)
            {
                // Check if tiff file have more than one number of pages to create zip file or not
                //Check excel file have more than on workseets to create zip or not
                case true when createZip && controllerName == "AsposeImagingConversionController" && (Path.GetExtension(fileName).ToLower() == ".tiff" || Path.GetExtension(fileName).ToLower() == ".tif"):
                {
                    // Get the frame dimension list from the image of the file and 
                    var image = Image.FromFile(fileName);
                    // Get the globally unique identifier (GUID) 
                    var objGuid = image.FrameDimensionsList[0];
                    // Create the frame dimension 
                    var dimension = new FrameDimension(objGuid);
                    // Gets the total number of frames in the .tiff file 
                    var noOfPages = image.GetFrameCount(dimension);
                    createZip = noOfPages > 1;
                    image.Dispose();
                    break;
                }
                case true when createZip && controllerName == "AsposeCellsAPIsController" && outFileExtension == ".svg":
                {
                    var workbook = new Workbook(fileName);
                    if (workbook.Worksheets.Count <= 1)
                    {
                        var imgOptions = new ImageOrPrintOptions {OnePagePerSheet = true};
                        var sr = new SheetRender(workbook.Worksheets[0], imgOptions);
                        var srPageCount = sr.PageCount;
                        createZip = srPageCount > 1;
                    }

                    break;
                }
            }

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

                // Log information to NLogging database
                NLogger.LogInfo(logMsg, productName, productFamily, logFileName);
            }
            catch (Exception ex)
            {
                statusCodeValue = 500;
                statusValue = "500 " + ex.Message;
                // Log error message to NLogging database
                NLogger.LogError(ex, logMsg, productName, productFamily, logFileName);
            }

            return await Task.FromResult(new Response
            {
                FileName = outfileName,
                FolderName = outFolder,
                Status = statusValue,
                StatusCode = statusCodeValue,
            });
        }

        ///<Summary>
        /// Aspose Cells
        ///</Summary>
        protected string AsposeCells => "Aspose.Cells";

        ///<Summary>
        /// Aspose Conversion APP
        ///</Summary>
        protected string ConversionApp => " Conversion";

        ///<Summary>
        /// Aspose Metadata APP
        ///</Summary>
        protected string MetadataApp => " Metadata";

        ///<Summary>
        /// Aspose Viewer APP
        ///</Summary>
        protected string ViewerApp => " Viewer";

        ///<Summary>
        /// Aspose Watermark APP
        ///</Summary>
        protected string WatermarkApp => " Watermark";

        ///<Summary>
        /// Aspose Merger APP
        ///</Summary>
        protected string MergerApp => " Merger";

        ///<Summary>
        /// Aspose ParserApp APP
        ///</Summary>
        protected string ParserApp => " Parser";

        ///<Summary>
        /// Aspose Unlock APP
        ///</Summary>
        protected string UnlockApp => " Unlock";

        ///<Summary>
        /// Aspose Splitter APP
        ///</Summary>
        protected string SplitterApp => " Splitter";

        ///<Summary>
        /// Aspose Protect APP
        ///</Summary>
        protected string ProtectApp => " Protect";

        ///<Summary>
        /// Aspose Annotation APP
        ///</Summary>
        protected string AnnotationApp => " Annotation";

        ///<Summary>
        /// Aspose Redaction APP
        ///</Summary>
        protected string RedactionApp => " Redaction";

        ///<Summary>
        /// Aspose Editor APP
        ///</Summary>
        protected string EditorApp => " Editor";

        ///<Summary>
        /// Aspose Comparison APP
        ///</Summary>
        protected string ComparisonApp => " Comparison";

        ///<Summary>
        /// Aspose Assembly APP
        ///</Summary>
        protected string AssemblyApp => " Assembly";

        ///<Summary>
        /// Aspose Perform APP
        ///</Summary>
        protected string PerformOCRApp => " Perform";

        ///<Summary>
        /// Unzip Files
        ///</Summary>
        protected string UnzipFilesApp => " Unzip Files";

        ///<Summary>
        /// Zip Files
        ///</Summary>
        protected string ZipFilesApp => " Zip Files";

        ///<Summary>
        /// Search
        ///</Summary>
        protected string SearchApp => " Search";

        ///<Summary>
        /// Image App Property
        ///</Summary>
        protected string ImageApp => " Image";

        ///<Summary>
        /// Recognize App Property
        ///</Summary>
        protected string RecognizeApp => " Recognize";

        ///<Summary>
        ///  Generate App Property
        ///</Summary>
        protected string GenerateApp => " Generate";

        ///<Summary>
        /// Signature App Property
        ///</Summary>
        protected string SignatureApp => " Signature";

        ///<Summary>
        /// Optimize App Property
        ///</Summary>
        protected string OptimizeApp => "Optimize";

        protected string ChartApp => "Chart";
    }
}