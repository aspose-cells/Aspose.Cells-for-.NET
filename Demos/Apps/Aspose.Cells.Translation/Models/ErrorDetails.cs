using System;
using System.Text;

namespace Aspose.Cells.Translation.Models
{
    public class ErrorDetails
    {
        public string RequestId { get; set; }

        public DateTime? Date { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ErrorDetails {\n");
            sb.Append("  RequestId: ").Append(RequestId).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}