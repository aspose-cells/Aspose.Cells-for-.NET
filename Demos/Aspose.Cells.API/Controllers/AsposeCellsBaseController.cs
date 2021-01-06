using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Helpers;
using Aspose.Cells.API.Models;
using Aspose.Cells.API.Services;
using Aspose.Cells.Drawing;
using Aspose.Cells.Rendering;
using Aspose.Pdf;
using Tools.Foundation.Models;
using Image = System.Drawing.Image;

namespace Aspose.Cells.API.Controllers
{
    ///<Summary>
    /// Aspose Cells Base Class
    ///</Summary>
    public class AsposeCellsBaseController : ApiControllerBase
    {
        /// <summary>
        /// Maximum number of files which can be uploaded for MVC Aspose.Words apps
        /// </summary>
        protected const int MaximumUploadFiles = 10;

        /// <summary>
        /// Original file format SaveAs option for multiple files uploading. By default, "-"
        /// </summary>
        private const string SaveAsOriginalName = ".-";

        /// <summary>
        /// Response when uploaded files exceed the limits
        /// </summary>
        protected readonly Response MaximumFileLimitsResponse = new Response
        {
            Status = $"Number of files should be less {MaximumUploadFiles}",
            StatusCode = 500
        };

        /// <summary>
        /// Response when uploaded files exceed the limits
        /// </summary>
        protected readonly Response PasswordProtectedResponse = new Response
        {
            Status = "Some of your documents are password protected",
            StatusCode = 500
        };

        ///<Summary>
        /// Aspose Cells Options Class
        ///</Summary>
        protected class Options
        {
            ///<Summary>
            /// AppName
            ///</Summary>
            public string AppName;

            ///<Summary>
            /// FolderName
            ///</Summary>
            public string FolderName;

            ///<Summary>
            /// FileName
            ///</Summary>
            public string FileName;

            private string _outputType;

            /// <summary>
            /// By default, it is the extension of FileName
            /// </summary>
            public string OutputType
            {
                get => _outputType;
                set
                {
                    if (!value.StartsWith("."))
                        value = "." + value;
                    _outputType = value;
                }
            }

            /// <summary>
            /// Check if OuputType is a picture extension
            /// </summary>
            public bool IsPicture
            {
                get
                {
                    switch (_outputType.ToLower())
                    {
                        case ".bmp":
                        case ".png":
                        case ".jpg":
                        case ".jpeg":
                        case ".emf":
                        case ".wmf":
                        case ".tiff":
                            return true;
                        default:
                            return false;
                    }
                }
            }

            ///<Summary>
            /// ResultFileName
            ///</Summary>
            public string ResultFileName;

            ///<Summary>
            /// MethodName
            ///</Summary>
            public string MethodName;

            ///<Summary>
            /// ControllerName
            ///</Summary>
            public string ControllerName;

            ///<Summary>
            /// CreateZip
            ///</Summary>
            public bool CreateZip;

            ///<Summary>
            /// CheckNumberOfPages
            ///</Summary>
            public bool CheckNumberOfPages = false;

            ///<Summary>
            /// DeleteSourceFolder
            ///</Summary>
            public bool DeleteSourceFolder = false;

            ///<Summary>
            /// CalculateZipFileName
            ///</Summary>
            public bool CalculateZipFileName = true;

            /// <summary>
            /// Output zip filename (without '.zip'), if CreateZip property is true
            /// By default, FileName + AppName
            /// </summary>
            public string ZipFileName;

            /// <summary>
            /// AppSettings.WorkingDirectory + FolderName + "/" + FileName
            /// </summary>
            public string WorkingFileName
            {
                get
                {
                    if (File.Exists(AppSettings.WorkingDirectory + FolderName + "/" + FileName))
                        return AppSettings.WorkingDirectory + FolderName + "/" + FileName;
                    return AppSettings.OutputDirectory + FolderName + "/" + FileName;
                }
            }
        }

        /// <summary>
        /// initialize Options
        /// </summary>
        protected Options Opts = new Options();

        /// <summary>
        /// UTF8WithoutBom
        /// </summary>
        protected static readonly Encoding UTF8WithoutBom = new UTF8Encoding(false);

