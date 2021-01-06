using Newtonsoft.Json;

namespace Aspose.Cells.UI.Models.SEO
{
    public class WebApplication : SoftwareApplication
    {
        [JsonProperty("@type")] public override string Type { get; set; } = "WebApplication";

        [JsonProperty("browserRequirements")] public string BrowserRequirements { get; set; } = "This web application no need any requirements to Browser. You can use it in any browser.";
    }
}