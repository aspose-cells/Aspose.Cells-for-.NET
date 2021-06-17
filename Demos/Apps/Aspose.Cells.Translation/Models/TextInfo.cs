using System.Text;
using Newtonsoft.Json;

namespace Aspose.Cells.Translation.Models
{
    public class TextInfo
    {
        [JsonProperty("pair")] public string Pair { get; set; }

        [JsonProperty("text")] public string Text { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TextInfo {\n");
            sb.Append("  Pair: ").Append(Pair).Append("\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}