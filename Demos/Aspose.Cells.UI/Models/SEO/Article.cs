using Newtonsoft.Json;

namespace Aspose.Cells.UI.Models.SEO
{
    public class Article : SeoElement
    {
        [JsonProperty("@type")] public override string Type { get; set; } = "Article";

        [JsonProperty("text")] public string Text { get; set; }

        [JsonProperty("author")] public string Author { get; set; }

        [JsonProperty("datePublished")] public string DatePublished { get; set; }

        [JsonProperty("headline")] public string HeadLine { get; set; }

        [JsonProperty("image")] public string Image { get; set; }

        [JsonProperty("publisher")] public string Publisher { get; set; }

        [JsonProperty("dateModified")] public string DateModified { get; set; }

        [JsonProperty("mainEntityOfPage")] public string MainEntityOfPage { get; set; }
    }
}