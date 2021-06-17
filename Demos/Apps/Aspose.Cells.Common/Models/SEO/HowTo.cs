using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Aspose.Cells.Common.Models.SEO
{
    public class HowTo : CreativeWork
    {
        public HowTo(HowToModel HowToModel, string TitleSub, string Title)
        {
            Name = HowToModel.Title;
            Description = Title;
            Supply = new HowToSupply[] { new HowToSupply(TitleSub) };
            List<HowToStep> steps = new List<HowToStep>();
            if (HowToModel.List != null && HowToModel.List.Count > 0)
            {
                int i = 1;
                foreach (HowToItem item in HowToModel.List)
                {
                    steps.Add(new HowToStep()
                    {
                        Name = item.Name,
                        Text = item.Text,
                        Position = i.ToString(),
                        Url = new URL() { Id = item.UrlPath },
                        Image = new ImageObject() { Url = new URL() { Id = item.ImageUrl } },
                    });
                    i++;
                }
            }

            Steps = steps.ToArray();
        }


        [JsonProperty("@type")]
        public override string Type { get; set; } = "HowTo";

        [JsonProperty("image")]
        public override ImageObject Image { get; set; } = new ImageObject()
        {
            Url = new URL() { Id = "https://products.aspose.app/img/howto.png" },
            Width = "280",
            Height = "200"
        };

        [JsonProperty("estimatedCost")]
        public MonetaryAmount EstimatedCost { get; set; } = new MonetaryAmount();

        [JsonProperty("totalTime")]
        public string TotalTime { get; set; } = "PT1M";

        [JsonProperty("tool")]
        public HowToTool Tool { get; set; } = new HowToTool();

        [JsonProperty("supply")]
        public HowToSupply[] Supply { get; set; }

        [JsonProperty("step")]
        public HowToStep[] Steps { get; set; }
    }

    public class HowToStep : CreativeWork
    {
        [JsonProperty("@type")]
        public override string Type { get; set; } = "HowToStep";

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class HowToTool : SeoElement
    {
        [JsonProperty("@type")]
        public override string Type { get; set; } = "HowToTool";

        [JsonProperty("name")]
        public string Name { get; set; } = "A Web browser";
    }

    public class HowToSupply
    {
        public HowToSupply(string name)
        {
            Name = name;
        }

        [JsonProperty("@type")]
        public string Type { get; set; } = "HowToSupply";

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ImageObject : SeoElement
    {
        [JsonProperty("@type")]
        public override string Type { get; set; } = "ImageObject";

        [JsonProperty("url")]
        public URL Url { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }
    }

    public class MonetaryAmount : SeoElement
    {
        [JsonProperty("@type")]
        public override string Type { get; set; } = "MonetaryAmount";

        [JsonProperty("currency")]
        public string Currency { get; set; } = "USD";

        [JsonProperty("value")]
        public string Value { get; set; } = "0";
    }

    public class URL : SeoElement
    {
        [JsonProperty("@type")]
        public override string Type { get; set; } = "URL";
    }
}
