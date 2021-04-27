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
    ///<Summary>
    /// AsposeCellsParserController class to parse excel file
    ///</Summary>
    public class AsposeCellsParserController : AsposeCellsBaseController
    {
        private const string App = "Parser";

        ///<Summary>
        /// Parse method to call parser controller based on product name
        ///</Summary>
        [HttpGet]
        [ActionName("Parse")]
        public async Task<Response> Parse()
        {
            var sessionId = Guid.NewGuid().ToString();
            const string action = "Parse";
            try
            {
                var taskUpload = Task.Run(() => UploadWorkbooks(sessionId));
                taskUpload.Wait(Api.Configuration.MillisecondsTimeout);
                if (!taskUpload.IsCompleted)
                {
                    NLogger.LogError($"Parse UploadWorkbooks=>{sessionId}=>{AppSettings.ProcessingTimedout}");
                    throw new TimeoutException(AppSettings.ProcessingTimedout);
                }

                var docs = taskUpload.Result;
                if (docs == null)
                    return PasswordProtectedResponse;
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = "Parser";
                Opts.MethodName = "Parse";
                Opts.ZipFileName = docs.Length > 1 ? "Parsed files" : Path.GetFileNameWithoutExtension(docs[0].FileName);
                Opts.OutputType = ".txt";
                Opts.CreateZip = true;

                /*var fileName = Path.GetFileName(docs[0].FileName);
                var folderName = docs[0].FolderName;
    
                return await Parse(fileName, folderName);*/

                return await Process((inFilePath, outPath, zipOutFolder) =>
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    NLogger.LogInfo($"Excel Parser=>{string.Join(",", docs.Select(t => t.FileName))}=>Start");

                    var tasks = docs.Select(doc => Task.Factory.StartNew(() => { ParseDocument(doc, zipOutFolder); })).ToArray();
                    var isCompleted = Task.WaitAll(tasks, Api.Configuration.MillisecondsTimeout);

                    if (!isCompleted)
                    {
                        NLogger.LogError($"Excel Parser=>{string.Join(",", docs.Select(t => t.FileName))}=>{AppSettings.ProcessingTimedout}");
                        throw new TimeoutException(AppSettings.ProcessingTimedout);
                    }

                    stopWatch.Stop();
                    NLogger.LogInfo($"Excel Parser=>{string.Join(",", docs.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}");
                });
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                NLogger.LogError(App, "Parse", exception.Message, sessionId);

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
        /// Parse Document
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="outPath"></param>
        private void ParseDocument(DocumentInfo doc, string outPath)
        {
            var (filename, folder) = PrepareFolder(doc, outPath);
            doc.Workbook.Save($"{folder}/{Path.GetFileNameWithoutExtension(filename)}.txt");
            ExtractImages(doc, folder);
        }

        /// <summary>
        /// Prepare output folder for using when multiple files are uploaded
        /// Creates folder by filename without extension
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="path">Zip folder name</param>
        /// <returns>Tuple(original filename, output folder)</returns>
        protected new static (string, string) PrepareFolder(DocumentInfo doc, string path)
        {
            var filename = Path.GetFileNameWithoutExtension(doc.FileName);
            var folder = path + "/";
            folder += filename;
            while (Directory.Exists(folder))
                folder += "_";
            folder += "/";
            Directory.CreateDirectory(folder);
            return (Path.GetFileName(doc.FileName), folder);
        }

        ///<Summary>
        /// Extract images
        ///</Summary>
        protected void ExtractImages(DocumentInfo doc, string outPath)
        {
            var wb = doc.Workbook;
            var sheetCount = wb.Worksheets.Count;

            var strSheetIndexFormat =
                sheetCount < 10 ? "0" : sheetCount < 100 ? "00" : sheetCount < 1000 ? "000" : "0000";

            for (var i = 0; i < sheetCount; i++)
            {
                wb.Worksheets.ActiveSheetIndex = i;

                var sheetName = wb.Worksheets[i].Name;
                wb.Save(outPath + "__" + (i + 1).ToString(strSheetIndexFormat) + "_" + sheetName + ".txt");
            }

            for (var i = 0; i < sheetCount; i++)
            {
                var ws = wb.Worksheets[i];
                var picsCount = ws.Pictures.Count;

                for (var j = 0; j < picsCount; j++)
                {
                    var pic = ws.Pictures[j];
                    var picData = pic.Data;
                    var fmt = pic.ImageType.ToString().ToLower();

                    var outFilePath = outPath + "__" + (i + 1).ToString(strSheetIndexFormat) + "_" + ws.Name + "__Pic" +
                                      j + "." + fmt;

                    using (var flout = new FileStream(outFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        flout.Write(picData, 0, picData.Length);
                    }
                }
            }
        }

        /// <summary>
        /// It will return true, if there is just one worksheet and it does not have any images.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public bool IsSingleSheetWithoutAnyImages(string fileName, string folderName)
        {
            fileName = AppSettings.WorkingDirectory + folderName + "/" + fileName;
            // fileName = folderName + "/" + fileName;

            var wb = new Workbook(fileName);

            if (wb.Worksheets.Count > 1)
                return false;

            var ws = wb.Worksheets[0];

            return ws.Pictures.Count <= 0;
        }

        ///<Summary>
        /// Parse method to parse excel file
        ///</Summary>
        public async Task<Response> Parse(string fileName, string folderName)
        {
            // License.SetAsposeCellsLicense();

            bool extractOnlyText;
            try
            {
                extractOnlyText = IsSingleSheetWithoutAnyImages(fileName, folderName);
            }
            catch (Exception e)
            {
                var message = $"{e.Message} | fileName = {fileName}";
                NLogger.LogError(App, "Parse", message, folderName);

                return await Task.FromResult(new Response
                {
                    StatusCode = 500,
                    Status = e.Message,
                    FileName = "",
                    FolderName = "",
                    Text = "Parse"
                });
            }

            if (extractOnlyText) // extracting only text
                return await Process(fileName, folderName, ".txt", false,
                    (inFilePath, outPath, zipOutFolder) =>
                    {
                        var wb = new Workbook(inFilePath);
                        wb.Save(outPath);
                    });

            // extracting text and images
            return await Process(fileName, folderName, "", true,
                (inFilePath, outPath, zipOutFolder) =>
                {
                    var wb = new Workbook(inFilePath);

                    var sheetCount = wb.Worksheets.Count;

                    var strSheetIndexFormat =
                        sheetCount < 10 ? "0" : sheetCount < 100 ? "00" : sheetCount < 1000 ? "000" : "0000";

                    for (var i = 0; i < sheetCount; i++)
                    {
                        wb.Worksheets.ActiveSheetIndex = i;

                        var sheetName = wb.Worksheets[i].Name;
                        wb.Save(outPath + "__" + (i + 1).ToString(strSheetIndexFormat) + "_" + sheetName + ".txt");
                    }

                    for (var i = 0; i < sheetCount; i++)
                    {
                        var ws = wb.Worksheets[i];
                        var picsCount = ws.Pictures.Count;

                        for (var j = 0; j < picsCount; j++)
                        {
                            var pic = ws.Pictures[j];
                            var picData = pic.Data;
                            var fmt = pic.ImageType.ToString().ToLower();

                            var outFilePath = outPath + "__" + (i + 1).ToString(strSheetIndexFormat) + "_" + ws.Name + "__Pic" +
                                              j + "." + fmt;

                            using (var flout = new FileStream(outFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                flout.Write(picData, 0, picData.Length);
                            }
                        }
                    }
                });
        }
    }
}