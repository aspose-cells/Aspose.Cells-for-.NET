using Aspose.Cells.UI.Models.SEO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Aspose.Cells.UI.Models
{
    public class SoftwareApplication:CreativeWork
    {
		[JsonProperty("@type")]
		public override string Type { get; set; } = "SoftwareApplication";

		[JsonProperty("creator")]
		public Organization Creator { get; set; } = new Organization();

		[JsonProperty("applicationCategory")]
		public string[] ApplicationCategory { get; set; } = new string[] { "WebApplication", "BusinessApplication", "BrowserApplication" };

		[JsonProperty("downloadUrl")]
		public string DownloadUrl { get; set; }

		[JsonProperty("operatingSystem")]
		public string[] OperatingSystem { get; set; } = new string[] { "Windows, iOS, Linux, Android" };

		[JsonProperty("softwareVersion")]
		public string SoftwareVersion { get; set; } = "20.7.0";

		[JsonProperty("softwareHelp")]
		public string SoftwareHelp { get; set; }

		[JsonProperty("softwareRequirements")]
		public URL SoftwareRequirements { get; set; }

		[JsonProperty("offers")]
		public Offer Offer { get; set; } = new Offer();

		//[JsonProperty("aggregateRating")]
		//public AggregateRating AggregateRating { get; set; } = new AggregateRating()
		//{
		//	Type = "AggregateRating",
		//	WorstRating = "1",
		//	BestRating = "5",
		//	RatingValue = "4.6",
		//	ReviewCount = (Int32.Parse(DateTime.Now.ToString("yyMMdd")) - 199000).ToString(),
		//	RatingCount = DateTime.Now.ToString("yyMMdd")
		//};
	}

    public class Offer
    {
		[JsonProperty("@type")]
		public string Type { get; set; } = "Offer";

		[JsonProperty("price")]
		public float Price { get; set; } = 0.00f;

		[JsonProperty("priceCurrency")]
		public string PriceCurrency { get; set; } = "USD";

	}

}
