using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Cells.API.Models;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    public class AsposeCellsSplitterController : AsposeCellsBaseController
    {
        ///<Summary>
        /// Split method
        ///</Summary>
        [MimeMultipart]
        [HttpPost]
        [ActionName("Split")]
        public async Task<Response> Split(string outputType)
        {
            var sessionId = Guid.NewGuid().ToString();
            var action = $"Split to {outputType.Trim().ToLower()}";

            try
            {
                var docs = await UploadWorkBooks(sessionId);
                if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
                    return MaximumFileLimitsResponse;

                SetDefaultOptions(docs);
                Opts.AppName = SplitterApp;
                Opts.MethodName = "Split";
                Opts.CreateZip = true;
                Opts.ZipFileName = "Splitted files";
                Opts.OutputType = outputType.Trim().ToLower();

                var saveOpt = GetSaveOptions(outputType.Trim().ToLower());
                return await Process((inFilePath, outPath, zipOutFolder) =>
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    NLogger.LogInfo($"Split to {outputType.Trim().ToLower()}=>{string.Join(",", docs.Select(t => t.FileName))}=>Start", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);

                    var tasks = docs.Select(doc => Task.Factory.StartNew(() =>
                    {
                        var workbook = doc.Workbook;
                        var worksheetCollection = workbook.Worksheets;
                        var i = worksheetCollection.Count;

                        for (var j = 0; j < i; j++)
                        {
                            try
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
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                        }
                    })).ToArray();
                    Task.WaitAll(tasks);

                    stopWatch.Stop();
                    NLogger.LogInfo($"Split to {outputType.Trim().ToLower()}=>{string.Join(",", docs.Select(t => t.FileName))}=>cost seconds:{stopWatch.Elapsed.TotalSeconds}", AsposeCells, ProductFamilyNameKeysEnum.cells, outPath);
                });
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