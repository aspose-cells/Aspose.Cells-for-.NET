using System.Collections.ObjectModel;

namespace Aspose.Cells.Common.Models
{
    public class Response
    {
        ///<Summary>
        /// Get or set DownloadFileLink
        ///</Summary>
        public string DownloadFileLink { get; set; }

        ///<Summary>
        /// Get or set StatusCode
        ///</Summary>
        public int StatusCode { get; set; }

        ///<Summary>
        /// Get or set FileName
        ///</Summary>
        public string FileName { get; set; }

        ///<Summary>
        /// Get or set FolderName
        ///</Summary>
        public string FolderName { get; set; }

        ///<Summary>
        /// Get or set Status
        ///</Summary>
        public string Status { get; set; }

        ///<Summary>
        /// Get or set Text
        ///</Summary>
        public string Text { get; set; }

        ///<Summary>
        /// Get or set Files
        ///</Summary>
        public Collection<string> Files { get; set; }

        ///<Summary>
        /// Get or set FileProcessingErrorCode
        ///</Summary>
        public FileProcessingErrorCode FileProcessingErrorCode { get; set; }

        /// <summary>
        /// Get count of files
        /// </summary>
        public int FileCount => Files?.Count ?? 0;

        public static Response Process(string folder, string fileName)
        {
            return new Response
            {
                FileName = fileName,
                FolderName = folder,
                Status = "Processing",
                StatusCode = 204
            };
        }

        public static Response Complete(string folder, string fileName)
        {
            return new Response
            {
                FileName = fileName,
                FolderName = folder,
                Status = "Complete",
                StatusCode = 200
            };
        }

        public static Response Error(string folder, string fileName, string message)
        {
            return new Response
            {
                FileName = fileName,
                FolderName = folder,
                Status = message,
                StatusCode = 500
            };
        }

        public static Response NoSearchResults(string folder, string filename)
        {
            return new Response
            {
                FileName = filename,
                FolderName = folder,
                Status = "Complete",
                StatusCode = 200,
                FileProcessingErrorCode = FileProcessingErrorCode.NoSearchResults
            };
        }
    }
}