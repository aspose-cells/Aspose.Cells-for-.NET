using System.Text;

namespace Aspose.Cells.API.Models
{
    public class TextResponse
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public string Translation { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TextResponse {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Translation: ").Append(Translation).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}