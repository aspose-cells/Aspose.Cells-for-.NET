using System;
using System.Text;
using System.Web;
using Aspose.Cells.UI.Config;

namespace Aspose.Cells.UI.Models
{
    public class FileUploadResult
    {
        public string LocalFilePath { get; set; }
        public string FileName { get; set; }
        public string FolderId { get; set; }
        public long FileLength { get; set; }

        public string DownloadUrl()
        {
            var url = new StringBuilder(Configuration.FileDownloadLink);
            url.Append("?FileName=");
            url.Append(HttpUtility.UrlPathEncode(FileName));
            url.Append("&Time=");
            url.Append(DateTime.Now);

            if (string.IsNullOrEmpty(FolderId)) return url.ToString();

            url.Append("&FolderName=");
            url.Append(FolderId);

            return url.ToString();
        }
    }
}