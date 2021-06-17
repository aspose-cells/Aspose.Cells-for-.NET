using Newtonsoft.Json;
using System.Collections.Generic;

namespace Aspose.Cells.Common.Models.SEO
{
    public abstract class SeoElement
	{
		[JsonProperty("@context")]
		public virtual string Context { get; set; } = "https://schema.org";

		[JsonProperty("@type")]
		public virtual string Type { get; set; }

		[JsonProperty("@id")]
		public virtual string Id { get; set; }
	}

	public class Thing: SeoElement
	{
		[JsonProperty("@type")]
		public override string Type { get; set; } = "Thing";

		[JsonProperty("name")]
		public virtual string Name { get; set; }

		[JsonProperty("alternateName")]
		public virtual string AlterName { get; set; }

		[JsonProperty("description")]
		public virtual string Description { get; set; }

		[JsonProperty("image")]
		public virtual ImageObject Image { get; set; }

		[JsonProperty("url")]
		public URL Url { get; set; }
	}

	public class CreativeWork: Thing
	{
		[JsonProperty("@type")]
		public override string Type { get; set; } = "CreativeWork";

		[JsonProperty("thumbnailUrl")]
		public string [] ThumbnailUrl { get; set; }

		[JsonProperty("datePublished")]
		public string DatePublished { get; set; }


	}
}
