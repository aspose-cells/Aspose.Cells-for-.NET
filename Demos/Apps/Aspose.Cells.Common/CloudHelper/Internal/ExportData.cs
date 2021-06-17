namespace Aspose.Cells.Common.CloudHelper
{
    using System;
    using System.Collections.Generic;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Net.Http.Headers;

    /// <summary>
    /// 
    /// </summary>
    internal class ExportData
    {
        private static readonly  Dictionary<string, ExportData> AllOperationFormats = new Dictionary<string, ExportData>
            {
                {"CSV", new ExportData("CSV", FormatCsv, "csv")},
                {"XLS", new ExportData("XLS", FormatExcel, "xls")},
                {"HTML", new ExportData("HTML", FormatHtml, "html")},
                {"MHTML", new ExportData("MHTML", FormatMHtml, "mhtml")},
                {"ODS", new ExportData("ODS", FormatOds, "ods")},
                {"PDF", new ExportData("PDF", FormatPdf, "pdf")},
                {"XML", new ExportData("SPREADSHEETML", FormatXml, "xml")},
                {"TXT", new ExportData("TABDELIMITED", FormatTxt, "txt")},
                {"TIFF", new ExportData("TIFF", FormatTiff, "tiff")},
                {"XLSB", new ExportData("XLSB", FormatExcel, "xlsb")},
                {"XLSM", new ExportData("XLSM", FormatExcel, "xlsm")},
                {"XLSX", new ExportData("XLSX", FormatExcel, "xlsx")},
                {"XLTM", new ExportData("XLTM", FormatExcel, "xltm")},
                {"XLTX", new ExportData("XLTX", FormatExcel, "xltx")},
                {"XPS", new ExportData("XPS", FormatXps, "xps")},
                {"PNG", new ExportData("PNG", FormatPng, "png")},
                {"JPG", new ExportData("JPG", FormatJpeg, "jpg")},
                {"JPEG", new ExportData("JPEG", FormatJpeg, "jpeg")},
                {"GIF", new ExportData("GIF", FormatGif, "gif")},
                {"EMF", new ExportData("EMF", FormatEmf, "emf")},
                {"BMP", new ExportData("BMP", FormatBmp, "bmp")},
                {"MD", new ExportData("MD", FormatMD, "MD")},
                {"MARKDOWN", new ExportData("MARKDOWN", FormatMD, "Markdown")},
                {"NUMBERS", new ExportData("NUMBERS", FormatNumbers, "Numbers")},
                {"WMF",new ExportData("WMF",FormatWmf,"wmf") },
                {"SVG",new ExportData("SVG",FormatSvg,"svg") },
                {"AUTO", new ExportData("AUTO", FormatExcel, "auto")}
            };

        #region Private fields

        private readonly string _format;
        private readonly string _contentType;
        private readonly string _extension;
        private readonly ImageFormat _imageFormat;
        #endregion

        #region Protected constants

        /// <summary>
        /// application/octet-stream
        /// </summary>
        protected const string FormatBin = "application/octet-stream";

        /// <summary>
        /// image/bmp
        /// </summary>
        protected const string FormatBmp = "image/bmp";
        /// <summary>
        ///text/markdown
        /// </summary>
        protected const string FormatMD = "text/markdown";
        /// <summary>
        /// 
        /// </summary>
        protected const string FormatNumbers = "application/vnd.apple.numbers";
        /// <summary>
        /// text/csv
        /// </summary>
        protected const string FormatCsv = "text/csv";

        /// <summary>
        /// message/rfc822
        /// </summary>
        protected const string FormatEmail = "message/rfc822";

        /// <summary>
        /// image/emf
        /// </summary>
        protected const string FormatEmf = "image/emf";

        /// <summary>
        /// application/epub+zip
        /// </summary>
        protected const string FormatEpub = "application/epub+zip";

        /// <summary>
        /// application/vnd.ms-excel
        /// </summary>
        protected const string FormatExcel = "application/vnd.ms-excel";

        /// <summary>
        /// application/vnd.openxmlformats-package.relationships+xml
        /// </summary>
        protected const string FormatFlatopc = "application/vnd.openxmlformats-package.relationships+xml";

        /// <summary>
        /// image/gif
        /// </summary>
        protected const string FormatGif = "image/gif";

        /// <summary>
        /// text/html
        /// </summary>
        protected const string FormatHtml = "text/html";
        /// <summary>
        /// text/html
        /// </summary>
        protected const string FormatMHtml = "tmultipart/related";
        /// <summary>
        /// image/jpeg
        /// </summary>
        protected const string FormatJpeg = "image/jpeg";

        /// <summary>
        /// text/vnd.latex-z
        /// </summary>
        protected const string FormatLaTeX = "text/vnd.latex-z";

        /// <summary>
        /// application/vnd.ms-outlook
        /// </summary>
        protected const string FormatMsg = "application/vnd.ms-outlook";

        /// <summary>
        /// multipart/related
        /// </summary>
        protected const string FormatMultipart = "multipart/related";

        /// <summary>
        /// application/vnd.oasis.opendocument.presentation
        /// </summary>
        protected const string FormatOdp = "application/vnd.oasis.opendocument.presentation";

        /// <summary>
        /// application/vnd.oasis.opendocument.spreadsheet
        /// </summary>
        protected const string FormatOds = "application/vnd.oasis.opendocument.spreadsheet";

        /// <summary>
        /// application/vnd.oasis.opendocument.text
        /// </summary>
        protected const string FormatOdt = "application/vnd.oasis.opendocument.text";

        /// <summary>
        /// application/vnd.oasis.opendocument.text-template 
        /// </summary>
        protected const string FormatOtt = "application/vnd.oasis.opendocument.text-template";

        /// <summary>
        /// application/pdf
        /// </summary>
        protected const string FormatPdf = "application/pdf";

        /// <summary>
        /// image/png
        /// </summary>
        protected const string FormatPng = "image/png";

        /// <summary>
        /// vnd.ms-powerpoint.template.macroEnabled.12
        /// </summary>
        protected const string FormatPotm = "vnd.ms-powerpoint.template.macroEnabled.12";

        /// <summary>
        /// vnd.ms-powerpoint.slideshow.macroEnabled.12
        /// </summary>
        protected const string FormatPpsm = "vnd.ms-powerpoint.slideshow.macroEnabled.12";

        /// <summary>
        /// application/vnd.ms-powerpoint
        /// </summary>
        protected const string FormatPpt = "application/vnd.ms-powerpoint";

        /// <summary>
        /// vnd.ms-powerpoint.presentation.macroEnabled.12
        /// </summary>
        protected const string FormatPptm = "vnd.ms-powerpoint.presentation.macroEnabled.12";

        /// <summary>
        /// application/vnd.openxmlformats-officedocument.presentationml.presentation
        /// </summary>
        protected const string FormatPptx = "application/vnd.openxmlformats-officedocument.presentationml.presentation";

        /// <summary>
        /// application/postscript
        /// </summary>
        protected const string FormatPs = "application/postscript";

        /// <summary>
        /// application/rtf
        /// </summary>
        protected const string FormatRtf = "application/rtf";

        /// <summary>
        /// image/svg+xml
        /// </summary>
        protected const string FormatSvg = "image/svg+xml";

        /// <summary>
        /// application/x-shockwave-flash
        /// </summary>
        protected const string FormatSwf = "application/x-shockwave-flash";

        /// <summary>
        /// image/tiff
        /// </summary>
        protected const string FormatTiff = "image/tiff";

        /// <summary>
        /// text/plain
        /// </summary>
        protected const string FormatTxt = "text/plain";

        /// <summary>
        /// text/vnd.wap.wml
        /// </summary>
        protected const string FormatWml = "text/vnd.wap.wml";

        /// <summary>
        /// application/msword
        /// </summary>
        protected const string FormatWord = "application/msword";

        /// <summary>
        /// application/vnd.ms-word.document.macroEnabled.12
        /// </summary>
        protected const string FormatWordDocm = "application/vnd.ms-word.document.macroEnabled.12";

        /// <summary>
        /// application/vnd.openxmlformats-officedocument.wordprocessingml.document
        /// </summary>
        protected const string FormatWordDocx = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

        /// <summary>
        /// application/vnd.ms-word.template.macroEnabled.12
        /// </summary>
        protected const string FormatWordDotm = "application/vnd.ms-word.template.macroEnabled.12";

        /// <summary>
        /// application/vnd.ms-word.document.macroEnabled.12
        /// </summary>
        protected const string FormatWordDotx = "application/vnd.ms-word.document.macroEnabled.12";

        /// <summary>
        /// application/xaml+xml
        /// </summary>
        protected const string FormatXamlFlow = "application/xaml+xml";

        /// <summary>
        /// application/xaml+xml
        /// </summary>
        protected const string FormatXamlFixed = "application/xaml+xml";

        /// <summary>
        /// text/xml
        /// </summary>
        protected const string FormatXml = "text/xml";

        /// <summary>
        /// application/vnd.ms-xpsdocument
        /// </summary>
        protected const string FormatXps = "application/vnd.ms-xpsdocument";

        /// <summary>
        /// application/oxps
        /// </summary>
        protected const string FormatOpenXps = "application/oxps";

        /// <summary>
        /// application/zip
        /// </summary>
        protected const string FormatZip = "application/zip";

        /// <summary>
        /// application/vnd.ms-project
        /// </summary>
        protected const string FormatMpp = "application/vnd.ms-project";

        /// <summary>
        /// application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
        /// </summary>
        protected const string FormatXlsx = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        /// <summary>
        /// MPX - Exchange file (Microsoft Project) used for exporting data application/x-project
        /// </summary>
        protected const string FormatMpx = "application/x-project";

        /// <summary>
        ///  Windows Metafile.
        /// </summary>
        protected const string FormatWmf = "application/x-msmetafile";

        /// <summary>
        ///   Macintosh PICT.
        /// </summary>
        protected const string FormatPict = "image/pict";
        #endregion

        #region Private constructors

        static ExportData()
        {
        }

        /// <summary>
        /// Constructor for specific format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="contentType">HHTP content type for the format.</param>
        /// <param name="extension">File extension for the format.</param>
        protected ExportData(string format, string contentType, string extension)
        {
            _format = format;
            _contentType = contentType;
            _extension = extension;

            switch (format.ToUpper())
            {
                case "PNG":
                    _imageFormat = ImageFormat.Png;
                    break;
                case "TIFF":
                    _imageFormat = ImageFormat.Tiff;
                    break;
                case "JPEG":
                    _imageFormat = ImageFormat.Jpeg;
                    break;
                case "GIF":
                    _imageFormat = ImageFormat.Gif;
                    break;
                case "EMF":
                    _imageFormat = ImageFormat.Emf;
                    break;
                case "BMP":
                    _imageFormat = ImageFormat.Bmp;
                    break;
                case "WMF":
                    _imageFormat = ImageFormat.Wmf;
                    break;
            }
        }

        private ExportData(string format, string contentType, string extension, ImageFormat imageFormat)
        {
            _format = format;
            _contentType = contentType;
            _extension = extension;
            _imageFormat = imageFormat;
        }


        #endregion

        #region Public properties

        /// <summary>
        /// Export format.
        /// </summary>
        public string Format
        {
            get { return _format; }
        }

        /// <summary>
        /// Response content type.
        /// </summary>
        public string ContentType
        {
            get { return _contentType; }
        }

        /// <summary>
        /// Response file extension.
        /// </summary>
        public string Extension
        {
            get { return _extension; }
        }

        /// <summary>
        /// Image format
        /// </summary>
        public ImageFormat ImageFormat
        {
            get { return _imageFormat; }
        }

        #endregion

        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetFileMimeType(string name)
        {
            string format = System.IO.Path.GetExtension(name);
            if (format.StartsWith(".")) format = format.Substring(1);
            var key = format.ToUpperInvariant();
            if (AllOperationFormats.ContainsKey(key))
                return AllOperationFormats[key].ContentType;
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public static ExportData GetExportData(string format)
        {
            if (format != null)
            {
                var key = format.ToUpperInvariant();
                if (AllOperationFormats.ContainsKey(key))
                    return AllOperationFormats[key];
            }

            throw new NotSupportedException(string.Format("Format '{0}' is not supported.", format));
        }

        /// <summary>
        /// Checks that the format is supported.
        /// </summary>
        /// <param name="format">The format to check.</param>
        /// <param name="kind"></param>
        /// <returns>True if the format supported.</returns>
        public static bool IsSupported(string format)
        {
            return AllOperationFormats.ContainsKey(format.ToUpperInvariant());
        }
    }    
}