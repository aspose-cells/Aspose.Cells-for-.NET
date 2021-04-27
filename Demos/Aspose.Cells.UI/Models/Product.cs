using Newtonsoft.Json;

namespace Aspose.Cells.UI.Models
{
	public class Product
    {
		[JsonProperty("@context")]
		public string Context { get; set; }

		[JsonProperty("@type")]
		public string Type { get; set; }

		[JsonProperty("brand")]
        public string Brand { get; set; }

		[JsonProperty("name")]
        public string Name { get; set; }

		[JsonProperty("image")]
        public string Image { get; set; }

		[JsonProperty("description")]
        public string Description { get; set; }

		[JsonProperty("category")]
        public string Category { get; set; }

		[JsonProperty("aggregateRating")]
		public AggregateRating AggregateRating { get; set; }
		
	}
	public class AggregateRating
	{
		[JsonProperty("@type")]
		public string Type { get; set; }

		[JsonProperty("worstRating")]
		public string WorstRating { get; internal set; }

		[JsonProperty("bestRating")]
		public string BestRating { get; internal set; }

		[JsonProperty("ratingValue")]
		public string RatingValue { get; internal set; }

		[JsonProperty("ratingCount")]
		public string RatingCount { get; internal set; }

        [JsonProperty("reviewCount")]
        public string ReviewCount { get; internal set; }

    }
}
