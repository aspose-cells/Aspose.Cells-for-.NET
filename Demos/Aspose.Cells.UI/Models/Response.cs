using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Web;
using Aspose.Cells.UI.Config;

namespace Aspose.Cells.UI.Models
{
    public class Response
    {
        public string DownloadFileLink { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string FileName { get; set; }
        public string Text { get; set; }
        public Collection<string> Files;
        public string FolderName { get; set; }
        public FileProcessingErrorCode FileProcessingErrorCode { get; set; }

        public string DownloadURL()
        {
            var url = new StringBuilder(Configuration.FileDownloadLink);
            url.Append("?FileName=");
            url.Append(HttpUtility.UrlPathEncode(FileName));
            url.Append("&Time=");
            url.Append(DateTime.Now);
            if (string.IsNullOrEmpty(FolderName)) return url.ToString();
            url.Append("&FolderName=");
            url.Append(FolderName);

            return url.ToString();
        }

        public string ViewerURL(string product, string callbackURL)
        {
            var url = new StringBuilder();
            switch (product.ToLower())
            {
                case "words":
                    url.Append($"/{product}/view?FolderName=");
                    url.Append(FolderName);
                    url.Append("&FileName=");
                    url.Append(HttpUtility.UrlEncode(FileName));
                    url.Append("&callbackURL=");
                    url.Append(callbackURL);
                    break;
                case "html":
                case "page":
                case "pdf":
                case "email":
                    url.Append($"/{product}/viewer/{FolderName}/{FileName}/");
                    //url.Append("?fileName=");
                    //url.Append(HttpUtility.UrlEncode(FileName));
                    url.Append("?callbackURL=");
                    url.Append(callbackURL);
                    //url.Append("#page-view-1");
                    break;
                default:
                    url.Append(string.Format(Configuration.FileViewLink, product));
                    url.Append("/");
                    url.Append(FolderName);
                    url.Append("?fileName=");
                    url.Append(HttpUtility.UrlEncode(FileName));
                    url.Append("&callbackURL=");
                    url.Append(callbackURL);
                    break;
            }

            return url.ToString();
        }

        public string ViewerURL(string callbackURL)
        {
            return ViewerURL(GetProductByFileExtension(), callbackURL);
        }

        private string GetProductByFileExtension()
        {
            switch (Path.GetExtension(FileName)?.ToLower())
            {
                case ".eml":
                case ".msg":
                    return "email";
                case ".mhtml":
                case ".html":
                    return "html";
                case ".epub":
                case ".ps":
                case ".xps":
                case ".pdf":
                    return "pdf";
                default:
                    return "words";
            }
        }

        public override string ToString()
        {
            return $"{StatusCode} - {Status}";
        }
    }
}