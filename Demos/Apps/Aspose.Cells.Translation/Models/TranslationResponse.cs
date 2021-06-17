using System.Text;

namespace Aspose.Cells.Translation.Models
{
    public class TranslationResponse
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TranslationResponse {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}