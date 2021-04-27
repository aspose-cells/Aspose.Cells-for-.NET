using System.Text;

namespace Aspose.Cells.API.Models
{
    public class TranslationErrorResponse : AsposeResponse
    {
        public string Message { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TranslationErrorResponse {\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}