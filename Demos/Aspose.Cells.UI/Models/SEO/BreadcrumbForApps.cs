using Newtonsoft.Json;
using System.Collections.Generic;

namespace Aspose.Cells.UI.Models.SEO
{
    public class BreadcrumbForApps : Thing
    {
        [JsonProperty("@type")] public override string Type { get; set; } = "BreadcrumbList";

        [JsonProperty("name")] public override string Name { get; set; } = "breadcrumbList";

        [JsonProperty("itemListElement")] public List<ListItemForApp> Items { get; set; } = new List<ListItemForApp>();
    }

    public class ListItemForApp : SeoElement
    {
        [JsonProperty("@type")] public override string Type { get; set; } = "ListItem";

        [JsonProperty("position")] public int Position { get; set; }

        [JsonProperty("item")] public Item Item { get; set; }
    }

    public class Item
    {
        [JsonProperty("@id")] public string Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
    }
}