        /// <summary>
        /// ProductFamily
        /// </summary>
        public ProductFamilyNameKeysEnum ProductFamily => ProductFamilyNameKeysEnum.cells;

        /// <summary>
        /// Prepare upload files and return as documents
        /// </summary>
        /// <exception cref="AppException"></exception>
        protected async Task<DocumentInfo[]> UploadWorkBooks(string sessionId)
        {
            try
            {
                var folderName = sessionId;
                var pathProcessor = new PathProcessor(folderName);
                var uploadProvider = new MultipartFormDataStreamProviderSafe(pathProcessor.SourceFolder);
                await Request.Content.ReadAsMultipartAsync(uploadProvider);
                return uploadProvider.FileData.Select(x =>
                {
                    var workbook = IsImage(x.LocalFileName) ? new Workbook() : new Workbook(x.LocalFileName);

                    return new DocumentInfo
                    {
                        FolderName = folderName,
                        FileName = x.LocalFileName,
                        Workbook = workbook
                    };
                }).ToArray();
            }
            catch (Exception)
            {
                throw new AppException("Invalid file, please ensure that uploading correct file");
            }
        }

        /// <summary>
        /// Set default parameters into Opts
        /// </summary>
        /// <param name="docs"></param>
        protected void SetDefaultOptions(DocumentInfo[] docs)
        {
            if (docs.Length <= 0) return;
            SetDefaultOptions(Path.GetFileName(docs[0].FileName));
            Opts.CreateZip = docs.Length > 1 || Opts.IsPicture;
        }

        /// <summary>
        /// Set default parameters into Opts
        /// </summary>
        /// <param name="filename"></param>
        private void SetDefaultOptions(string filename)
        {
            Opts.ResultFileName = filename;
            Opts.FileName = Path.GetFileName(filename);

            var query = Request.GetQueryNameValuePairs()
                .ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);
            string outputType = null;
            if (query.ContainsKey("outputType"))
                outputType = query["outputType"];
            Opts.OutputType = !string.IsNullOrEmpty(outputType)
                ? outputType
                : Path.GetExtension(Opts.FileName);
            Opts.OutputType = Opts.OutputType.ToLower();

            Opts.ResultFileName = Opts.OutputType == SaveAsOriginalName
                ? Opts.FileName
                : Path.GetFileNameWithoutExtension(Opts.FileName) + Opts.OutputType;
        }

