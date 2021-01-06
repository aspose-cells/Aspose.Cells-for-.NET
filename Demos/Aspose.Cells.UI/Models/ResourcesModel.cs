using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Aspose.Cells.UI.Config;
using Aspose.Cells.UI.Controllers;
using Aspose.Cells.UI.Services;

namespace Aspose.Cells.UI.Models
{
    public class ResourcesModel
    {
        private ResourcesModel(BaseController controller, string extension, string product)
        {
            Applications = controller?.Applications;
            Resources = controller?.Resources;
            Product = product;
            Extension1 = extension;

            EmailTo = controller?.Session["emailTo"]?.ToString();
        }

        public ResourcesModel(
            BaseController controller,
            string extension,
            string product,
            string method
        ) : this(controller, extension, product)
        {
            Method = method;

            PrepareKeyAndSeo(extension, method);
        }

        public ResourcesModel(
            BaseController controller,
            string extension,
            string product,
            string method,
            string method2
        ) : this(controller, extension, product)
        {
            Method = method;

            PrepareKeyAndSeo(extension, method2);
        }

        private void PrepareKeyAndSeo(
            string extension,
            string method
        )
        {
            GenerateKeys(method);
            SetupSEOValues(extension);
            PrepareUploadFileModel();
            PrepareFileFormats();
        }

        protected static FileFormatService _FileFormatService = new FileFormatService();
        public Dictionary<string, string> FileFormatUrls;

        private void PrepareFileFormats()
        {
            FileFormatUrls =
                _FileFormatService.GetAllCached()
                    .Where(f => f.Value != null)
                    .ToDictionary(
                        k => k.Key,
                        v => $"<a target=_blank href='{v.Value.FileFormatComUrl}'>{v.Key.ToUpper()}</a>"
                    );
        }

        private void GenerateKeys(string method)
        {
            ButtonKey = $"{method}Button";
            SuccessMessageKey = $"{method}SuccessMessage";
            AnotherFileKey = $"{method}AnotherFile";

            ProductTitleKey = Resources?.ContainsKey($"{Product}{method}H1") == true ? $"{Product}{method}H1" : $"{Product}{method}Title";

            ProductTitleSubKey = Resources?.ContainsKey($"{Product}{method}H4") == true ? $"{Product}{method}H4" : $"{Product}{method}TitleSub";

            PageTitleKey = Resources?.ContainsKey($"{Product}{method}PageTitle") == true ? $"{Product}{method}PageTitle" : ProductTitleKey;

            MetaDescriptionKey = Resources?.ContainsKey($"{Product}{method}MetaDescription") == true ? $"{Product}{method}MetaDescription" : ProductTitleSubKey;

            setValueWithKey(method, "RawHtmlAtStartProductFooter", v => RawHtmlAtStartProductFooter = v);
            setValueWithKey(method, "RawHtmlBeforeHowToProductFooter", v => RawHtmlBeforeHowToProductFooter = v);
        }

        void setValueWithKey(string method, string key, Action<string> setup, bool force = false)
        {
            var foundKey = FindKey(method, key, force);
            setup(foundKey != null ? Resources[foundKey] : null);
        }

        string FindKey(string method, string key, bool force = false)
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

        public string SEOPageTitle { get; set; }
        public string SEOMetaDescription { get; set; }

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

        public string AppURLID { get; set; }
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

        public string ProductsAsposeToolsURL => Configuration.ProductsAsposeToolsURL;

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

        public string QueryPlaceholderKey { get; internal set; }

        protected void SetupSEOValues(string extension)
        {
            SEOPageTitle = Resources?[PageTitleKey] ?? null;
            SEOMetaDescription = Resources?[MetaDescriptionKey] ?? null;

            if (extension == null)
            {
                if (SEOPageTitle != null)
                    SEOPageTitle = string.Format(SEOPageTitle, "Files");
            }
            else
            {
                if (SEOPageTitle != null)
                    SEOPageTitle = string.Format(SEOPageTitle, $"({extension.ToUpper()}) file");
            }

            var url = HttpContext.Current?.Request?.Url?.AbsolutePath?.ToLower();
            if (url != null)
                FetchSEOValues(url, extension);

            if (Resources == null)
                return;

            if (Resources.ContainsKey($"Howto{Method}Title"))
            {
                var howToApp = $"{PageProductTitle} {Resources[$"{Method}APPName"]}";
                HowToTitle = string.Format(Resources[$"Howto{Method}Title"], Extension1Upper, howToApp);
            }

            HowToFeatures = new List<string>();
            var i = 1;
            var howToFeatureKey = $"Howto{Method}Feature{i}";
            while (Resources.ContainsKey(howToFeatureKey))
            {
                var template = Resources[howToFeatureKey];
                var howTo = string.Format(template, Extension1Upper, Extension2Upper);
                HowToFeatures.Add(howTo);
                i++;
                howToFeatureKey = $"Howto{Method}Feature{i}";
            }

            AppFeatures = new List<string>();

            i = 1;
            while (Resources.ContainsKey($"{Product}{Method}LiFeature{i}"))
                AppFeatures.Add(Resources[$"{Product}{Method}LiFeature{i++}"]);

            if (AppFeatures.Count != 0) return;
            i = 1;
            while (Resources.ContainsKey($"{Method}LiFeature{i}"))
            {
                if (!Resources[$"{Method}LiFeature{i}"].Contains("Instantly download") || AppFeatures.Count == 0)
                    AppFeatures.Add(Resources[$"{Method}LiFeature{i}"]);
                i++;
            }
        }

