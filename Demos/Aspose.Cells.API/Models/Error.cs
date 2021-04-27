using System.Text;

namespace Aspose.Cells.API.Models
{
    public class Error
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public string Description { get; set; }

        public ErrorDetails InnerError { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Error {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  InnerError: ").Append(InnerError).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}