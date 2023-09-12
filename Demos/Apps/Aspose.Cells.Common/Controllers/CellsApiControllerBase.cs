using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Models;
using Aspose.Cells.Common.Services;
using Aspose.Cells.Drawing;
using Aspose.Cells.GridJs;
using Aspose.Cells.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using DocumentInfo = Aspose.Cells.Common.Models.DocumentInfo;
using Image = System.Drawing.Image;

namespace Aspose.Cells.Common.Controllers
{
    public class CellsApiControllerBase : Controller, ICellsController
    {
        protected readonly IStorageService Storage;

        private IConfiguration _configuration;

        private readonly object _readSync = new object();

        protected readonly ILogger Logger;

        private const string ZipFolderName = "output";

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
            StatusCode = 403
        };

        /// <summary>
        /// Response when uploaded files exceed the limits
        /// </summary>
        protected readonly Response PasswordProtectedResponse = new Response
        {
            Status = "Some of your documents are password protected",
            StatusCode = 403
        };

        /// <summary>
        /// initialize Options
        /// </summary>
        protected readonly Options Opts = new Options();

        /// <summary>
        /// UTF8WithoutBom
        /// </summary>
        private static readonly Encoding fileUtf8WithoutBom = new UTF8Encoding(false);

        /// <summary>
        /// initialize AsposeCellsBaseController
        /// </summary>
        public CellsApiControllerBase(IStorageService storage, IConfiguration configuration, ILogger logger)
        {
            Storage = storage;
            _configuration = configuration;
            Logger = logger;
        }

