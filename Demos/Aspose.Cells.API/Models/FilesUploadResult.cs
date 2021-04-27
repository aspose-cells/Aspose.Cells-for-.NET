using System.Collections.Generic;
using System.Text;

namespace Aspose.Cells.API.Models
{
    public class FilesUploadResult
    {
        public List<string> Uploaded { get; set; }

        public List<Error> Errors { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FilesUploadResult {\n");
            sb.Append("  Uploaded: ").Append(Uploaded).Append("\n");
            sb.Append("  Errors: ").Append(Errors).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}