using System;
using System.Collections.Generic;
using System.Globalization;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Controllers;

namespace Aspose.Cells.Common.Models
{
    public class ResourcesModel
    {
        private ResourcesModel(
            UIControllerBase controller,
            string extension,
            string product
        )
        {
            Applications = controller?.Applications;
            Resources = controller?.Resources;
            Product = product;
            Extension1 = extension;
        }

        private string FindKey(string method, string key, bool force = false)
        {
            if (Resources?.ContainsKey($"{Product}{method}{key}") == true)
                return $"{Product}{method}{key}";

            if (Resources?.ContainsKey($"{Product}{key}") == true)
                return $"{Product}{key}";

            if (Resources?.ContainsKey($"{method}{key}") == true)
                return $"{method}{key}";

            if (Resources?.ContainsKey($"{key}") == true)
                return $"{key}";

            if (force)
                throw new KeyNotFoundException($"The given key '{key}' was not present in the Resources.");

            return null;
        }

        public FlexibleResources Resources { get; }

        public string Product { get; }

        public string ProductFiles
        {
            get
            {
                switch (Product)
                {
                    case "slides":
                        return "PowerPoint";
                    default:
                        throw new ArgumentException($"Unknown product {Product}");
                }
            }
        }

        public string Method { get; }

        public string PageProductTitle => Resources["Aspose" + TitleCase(Product)];

        public string EmailTo { get; set; }

        public string Description { get; set; }
        private string PageTitleKey { get; set; }
        private string MetaDescriptionKey { get; set; }

        public string SeoPageTitle { get; set; }
        public string SeoMetaDescription { get; set; }

        public string HowToTitle { get; set; }
        public List<string> HowToFeatures { get; set; }

        public string ProductTitleKey { get; set; }
        public string ProductTitleSubKey { get; set; }

        public string ProductTitle { get; set; }
        public string ProductTitleSub { get; set; }

        public string AnotherFileKey { get; set; }
        public string SuccessMessageKey { get; set; }
        public string ButtonKey { get; set; }
        public string Feature2 { get; set; }

        public List<string> AppFeatures { get; set; }

        public string AppUrlId { get; set; }
        public string Extension1 { get; set; }
        public string Extension1Upper => Extension1?.ToUpper();
        public string Extension1Lower => Extension1?.ToLower();

        public string Extension2 { get; set; }
        public string Extension2Upper => Extension2?.ToUpper();
        public string Extension2Lower => Extension2?.ToLower();

        public string Extension1Name { get; set; }
        public string Extension1Description { get; set; }
        public string Extension1DescriptionUrl { get; set; }

        public string Extension2Name { get; set; }
        public string Extension2Description { get; set; }
        public string Extension2DescriptionUrl { get; set; }
        public bool? IsMainGeneratedPage { get; set; }
        public GeneratedPages Generated1Pages { get; set; }
        public GeneratedPages Generated2Pages { get; set; }

        public GeneratedPages GeneratedCombined { get; set; }

        protected string TitleCase(string value) => new CultureInfo("en-US", false).TextInfo.ToTitleCase(value);

        public UploadFileModel UploadFile { get; set; }

        public string RawHtmlAtStartProductFooter { get; set; }
        public string RawHtmlBeforeHowToProductFooter { get; set; }

        public IEnumerable<AnotherApp> Applications { get; set; }

        public string ExtensionsString
        {
            get
            {
                if (Resources == null)
                    return null;

                var key1 = $"{Product}ValidationExpression";
                var key2 = $"{Product}{Method}ValidationExpression";
                var ext = Resources.ContainsKey(key1) ? Resources[key1] : Resources[key2];
                return ext;
            }
        }

        public string this[string key]
        {
            get
            {
                var foundKey = FindKey(Method, key, true);
                return Resources[foundKey];
            }
        }
    }
}