        /// <summary>
        /// GetSaveOptions
        /// </summary>
        /// <param name="outputType"></param>
        /// <returns></returns>
        protected SaveFormatType GetSaveOptions(string outputType)
        {
            var saveFormat = new SaveFormatType {SaveOptions = null};
            switch (outputType)
            {
                case "ods":
                {
                    saveFormat.SaveOptions = new OdsSaveOptions();
                    saveFormat.SaveType = SaveType.ods;
                    break;
                }
                case "pdf":
                {
                    saveFormat.SaveOptions = new PdfSaveOptions();
                    saveFormat.SaveType = SaveType.pdf;
                    break;
                }
                case "docx":
                {
                    saveFormat.SaveType = SaveType.docx;
                    saveFormat.PdfSaveFileFormat = Pdf.SaveFormat.DocX;
                    break;
                }
                case "pptx":
                {
                    saveFormat.SaveType = SaveType.pptx;
                    saveFormat.PdfSaveFileFormat = Pdf.SaveFormat.Pptx;
                    break;
                }
                case "xps":
                {
                    saveFormat.SaveOptions = new XpsSaveOptions();
                    saveFormat.SaveType = SaveType.xps;
                    break;
                }
                case "xlsx":
                {
                    saveFormat.SaveType = SaveType.xlsx;
                    break;
                }
                case "xls":
                {
                    saveFormat.SaveType = SaveType.xls;
                    break;
                }
                case "xlsm":
                {
                    saveFormat.SaveType = SaveType.xlsm;
                    break;
                }
                case "xlsb":
                {
                    saveFormat.SaveType = SaveType.xlsb;
                    break;
                }
                case "xlam":
                {
                    saveFormat.SaveType = SaveType.xlam;
                    break;
                }
                case "csv":
                {
                    saveFormat.SaveOptions = new TxtSaveOptions(SaveFormat.CSV) {Encoding = Encoding.GetEncoding("UTF-8")};
                    saveFormat.SaveType = SaveType.csv;
                    break;
                }
                case "html":
                {
                    saveFormat.SaveOptions = new HtmlSaveOptions
                    {
                        // ExportFontsAsBase64 = true,
                        ExportImagesAsBase64 = true,
                        // CssStyleSheetType = CssStyleSheetType.Inline,
                        Encoding = UTF8WithoutBom,
                        // HtmlVersion = HtmlVersion.Html5
                    };
                    saveFormat.SaveType = SaveType.html;
                    break;
                }
                case "mhtml":
                {
                    saveFormat.SaveOptions = new HtmlSaveOptions(SaveFormat.MHtml)
                    {
                        // ExportFontsAsBase64 = true,
                        ExportImagesAsBase64 = true,
                        // CssStyleSheetType = CssStyleSheetType.Inline,
                        Encoding = UTF8WithoutBom,
                        // HtmlVersion = HtmlVersion.Html5
                    };
                    saveFormat.SaveType = SaveType.mhtml;
                    break;
                }
                case "svg":
                {
                    saveFormat.ImageOrPrintOptions = new ImageOrPrintOptions {SaveFormat = SaveFormat.SVG};
                    saveFormat.SaveType = SaveType.svg;
                    break;
                }
                case "bmp":
                {
                    saveFormat.ImageOrPrintOptions = new ImageOrPrintOptions {ImageType = ImageType.Bmp};
                    saveFormat.SaveType = SaveType.bmp;
                    break;
                }
                case "png":
                {
                    saveFormat.ImageOrPrintOptions = new ImageOrPrintOptions {ImageType = ImageType.Png};
                    saveFormat.SaveType = SaveType.png;
                    break;
                }
                case "tiff":
                {
                    saveFormat.ImageOrPrintOptions = new ImageOrPrintOptions {ImageType = ImageType.Tiff};
                    saveFormat.SaveType = SaveType.tiff;
                    break;
                }
                case "jpg":
                {
                    saveFormat.ImageOrPrintOptions = new ImageOrPrintOptions {ImageType = ImageType.Jpeg};
                    saveFormat.SaveType = SaveType.jpg;
                    break;
                }
                case "emf":
                {
                    saveFormat.ImageOrPrintOptions = new ImageOrPrintOptions {ImageType = ImageType.Emf};
                    saveFormat.SaveType = SaveType.emf;
                    break;
                }
                case "wmf":
                {
                    saveFormat.ImageOrPrintOptions = new ImageOrPrintOptions {ImageType = ImageType.Wmf};
                    saveFormat.SaveType = SaveType.wmf;
                    break;
                }
                case "tabdelimited":
                {
                    saveFormat.SaveType = SaveType.tabdelimited;
                    break;
                }
                case "tsv":
                {
                    saveFormat.SaveOptions = new TxtSaveOptions(SaveFormat.TSV) {Encoding = Encoding.GetEncoding("UTF-8")};
                    saveFormat.SaveType = SaveType.tsv;
                    break;
                }
                case "md":
                {
                    saveFormat.SaveOptions = new MarkdownSaveOptions();
                    saveFormat.SaveType = SaveType.md;
                    break;
                }
                default:
                    saveFormat.SaveType = null;
                    break;
            }

            return saveFormat;
        }

        /// <summary>
        /// GetSaveFormatType by filename
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        protected SaveFormatType GetSaveFormatType(string filename)
        {
            var outputType = Path.GetExtension(filename);
            if (string.IsNullOrEmpty(outputType)) return GetSaveOptions(outputType);
            if (outputType[0] == '.')
            {
                outputType = outputType.Substring(1);
            }

            outputType = outputType.ToLower();

            return GetSaveOptions(outputType);
        }

