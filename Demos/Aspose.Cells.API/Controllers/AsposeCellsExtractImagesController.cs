using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Models;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    ///<Summary>
    /// AsposeCellsExtractImagesController class to extract images from excel
    ///</Summary>
    public class AsposeCellsExtractImagesController : ApiControllerBase
    {
        private const string App = "ExtractImages";

        /// <summary>
        /// Check the workbook for the presence of images
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public bool HasImages(string fileName, string folderName)
        {
            fileName = AppSettings.WorkingDirectory + folderName + "/" + fileName;

            var wb = new Workbook(fileName);

            var cnt = wb.Worksheets.Count;

            for (var i = 0; i < cnt; i++)
            {
                var ws = wb.Worksheets[i];

                if (ws.Pictures.Count > 0)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Extract the images inside the workbook.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public async Task<Response> ExtractImages(string fileName, string folderName)
        {
            // license.SetAsposeCellsLicense();
            string statusValue;
            int statusCodeValue;
            var fileProcessingErrorCode = FileProcessingErrorCode.OK;

            try
            {
                if (HasImages(fileName, folderName))
                    return await Process(fileName, folderName, "", true,
                        (inFilePath, outPath, zipOutFolder) =>
                        {
                            var index = outPath.LastIndexOf("/", StringComparison.Ordinal);
                            if (index > 0)
                                outPath = outPath.Substring(0, index + 1);

                            var wb = new Workbook(inFilePath);
                            var sheetCount = wb.Worksheets.Count;

                            for (var i = 0; i < sheetCount; i++)
                            {
                                var ws = wb.Worksheets[i];
                                var picsCount = ws.Pictures.Count;

                                for (var j = 0; j < picsCount; j++)
                                {
                                    var pic = ws.Pictures[j];
                                    var picData = pic.Data;
                                    var fmt = pic.ImageType.ToString().ToLower();

                                    var outFilePath = outPath + i + "--" + ws.Name + "--Pic" + j + "." + fmt;
                                    var fileStream = new FileStream(outFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                                    fileStream.Write(picData, 0, picData.Length);
                                    fileStream.Close();
                                }
                            }
                        });

                statusCodeValue = 200;
                statusValue = "OK";
                fileProcessingErrorCode = FileProcessingErrorCode.NoImagesFound;
            }
            catch (Exception e)
            {
                var message = $"{e.Message} | fileName = {fileName}";
                NLogger.LogError(App, "ExtractImages", message, folderName);

                statusCodeValue = 500;
                statusValue = "500 " + e.Message;
            }

            return await Task.FromResult(new Response
            {
                FileName = fileName,
                FolderName = folderName,
                Status = statusValue,
                StatusCode = statusCodeValue,
                FileProcessingErrorCode = fileProcessingErrorCode
            });
        }
    }
}