using System.Collections.Generic;
using Newtonsoft.Json;

namespace Aspose.Cells.UI.Models.SEO
{
    public class Organization : SeoElement
    {
        [JsonProperty("@type")] public override string Type { get; set; } = "Organization";

        [JsonProperty("name")] public string Name { get; set; } = "Aspose Pty Ltd";

        [JsonProperty("alternateName")] public string AltName { get; set; } = "Aspose Pty Ltd";

        [JsonProperty("legalName")] public string LegalName { get; set; }

        [JsonProperty("taxID")] public string taxID { get; set; }

        [JsonProperty("vatID")] public string vatID { get; set; }

        [JsonProperty("logo")] public ImageObject Logo { get; set; } = new ImageObject {Url = new URL {Id = "https://cms.admin.containerize.com/templates/aspose/App_Themes/V3/images/aspose-logo.png"}, Height = "300", Width = "600"};

        [JsonProperty("url")] public string Url { get; set; } = "https://www.aspose.com/";

        [JsonProperty("address")] public Adress Adress { get; set; } = new Adress();

        [JsonProperty("email")] public string Email { get; set; } = "mailto:sales@aspose.com";

        [JsonProperty("sameAs")]
        public string[] SameAs { get; set; } =
        {
            "https://www.facebook.com/aspose",
            "https://twitter.com/aspose",
            "https://www.youtube.com/channel/UCoKbPb28Htp4MUiLtW3CT9g",
            "https://au.linkedin.com/company/asposeapp"
        };

        [JsonProperty("contactPoint")]
        public List<ContactPoint> Contact { get; set; } = new List<ContactPoint>
        {
            new ContactPoint
            {
                Areas = new[] {"USA"},
                ContactOption = "http://schema.org/TollFree",
                ContactType = new[] {"customer service", "technical support", "billing support", "bill payment", "credit card support"},
                Languages = new[] {"English"},
                Telephone = "+19033061676",
            },
            new ContactPoint
            {
                Areas = new[] {"Europe"},
                ContactOption = "http://schema.org/TollFree",
                ContactType = new[] {"customer service", "technical support", "billing support", "bill payment", "credit card support"},
                Languages = new[] {"English"},
                Telephone = "+441416288900",
            },
            new ContactPoint
            {
                Areas = new[] {"Australia"},
                ContactOption = "http://schema.org/TollFree",
                ContactType = new[] {"customer service", "technical support", "billing support", "bill payment", "credit card support"},
                Languages = new[] {"English"},
                Telephone = "+61280066987"
            }
        };

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("award")] public string[] Award { get; set; } = {"Top 5 Best Selling Publisher Award 2012"};
    }

    public class ContactPoint : SeoElement
    {
        [JsonProperty("@type")] public override string Type { get; set; } = "ContactPoint";

        [JsonProperty("telephone")] public string Telephone { get; set; }

        [JsonProperty("contactType")] public string[] ContactType { get; set; }

        [JsonProperty("contactOption")] public string ContactOption { get; set; } = "http://schema.org/TollFree";

        [JsonProperty("areaServed")] public string[] Areas { get; set; }

        [JsonProperty("availableLanguage")] public string[] Languages { get; set; }
    }

    public class Adress : SeoElement
    {
        [JsonProperty("@type")] public override string Type { get; set; } = "PostalAddress";

        [JsonProperty("addressLocality")] public string AdressLocality { get; set; } = "Lane Cove, NSW";

        [JsonProperty("postalCode")] public string postalCode { get; set; } = "2066, Australia";

        [JsonProperty("streetAddress")] public string StreetAdress { get; set; } = "Suite 163, 79 Longueville Road, Lane Cove";
    }
}