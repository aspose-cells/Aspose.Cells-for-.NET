using System.Linq;
using Newtonsoft.Json;

namespace Aspose.Cells.UI.Models
{
    public class Breadcrumb
    {
        public static string GenerateJson(params (string Name, string Href)[] nameHrefPairs)
        {
            var i = 1;

            return JsonConvert.SerializeObject(new Breadcrumb
            {
                Context = @"https://schema.org",
                Type = "BreadcrumbList",
                Items = nameHrefPairs.Select(x => new ItemListElement
                {
                    Position = i++,
                    Type = "ListItem",
                    Name = x.Name,
                    Item = x.Href
                }).ToArray()
            });
        }

        [JsonProperty("@context")] public string Context { get; set; }

        [JsonProperty("@type")] public string Type { get; set; }

        [JsonProperty("itemListElement")] public ItemListElement[] Items { get; set; }
    }

    public class ItemListElement
    {
        [JsonProperty("@type")] public string Type { get; set; }

        [JsonProperty("position")] public int Position { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("item")] public string Item { get; set; }
    }
}