        /// <summary>
        /// Prepare upload files and return as documents
        /// </summary>
        protected async Task<DocumentInfo[]> UploadWorkbooks(string sessionId, string appName)
        {
            var duration = Stopwatch.StartNew();
            var sourceKeyLs = new List<string>();
            try
            {
                IEnumerable<IFormFile> uploadProvider = HttpContext.Request.Form.Files;
                uploadProvider = uploadProvider.Union(await UploadLinks());
                var formFiles = uploadProvider.ToList();
                Logger.FileUploading(formFiles.Select(x => x.FileName).ToArray(), "", false);

                var res = new List<DocumentInfo>();

                foreach (var formFile in formFiles)
                {
                    await using var memoryStream = new MemoryStream();
                    await formFile.CopyToAsync(memoryStream);
                    await using (var stream = new MemoryStream())
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        await memoryStream.CopyToAsync(stream);

                        // upload source files to AWS S3
                        var objectPath = $"{Configuration.SourceFolder}/{sessionId}/{formFile.FileName}";
                        sourceKeyLs.Add(objectPath);
                        await Storage.Upload(objectPath, stream, new AwsMetaInfo
                        {
                            OriginalFileName = formFile.FileName,
                            Title = formFile.FileName
                        });
                    }

                    memoryStream.Seek(0, SeekOrigin.Begin);
                    lock (_readSync)
                    {
                        var interruptMonitor = new InterruptMonitor();
                        var thread = new Thread(InterruptMonitor);
                        try
                        {
                            thread.Start(new object[] {interruptMonitor, Configuration.MillisecondsTimeout, formFile.FileName});
                            Workbook workbook;
                            if (IsImage(memoryStream))
                            {
                                workbook = new Workbook();
                                workbook.Worksheets[0].Pictures.Add(0, 0, memoryStream);
                            }
                            else
                            {
                                var loadOptions = GetLoadOptionsByExtension(Path.GetExtension(formFile.FileName), interruptMonitor);
                                workbook = new Workbook(memoryStream, loadOptions);
                            }

                            res.Add(new DocumentInfo
                            {
                                FolderName = sessionId,
                                FileName = formFile.FileName,
                                Workbook = workbook
                            });
                        }
                        finally
                        {
                            thread.Interrupt();
                        }
                    }
                }

                Logger.FileUploaded(res.Select(x => x.FileName).ToArray(), "", duration.Elapsed);
                return res.ToArray();
            }
            catch (CellsException e)
            {
                if (e.Code != ExceptionType.IncorrectPassword)
                {
                    foreach (var sourceKey in sourceKeyLs)
                    {
                        var destinationKey = sourceKey.Replace(Configuration.SourceFolder, $"{Configuration.ErrorFolder}/{appName}");
                        await Storage.CopyingObjectAsync(sourceKey, destinationKey);
                    }

                    if (e.Code == ExceptionType.Interrupted)
                    {
                        Logger.LogError("UploadWorkbooks {SessionId}=>{ProcessingTimeout}", sessionId, Configuration.ProcessingTimeout);
                        throw new TimeoutException(Configuration.ProcessingTimeout);
                    }
                }

                Logger.FileUploadingError(HttpContext.Request?.Form?.Files?.Select(x => x.FileName).ToArray(), duration.Elapsed, e);
                if (string.IsNullOrEmpty(e.Message))
                    throw new Exception("Invalid file, please ensure that uploading correct file");
                throw;
            }
            catch (Exception e)
            {
                foreach (var sourceKey in sourceKeyLs)
                {
                    var destinationKey = sourceKey.Replace(Configuration.SourceFolder, $"{Configuration.ErrorFolder}/{appName}");
                    await Storage.CopyingObjectAsync(sourceKey, destinationKey);
                }

                Logger.FileUploadingError(HttpContext.Request?.Form?.Files?.Select(x => x.FileName).ToArray(), duration.Elapsed, e);
                if (string.IsNullOrEmpty(e.Message))
                    throw new Exception("Invalid file, please ensure that uploading correct file");
                throw;
            }
        }

        /// <summary>
        /// Set default parameters into Opts
        /// </summary>
        /// <param name="docs"></param>
        protected void SetDefaultOptions(DocumentInfo[] docs)
        {
            // all files move to AWS
            Opts.DeleteSourceFolder = true;

            if (docs.Length <= 0) return;

            SetDefaultOptions(Path.GetFileName(docs[0].FileName));
            // Opts.CreateZip = docs.Length > 1 || Opts.IsPicture;
        }

        /// <summary>
        /// Set default parameters into Opts
        /// </summary>
        /// <param name="filename"></param>
        private void SetDefaultOptions(string filename)
        {
            Opts.FileName = Path.GetFileName(filename);
            var query = Request.Query.ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);
            string outputType = null;
            if (query.ContainsKey("outputType")) outputType = query["outputType"];
            Opts.OutputType = !string.IsNullOrEmpty(outputType) ? outputType : Path.GetExtension(Opts.FileName);
            Opts.OutputType = Opts.OutputType?.ToLower() == SaveAsOriginalName ? Path.GetExtension(Opts.FileName)?.ToLower() : Opts.OutputType?.ToLower();
            Opts.ResultFileName = Path.GetFileNameWithoutExtension(Opts.FileName) + Opts.OutputType;
        }

        protected static LoadOptions GetLoadOptionsByExtension(string extension, InterruptMonitor interruptMonitor)
        {
            var loadOptions = extension.ToLower() switch
            {
                ".ods" => new OdsLoadOptions(LoadFormat.Ods),
                ".csv" => new TxtLoadOptions(LoadFormat.Csv),
                ".html" => new HtmlLoadOptions(LoadFormat.Html),
                ".mhtml" => new HtmlLoadOptions(LoadFormat.MHtml),
                ".tabdelimited" => new TxtLoadOptions(LoadFormat.TabDelimited),
                ".tsv" => new TxtLoadOptions(LoadFormat.Tsv),
                _ => new LoadOptions()
            };

            loadOptions.CheckExcelRestriction = false;
            loadOptions.InterruptMonitor = interruptMonitor;
            return loadOptions;
        }

        protected static LoadOptions GetLoadOptionsByExtension(string extension)
        {
            var loadOptions = extension.ToLower() switch
            {
                ".ods" => new OdsLoadOptions(LoadFormat.Ods),
                ".csv" => new TxtLoadOptions(LoadFormat.Csv),
                ".html" => new HtmlLoadOptions(LoadFormat.Html),
                ".mhtml" => new HtmlLoadOptions(LoadFormat.MHtml),
                ".tabdelimited" => new TxtLoadOptions(LoadFormat.TabDelimited),
                ".tsv" => new TxtLoadOptions(LoadFormat.Tsv),
                _ => new LoadOptions()
            };

            loadOptions.CheckExcelRestriction = false;
            return loadOptions;
        }

        protected static SaveFormatType GetSaveFormatTypeByOutputType(string outputType)
        {
            var saveFormat = new SaveFormatType {SaveOptions = null};
            switch (outputType.ToLower())
            {
                case "ods":
                {
                    saveFormat.SaveOptions = new OdsSaveOptions();
                    saveFormat.SaveType = SaveType.Ods;
                    saveFormat.SaveFormat = SaveFormat.Ods;
                    break;
                }
                case "pdf":
                {
                    saveFormat.SaveOptions = new PdfSaveOptions();
                    saveFormat.SaveType = SaveType.Pdf;
                    saveFormat.SaveFormat = SaveFormat.Pdf;
                    break;
                }
                case "docx":
                {
                    saveFormat.SaveOptions = new DocxSaveOptions();
                    saveFormat.SaveType = SaveType.Docx;
                    saveFormat.SaveFormat = SaveFormat.Docx;
                    break;
                }
                case "pptx":
                {
                    saveFormat.SaveOptions = new PptxSaveOptions();
                    saveFormat.SaveType = SaveType.Pptx;
                    saveFormat.SaveFormat = SaveFormat.Pptx;
                    break;
                }
                case "xps":
                {
                    saveFormat.SaveOptions = new XpsSaveOptions();
                    saveFormat.SaveType = SaveType.Xps;
                    saveFormat.SaveFormat = SaveFormat.Xps;
                    break;
                }
                case "xlsx":
                {
                    saveFormat.SaveOptions = null;
                    saveFormat.SaveType = SaveType.Xlsx;
                    saveFormat.SaveFormat = SaveFormat.Xlsx;
                    break;
                }
                case "xls":
                {
                    saveFormat.SaveOptions = new XlsSaveOptions();
                    saveFormat.SaveType = SaveType.Xls;
                    saveFormat.SaveFormat = SaveFormat.Unknown;
                    break;
                }
                case "xlsm":
                {
                    saveFormat.SaveOptions = null;
                    saveFormat.SaveType = SaveType.Xlsm;
                    saveFormat.SaveFormat = SaveFormat.Xlsm;
                    break;
                }
                case "xlsb":
                {
                    saveFormat.SaveOptions = new XlsbSaveOptions();
                    saveFormat.SaveType = SaveType.Xlsb;
                    saveFormat.SaveFormat = SaveFormat.Xlsb;
                    break;
                }
                case "xlam":
                {
                    saveFormat.SaveOptions = null;
                    saveFormat.SaveType = SaveType.Xlam;
                    saveFormat.SaveFormat = SaveFormat.Xlam;
                    break;
                }
                case "csv":
                {
                    saveFormat.SaveOptions = new TxtSaveOptions(SaveFormat.Csv) {Encoding = Encoding.GetEncoding("UTF-8")};
                    saveFormat.SaveType = SaveType.Csv;
                    saveFormat.SaveFormat = SaveFormat.Csv;
                    break;
                }
                case "html":
                {
                    saveFormat.SaveOptions = new HtmlSaveOptions
                    {
                        // ExportFontsAsBase64 = true,
                        ExportImagesAsBase64 = true,
                        // CssStyleSheetType = CssStyleSheetType.Inline,
                        Encoding = fileUtf8WithoutBom,
                        // HtmlVersion = HtmlVersion.Html5
                    };
                    saveFormat.SaveType = SaveType.Html;
                    saveFormat.SaveFormat = SaveFormat.Html;
                    break;
                }
                case "mhtml":
                {
                    saveFormat.SaveOptions = new HtmlSaveOptions(SaveFormat.MHtml)
                    {
                        // ExportFontsAsBase64 = true,
                        ExportImagesAsBase64 = true,
                        // CssStyleSheetType = CssStyleSheetType.Inline,
                        Encoding = fileUtf8WithoutBom,
                        // HtmlVersion = HtmlVersion.Html5
                    };
                    saveFormat.SaveType = SaveType.Mhtml;
                    saveFormat.SaveFormat = SaveFormat.MHtml;
                    break;
                }
                case "svg":
                {
                    saveFormat.SaveOptions = new SvgSaveOptions();
                    saveFormat.ImageOrPrintOptions = new ImageOrPrintOptions {SaveFormat = SaveFormat.Svg};
                    saveFormat.SaveType = SaveType.Svg;
                    saveFormat.SaveFormat = SaveFormat.Svg;
                    break;
                }
                case "bmp":
                {
                    saveFormat.SaveOptions = null;
                    saveFormat.ImageOrPrintOptions = new ImageOrPrintOptions {ImageType = ImageType.Bmp};
                    saveFormat.SaveType = SaveType.Bmp;
                    saveFormat.SaveFormat = SaveFormat.Unknown;
                    break;
                }
                case "png":
                {
                    saveFormat.SaveOptions = null;
                    saveFormat.ImageOrPrintOptions = new ImageOrPrintOptions {ImageType = ImageType.Png};
                    saveFormat.SaveType = SaveType.Png;
                    saveFormat.SaveFormat = SaveFormat.Unknown;
                    break;
                }
                case "tiff":
                {
                    saveFormat.SaveOptions = new ImageSaveOptions(SaveFormat.Tiff);
                    saveFormat.ImageOrPrintOptions = new ImageOrPrintOptions {ImageType = ImageType.Tiff};
                    saveFormat.SaveType = SaveType.Tiff;
                    saveFormat.SaveFormat = SaveFormat.Tiff;
                    break;
                }
                case "jpg":
                {
                    saveFormat.SaveOptions = null;
                    saveFormat.ImageOrPrintOptions = new ImageOrPrintOptions {ImageType = ImageType.Jpeg};
                    saveFormat.SaveType = SaveType.Jpg;
                    saveFormat.SaveFormat = SaveFormat.Unknown;
                    break;
                }
                case "tabdelimited":
                {
                    saveFormat.SaveOptions = null;
                    saveFormat.SaveType = SaveType.Tabdelimited;
                    saveFormat.SaveFormat = SaveFormat.TabDelimited;
                    break;
                }
                case "tsv":
                {
                    saveFormat.SaveOptions = new TxtSaveOptions(SaveFormat.Tsv) {Encoding = Encoding.GetEncoding("UTF-8")};
                    saveFormat.SaveType = SaveType.Tsv;
                    saveFormat.SaveFormat = SaveFormat.Tsv;
                    break;
                }
                case "md":
                {
                    saveFormat.SaveOptions = new MarkdownSaveOptions();
                    saveFormat.SaveType = SaveType.Md;
                    saveFormat.SaveFormat = SaveFormat.Markdown;
                    break;
                }
            }

            return saveFormat;
        }

        protected static SaveFormatType GetSaveFormatTypeByFilename(string filename)
        {
            var outputType = Path.GetExtension(filename);

            if (string.IsNullOrEmpty(outputType)) throw new FormatException();

            if (outputType[0] == '.')
            {
                outputType = outputType.Substring(1);
            }

            return GetSaveFormatTypeByOutputType(outputType);
        }

        protected async Task<DocumentInfo[]> UploadFiles(string sessionId, string password, string appName)
        {
            var duration = Stopwatch.StartNew();
            var sourceKeyLs = new List<string>();
            try
            {
                IEnumerable<IFormFile> uploadProvider = HttpContext.Request.Form.Files;
                uploadProvider = uploadProvider.Union(await UploadLinks());
                var formFiles = uploadProvider.ToList();
                Logger.FileUploading(formFiles.Select(x => x.FileName).ToArray(), "", true);

                var res = new List<DocumentInfo>();

                foreach (var formFile in formFiles)
                {
                    await using var memoryStream = new MemoryStream();
                    await formFile.CopyToAsync(memoryStream);
                    await using (var stream = new MemoryStream())
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        await memoryStream.CopyToAsync(stream);

                        // upload source files to AWS S3
                        var objectPath = $"{Configuration.SourceFolder}/{sessionId}/{formFile.FileName}";
                        sourceKeyLs.Add(objectPath);
                        await Storage.Upload(objectPath, stream, new AwsMetaInfo
                        {
                            OriginalFileName = formFile.FileName,
                            Title = formFile.FileName
                        });
                    }

                    memoryStream.Seek(0, SeekOrigin.Begin);
                    lock (_readSync)
                    {
                        var interruptMonitor = new InterruptMonitor();
                        var thread = new Thread(InterruptMonitor);
                        try
                        {
                            thread.Start(new object[] {interruptMonitor, Configuration.MillisecondsTimeout, formFile.FileName});
                            Workbook workbook;
                            if (IsImage(memoryStream))
                            {
                                workbook = new Workbook();
                                workbook.Worksheets[0].Pictures.Add(0, 0, memoryStream);
                            }
                            else
                            {
                                var loadOptions = GetLoadOptionsByExtension(Path.GetExtension(formFile.FileName), interruptMonitor);
                                loadOptions.Password = password;
                                workbook = new Workbook(memoryStream, loadOptions);
                            }

                            res.Add(new DocumentInfo
                            {
                                FolderName = sessionId,
                                FileName = formFile.FileName,
                                Workbook = workbook
                            });
                        }
                        finally
                        {
                            thread.Interrupt();
                        }
                    }
                }

                Logger.FileUploaded(res.Select(x => x.FileName).ToArray(), "", duration.Elapsed);
                return res.ToArray();
            }
            catch (CellsException e)
            {
                if (e.Code != ExceptionType.IncorrectPassword)
                {
                    foreach (var sourceKey in sourceKeyLs)
                    {
                        var destinationKey = sourceKey.Replace(Configuration.SourceFolder, $"{Configuration.ErrorFolder}/{appName}");
                        await Storage.CopyingObjectAsync(sourceKey, destinationKey);
                    }

                    if (e.Code == ExceptionType.Interrupted)
                    {
                        Logger.LogError("UploadFiles {SessionId}=>{ProcessingTimeout}", sessionId, Configuration.ProcessingTimeout);
                        throw new TimeoutException(Configuration.ProcessingTimeout);
                    }
                }

                Logger.FileUploadingError(HttpContext.Request?.Form?.Files?.Select(x => x.FileName).ToArray(), duration.Elapsed, e);
                if (string.IsNullOrEmpty(e.Message))
                    throw new Exception("Invalid file, please ensure that uploading correct file");
                throw;
            }
            catch (Exception e)
            {
                foreach (var sourceKey in sourceKeyLs)
                {
                    var destinationKey = sourceKey.Replace(Configuration.SourceFolder, $"{Configuration.ErrorFolder}/{appName}");
                    await Storage.CopyingObjectAsync(sourceKey, destinationKey);
                }

                Logger.FileUploadingError(HttpContext.Request?.Form?.Files?.Select(x => x.FileName).ToArray(), duration.Elapsed, e);
                if (string.IsNullOrEmpty(e.Message))
                    throw new Exception("Invalid file, please ensure that uploading correct file");
                throw;
            }
        }

        protected async Task<FormFile[]> UploadLinks()
        {
            var form = await HttpContext.Request.ReadFormAsync();
            var service = new WebClientService();
            var internalService = new InternalLinkService(Storage);
            var files = await Task.WhenAll(
                form
                    .Where(item =>
                        Uri.IsWellFormedUriString(item.Value, UriKind.Absolute))
                    .AsParallel()
                    .Where(item =>
                        item.Key.StartsWith("link_"))
                    .Select(async item => await service.Upload(item.Value)));

            var internalFiles = await Task.WhenAll(
                form
                    .Where(item => Uri.IsWellFormedUriString(item.Value, UriKind.Relative))
                    .AsParallel()
                    .Where(item =>
                        item.Key.StartsWith("link_"))
                    .Select(async item => await internalService.Upload(item.Value)));
            return files.Union(internalFiles).Where(f => f != null).ToArray();
        }

        protected Dictionary<string, Stream> SaveDocument(DocumentInfo doc, SaveFormatType saveOptions)
        {
            var streams = new Dictionary<string, Stream>();
            doc.Workbook.InterruptMonitor = new InterruptMonitor();
            var thread = new Thread(InterruptMonitor);
            try
            {
                thread.Start(new object[] {doc.Workbook.InterruptMonitor, Configuration.MillisecondsTimeout, doc.FileName});
                switch (saveOptions.SaveType)
                {
                    case SaveType.Xls:
                    case SaveType.Ods:
                    case SaveType.Pdf:
                    case SaveType.Xps:
                    case SaveType.Xlsx:
                    case SaveType.Xlsm:
                    case SaveType.Xlsb:
                    case SaveType.Xlam:
                    case SaveType.Tabdelimited:
                    case SaveType.Md:
                    case SaveType.Csv:
                    case SaveType.Tsv:
                    case SaveType.Docx:
                    case SaveType.Pptx:
                    case SaveType.Mhtml:
                    {
                        if (saveOptions.SaveOptions == null && saveOptions.SaveFormat == SaveFormat.Unknown)
                        {
                            throw new Exception("Represents unrecognized format, cannot be saved.");
                        }

                        var stream = new MemoryStream();
                        if (saveOptions.SaveOptions != null)
                        {
                            doc.Workbook.Save(stream, saveOptions.SaveOptions);
                        }

                        if (saveOptions.SaveOptions == null)
                        {
                            doc.Workbook.Save(stream, saveOptions.SaveFormat);
                        }

                        stream.Seek(0, SeekOrigin.Begin);
                        streams.Add(doc.FileName, stream);
                        break;
                    }
                    case SaveType.Html:
                    {
                        streams = SaveHtml(doc, saveOptions.SaveFormat);
                        break;
                    }
                    case SaveType.Tiff:
                    case SaveType.Png:
                    case SaveType.Jpg:
                    case SaveType.Bmp:
                    case SaveType.Svg:
                    {
                        streams = SaveImage(doc, saveOptions.ImageOrPrintOptions);
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                return streams;
            }
            finally
            {
                thread.Interrupt();
            }
        }

        /// <summary>
        /// SaveFormatType
        /// </summary>
        protected class SaveFormatType
        {
            /// <summary>
            /// SaveOptions
            /// </summary>
            public SaveOptions SaveOptions { get; set; }

            /// <summary>
            /// SaveType
            /// </summary>
            public SaveType SaveType { get; set; }

            public ImageOrPrintOptions ImageOrPrintOptions { get; set; }

            public SaveFormat SaveFormat { get; set; }
        }

        /// <summary>
        /// SaveType
        /// </summary>
        protected enum SaveType
        {
            Ods,
            Pdf,
            Docx,
            Pptx,
            Xps,
            Html,
            Jpg,
            Png,
            Bmp,
            Tiff,
            Svg,
            Xls,
            Xlsx,
            Xlsm,
            Xlsb,
            Xlam,
            Csv,
            Tabdelimited,
            Tsv,
            Mhtml,
            Md
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

        /// <summary>
        /// todo IsImage
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public bool IsImage(Stream stream)
        {
            try
            {
                Image.FromStream(stream);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Dictionary<string, Stream> SaveImage(DocumentInfo doc, ImageOrPrintOptions imgOptions)
        {
            var streams = new Dictionary<string, Stream>();
            var sheetCount = doc.Workbook.Worksheets.Count;
            var outFilename = $"{Path.GetFileNameWithoutExtension(doc.FileName)}{Opts.OutputType}";

            foreach (var sheet in doc.Workbook.Worksheets)
            {
                imgOptions.OutputBlankPageWhenNothingToPrint = true;
                var sr = new SheetRender(sheet, imgOptions);
                var srPageCount = Math.Min(sr.PageCount, Configuration.MaxPageCount);
                for (var i = 0; i < srPageCount; i++)
                {
                    if (sheetCount > 1 || srPageCount > 1)
                    {
                        outFilename = $"{sheet.Name}_{(i + 1)}{Opts.OutputType}";
                    }

                    var outStream = new MemoryStream();
                    sr.ToImage(i, outStream);
                    outStream.Seek(0, SeekOrigin.Begin);
                    streams.Add(outFilename, outStream);
                }
            }

            return streams;
        }

        private Dictionary<string, Stream> SaveHtml(DocumentInfo doc, SaveFormat saveFormat)
        {
            var streams = new Dictionary<string, Stream>();
            var ms = new MemoryStream();

            var options = new HtmlSaveOptions(saveFormat) {ExportImagesAsBase64 = true};
            var streamProvider = new HtmlExportStreamProvider(doc.FileName);
            options.StreamProvider = streamProvider;
            doc.Workbook.Save(ms, options);
            ms.Seek(0, SeekOrigin.Begin);
            streams.Add(doc.FileName, ms);
            foreach (var (key, value) in streamProvider.FileStreams)
            {
                value.Seek(0, SeekOrigin.Begin);
                streams.Add(key, value);
            }

            return streams;
        }

        public (string, string) BeforeAction()
        {
            var outputFolder = Opts.CreateZip ? $"{Opts.FolderName}/{ZipFolderName}" : Opts.FolderName;
            var outFilePath = $"{outputFolder}/{Opts.ResultFileName}";
            return (outputFolder, outFilePath);
        }

        public async Task<Response> AfterAction(string outFilePath, Dictionary<string, Stream> streams)
        {
            var duration = Stopwatch.StartNew();
            await using var outStream = new MemoryStream();

            if (streams.Count > 1)
            {
                Opts.ResultFileName = $"{Opts.ZipFileName}.zip";
                await using var zipStream = new MemoryStream();
                using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                {
                    foreach (var (filename, stream) in streams)
                    {
                        var entry = archive.CreateEntry(filename);
                        await using var entryStream = entry.Open();
                        stream.Seek(0, SeekOrigin.Begin);
                        await stream.CopyToAsync(entryStream);
                        stream.Close();
                    }
                }

                zipStream.Seek(0, SeekOrigin.Begin);
                await zipStream.CopyToAsync(outStream);
            }
            else
            {
                await using var sourceStream = streams.First().Value;
                sourceStream.Seek(0, SeekOrigin.Begin);
                await sourceStream.CopyToAsync(outStream);
            }

            try
            {
                // Upload result file
                Logger.FileUploading(new[] {outFilePath}, "", false);
                outStream.Seek(0, SeekOrigin.Begin);
                var objectPath = $"{Configuration.ConvertFolder}/{Opts.FolderName}/{Opts.ResultFileName}";
                await Storage.Upload(objectPath, outStream, new AwsMetaInfo
                {
                    OriginalFileName = Opts.ResultFileName,
                    Title = Opts.ResultFileName
                });
                Logger.FileUploaded(new[] {outFilePath}, "", duration.Elapsed);
            }
            catch (Exception e)
            {
                Logger.FileUploadingError(new[] {outFilePath}, duration.Elapsed, e);
                var response = Models.Response.Error(Opts.FolderName, Opts.ResultFileName, "Error when processing");
                await Storage.UpdateStatus(response);
                return response;
            }

            try
            {
                // Update status of result file
                var response = Models.Response.Complete(Opts.FolderName, Opts.ResultFileName);
                response.FileProcessingErrorCode = FileProcessingErrorCode.OK;
                await Storage.UpdateStatus(response);
                return response;
            }
            catch (Exception e)
            {
                Logger.FileUploadingError(new[] {"status.json"}, duration.Elapsed, e);
                var response = Models.Response.Error(Opts.FolderName, Opts.ResultFileName, "Error when processing");
                await Storage.UpdateStatus(response);
                return response;
            }
        }

        protected async Task UploadErrorFiles(DocumentInfo[] docs, string appName)
        {
            foreach (var doc in docs)
            {
                var sourceKey = $"{Configuration.SourceFolder}/{doc.FolderName}/{doc.FileName}";
                var destinationKey = $"{Configuration.ErrorFolder}/{appName}/{doc.FolderName}/{doc.FileName}";
                await Storage.CopyingObjectAsync(sourceKey, destinationKey);
            }
        }

        protected async Task UploadErrorFile(string folderName, string filename, string appName)
        {
            var sourceKey = $"{Configuration.SourceFolder}/{folderName}/{filename}";
            var destinationKey = $"{Configuration.ErrorFolder}/{appName}/{folderName}/{filename}";
            await Storage.CopyingObjectAsync(sourceKey, destinationKey);
        }

        protected async Task UploadUidFile(string folderName, string uid, string appName)
        {
            var sourceKey = $"{Configuration.GridJsCacheFolder}/{uid}";
            var destinationKey = $"{Configuration.ErrorFolder}/{appName}/{folderName}/{uid}";
            await Storage.CopyingObjectAsync(sourceKey, destinationKey);
        }

        protected async Task UploadGridJsErrorJson(string errorJson, string id)
        {
            var duration = Stopwatch.StartNew();
            var objectPath = $"{Configuration.GridJsErrorJsonFolder}/{id}.json";
            try
            {
                await using var memoryStream = new MemoryStream();
                await using var requestWriter = new StreamWriter(memoryStream);
                await requestWriter.WriteAsync(errorJson);
                await requestWriter.FlushAsync();
                await Storage.Upload(objectPath, memoryStream);
            }
            catch (Exception e)
            {
                Logger.FileUploadingError(new[] {objectPath}, duration.Elapsed, e);
            }
        }

        public void InterruptMonitor(object o)
        {
            var os = (object[]) o;
            try
            {
                Thread.Sleep((int) os[1]);
                Logger.LogError("Failed to process file in given time: {Time}ms | filename : {Filename}", os[1], os[2]);
                ((InterruptMonitor) os[0]).Interrupt();
            }
            catch (ThreadInterruptedException)
            {
            }
        }

        public void GridInterruptMonitor(object o)
        {
            var os = (object[]) o;
            try
            {
                Thread.Sleep((int) os[1]);
                Logger.LogError("GridJs failed to process file in given time: {Time}ms | filename : {Filename}", os[1], os[2]);
                ((GridInterruptMonitor) os[0]).Interrupt();
            }
            catch (ThreadInterruptedException)
            {
            }
        }

        public async Task<Workbook> GetWorkbook(InterruptMonitor interruptMonitor)
        {
            var objectPath = $"{Configuration.SourceFolder}/{Opts.FolderName}/{Opts.FileName}";
            var stream = await Storage.Download(objectPath);
            var loadOptions = GetLoadOptionsByExtension(Path.GetExtension(Opts.FileName), interruptMonitor);
            var workbook = new Workbook(stream, loadOptions);
            return workbook;
        }

        public async Task<Workbook> GetWorkbook(string objectPath, InterruptMonitor interruptMonitor)
        {
            var stream = await Storage.Download(objectPath);
            var loadOptions = GetLoadOptionsByExtension(Path.GetExtension(objectPath), interruptMonitor);
            var workbook = new Workbook(stream, loadOptions);
            return workbook;
        }

        public GridLoadFormat GetGridLoadFormat(string extension)
        {
            return extension.ToLower() switch
            {
                ".csv" => GridLoadFormat.CSV,
                ".xls" => GridLoadFormat.Excel97To2003,
                ".xlsx" => GridLoadFormat.Xlsx,
                ".tsv" => GridLoadFormat.TSV,
                ".tabDelimited" => GridLoadFormat.TabDelimited,
                ".html" => GridLoadFormat.Html,
                ".mhtml" => GridLoadFormat.MHtml,
                ".ods" => GridLoadFormat.ODS,
                ".xlsb" => GridLoadFormat.Xlsb,
                ".fods" => GridLoadFormat.FODS,
                ".sxc" => GridLoadFormat.SXC,
                _ => GridLoadFormat.Unknown
            };
        }
    }
}