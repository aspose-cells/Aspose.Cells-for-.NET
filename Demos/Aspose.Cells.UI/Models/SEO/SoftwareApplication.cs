using Newtonsoft.Json;

namespace Aspose.Cells.UI.Models.SEO
{
    public class SoftwareApplication : CreativeWork
    {
        [JsonProperty("@type")] public override string Type { get; set; } = "SoftwareApplication";

        [JsonProperty("creator")] public Organization Creator { get; set; } = new Organization();

        [JsonProperty("applicationCategory")] public string[] ApplicationCategory { get; set; } = {"WebApplication", "BusinessApplication", "BrowserApplication"};

        [JsonProperty("downloadUrl")] public string DownloadUrl { get; set; }

        [JsonProperty("operatingSystem")] public string[] OperatingSystem { get; set; } = {"Windows, iOS, Linux, Android"};

        [JsonProperty("softwareVersion")] public string SoftwareVersion { get; set; } = "20.7.0";

        [JsonProperty("softwareHelp")] public string SoftwareHelp { get; set; }

        [JsonProperty("softwareRequirements")] public URL SoftwareRequirements { get; set; }

        [JsonProperty("offers")] public Offer Offer { get; set; } = new Offer();
    }

    public class Offer
    {
        [JsonProperty("@type")] public string Type { get; set; } = "Offer";

        [JsonProperty("price")] public float Price { get; set; }

        [JsonProperty("priceCurrency")] public string PriceCurrency { get; set; } = "USD";
    }
}