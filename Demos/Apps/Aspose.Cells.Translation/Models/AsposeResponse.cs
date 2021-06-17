using System.Text;

namespace Aspose.Cells.Translation.Models
{
    public class AsposeResponse
    {
        public System.Net.HttpStatusCode Code { get; set; }

        public string Status { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AsposeResponse {\n");
            sb.Append("  Code: ").Append(this.Code).Append("\n");
            sb.Append("  Status: ").Append(this.Status).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}