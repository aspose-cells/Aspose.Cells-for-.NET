using System.IO;

namespace Aspose.Cells.API.Models.Requests
{
    public class UploadFileRequest
    {
        public string Path { get; set; }

        public Stream File { get; set; }

        public string StorageName { get; set; }
    }
}