        protected void FetchSEOValues(string url, string extension)
        {
            var generatedPage = new GeneratedPage(url).GetByURL();
            string pureAppExtension = null;
            if (string.IsNullOrEmpty(generatedPage?.Extension1))
            {
                generatedPage = new GeneratedPage(url).GetByAppURL();
                pureAppExtension = generatedPage?.Extension1;
                Extension1 = null;
                Extension2 = null;
            }
            else
            {
                Extension1 = generatedPage.Extension1;
                Extension2 = generatedPage.Extension2;
            }

            if (string.IsNullOrEmpty(generatedPage?.Extension1))
            {
                if (extension != null)
                    throw new HttpException(404, "Not found");
                return;
            }

            if (string.IsNullOrEmpty(Extension1))
                Extension1 = null;
            if (string.IsNullOrEmpty(Extension2))
                Extension2 = null;

            AppURLID = generatedPage?.App_URL_ID;

            if (!string.IsNullOrWhiteSpace(generatedPage?.Header1)
                && !generatedPage.Header1.Contains("Header")
                && string.IsNullOrWhiteSpace(pureAppExtension)
            )
                SEOPageTitle = generatedPage.Header1;

            if (!string.IsNullOrWhiteSpace(generatedPage?.Header2)
                && !generatedPage.Header2.Contains("Header")
                && string.IsNullOrWhiteSpace(pureAppExtension)
            )
                SEOMetaDescription = generatedPage.Header2;

            if (url.StartsWith("/"))
                IsMainGeneratedPage = generatedPage.App_url == url.Substring(1);
            else
                IsMainGeneratedPage = generatedPage.App_url == url;

            if (pureAppExtension != null)
            {
                if (AppURLID != null)
                {
                    Generated1Pages = new GeneratedPage(pureAppExtension, AppURLID, true).GetByAppIDandNotExtension();
                    IsMainGeneratedPage = true;
                }
            }
            else
            {
                if (Extension1 != null)
                {
                    ProductTitle = string.Format(generatedPage.MainHeadline, Extension1Upper, Extension2Upper);
                    ProductTitleSub = string.Format(generatedPage.SubHeadline, Extension1Upper, Extension2Upper);

                    var fileFormat1 = new FileFormat(Extension1Lower).GetByExtension();
                    Extension1Name = fileFormat1?.Name;
                    Extension1Description = fileFormat1?.Description;
                    Extension1DescriptionUrl = fileFormat1?.FileFormat_Com_URL;
                    if (AppURLID != null)
                        Generated1Pages = new GeneratedPage(Extension1, AppURLID, true).GetByAppIDandNotExtension();
                }

                if (Extension2 != null)
                {
                    var fileFormat2 = new FileFormat(Extension2Lower).GetByExtension();
                    Extension2Name = fileFormat2?.Name;
                    Extension2Description = fileFormat2?.Description;
                    Extension2DescriptionUrl = fileFormat2?.FileFormat_Com_URL;
                    if (AppURLID != null)
                        Generated2Pages = new GeneratedPage(Extension2, AppURLID, true).GetByAppIDandNotExtension();
                }
            }

            var combined =
                (Generated1Pages ?? new GeneratedPages())
                .Concat
                    (Generated2Pages ?? new GeneratedPages());

            var result = combined
                .Select(
                    c => new
                    {
                        c.MainHeadline,
                        c.SubHeadline,
                        c.URL,
                        c.Name,
                        c.Extension1,
                        c.Header1,
                        c.Extension2,
                        c.App_URL_ID,
                        c.Header2,
                    }
                )
                .Distinct()
                .Select(
                    c => new GeneratedPage
                    {
                        MainHeadline = c.MainHeadline,
                        SubHeadline = c.SubHeadline,
                        URL = c.URL,
                        Name = c.Name,
                        Extension1 = c.Extension1,
                        Header1 = c.Header1,
                        Extension2 = c.Extension2,
                        App_URL_ID = c.App_URL_ID,
                        Header2 = c.Header2,
                    }
                ).ToList();

            GeneratedCombined = new GeneratedPages();
            GeneratedCombined.AddRange(result);
        }

        private void PrepareUploadFileModel()
        {
            UploadFile = new UploadFileModel(Resources)
            {
                FileDropKey = "DropAFile",
                AcceptMultipleFiles = false,
                AcceptedExtentions = ExtensionsString?.Replace("|.", ",."),
            };
        }

        public bool KeyExists(string key) => FindKey(Method, key) != null;

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