        /// <summary>
        /// Prepare upload files and return DocumentInfo[]
        /// </summary>
        protected async Task<DocumentInfo[]> UploadFiles(string sessionId, string password)
        {
            try
            {
                var folderName = sessionId;
                var pathProcessor = new PathProcessor(folderName);
                var uploadProvider = new MultipartFormDataStreamProviderSafe(pathProcessor.SourceFolder);
                await Request.Content.ReadAsMultipartAsync(uploadProvider);
                return uploadProvider.FileData.Select(x => new DocumentInfo
                {
                    FolderName = folderName,
                    FileName = x.LocalFileName,
                    Workbook = new Workbook(x.LocalFileName, new LoadOptions {Password = password})
                }).ToArray();
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw new AppException("Invalid file, please ensure that uploading correct file");
            }
        }

        /// <summary>
        /// Process
        /// </summary>
        protected Task<Response> Process(ActionDelegate action)
        {
            if (string.IsNullOrEmpty(Opts.OutputType))
                Opts.OutputType = Path.GetExtension(Opts.FileName);
            if (Opts.OutputType == ".svg" || Opts.IsPicture)
                Opts.CreateZip = true;
            if (string.IsNullOrEmpty(Opts.ZipFileName) && Opts.CalculateZipFileName)
                Opts.ZipFileName = Path.GetFileNameWithoutExtension(Opts.FileName) + Opts.AppName;


            return Process(
                GetType().Name,
                Opts.ResultFileName,
                Opts.FolderName,
                Opts.OutputType,
                Opts.CreateZip,
                Opts.CheckNumberOfPages,
                AsposeCells + Opts.AppName,
                ProductFamilyNameKeysEnum.cells,
                Opts.MethodName,
                action,
                Opts.DeleteSourceFolder,
                Opts.ZipFileName
            );
        }

        /// <summary>
        /// Check if the OutputType is a picture and saves the document
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="outPath"></param>
        /// <param name="zipOutFolder"></param>
        /// <param name="saveOptions"></param>
        protected void SaveDocument(DocumentInfo doc, string outPath, string zipOutFolder, SaveFormatType saveOptions)
        {
            string filename;
            if (Opts.CreateZip)
                filename = zipOutFolder + "/" +
                           (Opts.OutputType == SaveAsOriginalName
                               ? Path.GetFileName(doc.FileName)
                               : Path.GetFileNameWithoutExtension(doc.FileName) + Opts.OutputType);
            else
                filename = outPath;

            if (IsImage(doc.FileName))
            {
                doc.Workbook.Worksheets[0].Pictures.Add(0, 0, doc.FileName);
            }

            SaveDocument(doc, filename, saveOptions);
        }

