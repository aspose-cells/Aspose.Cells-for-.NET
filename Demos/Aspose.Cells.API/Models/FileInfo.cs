using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Aspose.Cells.API.Models
{
    public class FileInfo
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("folder")] public string Folder { get; set; }

        [JsonProperty("storage")] public string Storage { get; set; }

        [JsonProperty("format")] public string Format { get; set; }

        [JsonProperty("outformat")] public string OutFormat { get; set; }

        [JsonProperty("savepath")] public string SavePath { get; set; }

        [JsonProperty("savefile")] public string SaveFile { get; set; }

        [JsonProperty("pair")] public string Pair { get; set; }

        [JsonProperty("masters")] public bool Masters { get; set; }

        [JsonProperty("elements")] public List<int> Elements { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FileInfo {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Folder: ").Append(Folder).Append("\n");
            sb.Append("  Storage: ").Append(Storage).Append("\n");
            sb.Append("  Format: ").Append(Format).Append("\n");
            sb.Append("  OutFormat: ").Append(OutFormat).Append("\n");
            sb.Append("  SavePath: ").Append(SavePath).Append("\n");
            sb.Append("  SaveFile: ").Append(SaveFile).Append("\n");
            sb.Append("  Pair: ").Append(Pair).Append("\n");
            sb.Append("  Masters: ").Append(Masters).Append("\n");
            sb.Append("  Elements: ").Append(Elements).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}