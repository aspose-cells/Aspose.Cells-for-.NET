using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.Cells.Common.Models.SEO
{
    public class LocalBusiness:SeoElement
    {		
		[JsonProperty("@type")]
		public override string Type { get; set; } = "LocalBusiness";

		[JsonProperty("name")]
		public string Name { get; set; } = "Aspose Pty Ltd";

		[JsonProperty("image")]
		public string Image { get; set; } //= "https://joomla-asposeapp.dynabic.com/templates/asposeapp/images/product-family/aspose-cells-app.png";

		[JsonProperty("telephone")]
		public string Telephone { get; set; } = "+19033061676";

		[JsonProperty("aggregateRating")]
		public AggregateRating AggregateRating { get; set; } = new AggregateRating();

		[JsonProperty("address")]
		public Adress Adress { get; set; } = new Adress();

		[JsonProperty("priceRange")]
		public string PriceRange { get; set; } = "$$";

		[JsonProperty("url")]
		public string Url { get; set; } = "https://www.aspose.com/";
	}
}