        /// <summary>
        /// Check if the OutputType is a picture and saves the document
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="filename">The output full FileName</param>
        /// <param name="saveOptions"></param>
        protected void SaveDocument(DocumentInfo doc, string filename, SaveFormatType saveOptions)
        {
            var zipOutFolder = $"{Path.GetDirectoryName(filename)}\\{Path.GetFileNameWithoutExtension(filename)}";

            if (Opts.CreateZip)
                Directory.CreateDirectory(zipOutFolder);

            var worksheetCount = doc.Workbook.Worksheets.Count;
            var outPath = zipOutFolder;
            switch (saveOptions.SaveType)
            {
                case SaveType.xls:
                case SaveType.ods:
                case SaveType.pdf:
                case SaveType.xps:
                case SaveType.xlsx:
                case SaveType.xlsm:
                case SaveType.xlsb:
                case SaveType.xlam:
                case SaveType.tabdelimited:
                case SaveType.md:
                    outPath += Opts.OutputType;
                    doc.Workbook.Save(outPath);
                    break;
                case SaveType.csv:
                case SaveType.tsv:
                    outPath += Opts.OutputType;
                    doc.Workbook.Save(outPath, saveOptions.SaveOptions);
                    break;
                case SaveType.tiff:
                case SaveType.png:
                case SaveType.jpg:
                case SaveType.bmp:
                case SaveType.emf:
                case SaveType.wmf:
                case SaveType.svg:
                    SaveImage(doc, zipOutFolder, filename, saveOptions.ImageOrPrintOptions, worksheetCount);
                    break;
                case SaveType.html:
                    if (worksheetCount > 1)
                    {
                        Opts.CreateZip = true;
                    }

                    doc.Workbook.Save(filename, saveOptions.SaveOptions);
                    break;
                case SaveType.mhtml:
                    doc.Workbook.Save(filename, saveOptions.SaveOptions);
                    break;
                case SaveType.docx:
                case SaveType.pptx:
                    outPath += Opts.OutputType;
                    doc.Workbook.CalculateFormula();
                    using (var stream = new MemoryStream())
                    {
                        doc.Workbook.Save(stream, SaveFormat.Pdf);
                        stream.Position = 0;
                        var pdf = new Document(stream);
                        pdf.Save(outPath, saveOptions.PdfSaveFileFormat);
                    }

                    break;
                case null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// LogError method to log errors
        /// </summary>
        protected void LogError(Exception ex)
        {
            var logMsg = "ControllerName = " + Opts.ControllerName + ", " + "MethodName = " + Opts.MethodName + ", " +
                         "Folder = " + Opts.FolderName;
            NLogger.LogError(ex, logMsg, AsposeCells + Opts.AppName, ProductFamily, Opts.FileName);
        }

        /// <summary>
        /// SaveFormatType
        /// </summary>
        public class SaveFormatType
        {
            /// <summary>
            /// SaveOptions
            /// </summary>
            public SaveOptions SaveOptions { get; set; }

            /// <summary>
            /// SaveType
            /// </summary>
            public SaveType? SaveType { get; set; }

            public ImageOrPrintOptions ImageOrPrintOptions { get; set; }

            public Pdf.SaveFormat PdfSaveFileFormat { get; set; }
        }

        /// <summary>
        /// SaveType
        /// </summary>
        public enum SaveType
        {
            ods,
            pdf,
            docx,
            pptx,
            xps,
            html,
            jpg,
            png,
            bmp,
            tiff,
            svg,
            xls,
            xlsx,
            xlsm,
            xlsb,
            xlam,
            csv,
            tabdelimited,
            tsv,
            emf,
            wmf,
            mhtml,
            md
        }

        /// <summary>
        /// DocumentInfo
        /// </summary>
        public class DocumentInfo
        {
            /// <summary>
            /// FolderName
            /// </summary>
            public string FolderName { get; set; }

            /// <summary>
            /// FileName
            /// </summary>
            public string FileName { get; set; }

            /// <summary>
            /// Workbook
            /// </summary>
            public Workbook Workbook { get; set; }
        }

        /// <summary>
        /// Prepare output folder for using when multiple files are uploaded
        /// Creates folder by filename without extension
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="path">Zip folder name</param>
        /// <returns>Tuple(original filename, output folder)</returns>
        protected static (string, string) PrepareFolder(DocumentInfo doc, string path)
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

        public bool IsImage(string path)
        {
            try
            {
                Image.FromFile(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SaveImage(DocumentInfo doc, string zipOutFolder, string filename, ImageOrPrintOptions imgOptions, int sheetCount)
        {
            foreach (var sheet in doc.Workbook.Worksheets)
            {
                var sr = new SheetRender(sheet, imgOptions);
                var srPageCount = sr.PageCount;
                for (var i = 0; i < sr.PageCount; i++)
                {
                    string outfileName;
                    string outPath;
                    if (sheetCount > 1 || srPageCount > 1)
                    {
                        outfileName = sheet.Name + "_" + (i + 1) + Opts.OutputType;
                        outPath = zipOutFolder + "/" + outfileName;
                        // Opts.CreateZip = true;
                    }
                    else
                    {
                        outfileName = Path.GetFileNameWithoutExtension(filename) + Opts.OutputType;
                        outPath = zipOutFolder + "/" + outfileName;
                    }

                    sr.ToImage(i, outPath);
                }
            }
        }

        protected static Response InternalServerErrorResponse(string folderName, string text)
        {
            return new Response
            {
                Status = "Internal server error",
                StatusCode = 500,
                FolderName = folderName,
                Text = text,
            };
        }

        protected static Response AppErrorResponse(string msg, string folderName, string text)
        {
            return new Response
            {
                Status = msg,
                StatusCode = 500,
                FolderName = folderName,
                Text = text,
            };
        }
    }
}