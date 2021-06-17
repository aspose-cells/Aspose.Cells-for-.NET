using System.IO;

namespace Aspose.Cells.Translation.Models.Requests
{
    public class UploadFileRequest
    {
        public string Path { get; set; }

        public Stream File { get; set; }

        public string StorageName { get; set; }
    }
}