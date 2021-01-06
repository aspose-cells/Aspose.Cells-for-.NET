using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.WebPages;
using Newtonsoft.Json;
using Aspose.Cells.UI.Config;
using Aspose.Cells.UI.Controllers;
using Aspose.Cells.UI.Models.SEO;
using Tools.Foundation.Models;

namespace Aspose.Cells.UI.Models
{
    public class ViewModel
    {
        public const int MaximumUploadFiles = 10;

        public const int MaxsizeUploadFile = 5;

        /// <summary>
        /// String for using in titles, meta description and headers.
        /// "Excel"
        /// </summary>
        public const string cellsDefaultTitleAddition = "Excel";

        /// <summary>
        /// Name of the product (e.g., words)
        /// </summary>
        public string Product { get; set; }

        public BaseController Controller;

        /// <summary>
        /// Product + AppName, e.g. wordsMerger
        /// </summary>
        public string ProductAppName { get; set; }

        public FlexibleResources Resources { get; set; }

        public string APIBasePath => Configuration.AsposeToolsAPIBasePath;

        public string PageProductTitle => Resources["Aspose" + TitleCase(Product)];
        public string PageProductTitleURL => "<a href=\"https://products.aspose.com/cells\">Aspose.Cells</a>";

        public string PageAppName
        {
            get
            {
                var res = AppName;
                if ("xfa".Equals(AppName, StringComparison.InvariantCultureIgnoreCase))
                {
                    res = "Xfa to Acroform converter";
                }

                return res;
            }
        }

        public string EmailTo { get; set; }

        /// <summary>
        /// The name of the app (e.g., Conversion, Merger)
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// The full address of the application without query string (e.g., https://products.aspose.app/words/conversion)
        /// </summary>
        public string AppURL { get; set; }

        /// <summary>
        /// The full address of the application without query string (e.g., https://products.aspose.app/words/conversion)
        /// </summary>
        public string AppRoute => new Uri(AppURL).PathAndQuery;


        /// <summary>
        /// File extension without dot received by "fileformat" value in RouteData (e.g. docx)
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// File extension without dot received by "fileformat" value in RouteData (e.g. docx)
        /// </summary>
        public string Extension2 { get; set; }

        /// <summary>
        /// Redirect to main app, if there is no ExtensionInfoModel for auto generated models
        /// </summary>
        public bool RedirectToMainApp { get; set; }

        /// <summary>
        /// Is canonical page opened (/all)
        /// </summary>
        public bool IsCanonical;

        /// <summary>
        /// Name of the partial View of controls (e.g. SignatureControls)
        /// </summary>
        public string ControlsView { get; set; }

        public string AnotherFileText { get; set; }
        public string CellsAnotherFileText { get; set; }
        public string CellsWatermarkSuccessMessage { get; set; }
        public string UploadButtonText { get; set; }
        public string ViewerButtonText { get; set; }
        public string DeleteButtonText { get; set; }
        public bool ShowViewerButton { get; set; }
        public bool ShowDeleteButton { get; set; }
        public string SuccessMessage { get; set; }

        /// <summary>
        /// List of app features for ul-list. E.g. Resources[app + "LiFeature1"]
        /// </summary>
        public List<string> AppFeatures { get; set; }

        public string Title { get; set; }
        public string TitleSub { get; set; }


        public string PageTitle
        {
            get => Controller.ViewBag.PageTitle;
            set => Controller.ViewBag.PageTitle = value;
        }

        public string MetaDescription
        {
            get => Controller.ViewBag.MetaDescription;
            set => Controller.ViewBag.MetaDescription = value;
        }

        public string MetaKeywords
        {
            get => Controller.ViewBag.MetaKeywords;
            set => Controller.ViewBag.MetaKeywords = value;
        }

        public string HtmlLocale
        {
            get => Controller.ViewBag.HtmlLocale;
            set => Controller.ViewBag.HtmlLocale = value;
        }

        /// <summary>
        /// If the application doesn't need to upload several files (e.g. Viewer, Editor)
        /// </summary>
        public bool UploadAndRedirect { get; set; }

        protected string TitleCase(string value) => new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(value);

        /// <summary>
        /// e.g., .doc|.docx|.dot|.dotx|.rtf|.odt|.ott|.txt|.html|.xhtml|.mhtml
        /// </summary>
        public string ExtensionsString { get; set; }

        #region SaveAs

        private bool _saveAsComponent;

        public virtual bool SaveAsComponent
        {
            get => _saveAsComponent;
            set
            {
                _saveAsComponent = value;
                Controller.ViewBag.SaveAsComponent = value;

                if (!_saveAsComponent) return;

                var smokey1 = $"{Product}{AppName}SaveAsOptions";

                if (Resources.ContainsKey(smokey1))
                {
                    switch (AppName)
                    {
                        case "Chart":
                            var lst = Resources[smokey1].Split(',').ToList();
                            try
                            {
                                if (!string.IsNullOrEmpty(Extension2))
                                {
                                    var index = lst.FindIndex(x => x.Trim() == Extension2.ToUpper());
                                    if (index >= 0)
                                    {
                                        lst.RemoveAt(index);
                                        lst.Insert(0, Extension2.ToUpper());
                                    }
                                }
                            }
                            catch
                            {
                                //
                            }
                            finally
                            {
                                SaveAsOptions = lst.ToArray();
                            }

                            break;

                        default:
                            SaveAsOptions = Resources[smokey1].Split(',');
                            break;
                    }
                }

                if (AppFeatures == null) return;

                var lifeAcuteKey = Product + "SaveAsLiFeature";
                var ligatureExt = Product + "SaveAsLiFeatureExt";

                if (Resources.ContainsKey(ligatureExt))
                {
                    var str = new StringBuilder();
                    foreach (var ext in SaveAsOptions)
                    {
                        var extTrim = ext.Trim();
                        str.Append(FileFormatLinks.ContainsKey(extTrim)
                            ? $"<a target=\"_blank\" href=\"{FileFormatLinks[extTrim]}\">{extTrim}</a>, "
                            : $"{extTrim}, ");
                    }

                    str.Remove(str.Length - 2, 2);
                    // str.Append(" ");
                    AppFeatures.Insert(1, string.Format(Resources[ligatureExt], str));
                }
                else if (Resources.ContainsKey(lifeAcuteKey))
                    AppFeatures.Add(Resources[lifeAcuteKey]);
            }
        }

        /// <summary>
        /// FileFormats in UpperCase
        /// </summary>
        public string[] SaveAsOptions { get; set; }

        /// <summary>
        /// Original file format SaveAs option for multiple files uploading
        /// </summary>
        public bool SaveAsOriginal { get; set; }

        #endregion

        /// <summary>
        /// The possibility of changing the order of uploaded files. It is actual for Merger App.
        /// </summary>
        public bool UseSorting { get; set; }

        #region ViewSections

        public bool ShowExtensionInfo => ExtensionInfoModel != null;
        public ExtensionInfoModel ExtensionInfoModel { get; set; }
        public bool ShowExtensionInfo2 => ExtensionInfoModel2 != null;
        public ExtensionInfoModel ExtensionInfoModel2 { get; set; }

        public bool ShowOtherFeatures => OtherFeaturesModel != null;
        public OtherFeaturesModel OtherFeaturesModel { get; set; }

        public bool HowTo => HowToModel != null;
        public HowToModel HowToModel { get; set; }

        public GeneratedPage GeneratedPage { get; set; }

        public IEnumerable<AnotherApp> OtherApps { get; set; }

        #endregion

        public string JSOptions => new JSOptions(this).ToString();

        /// <summary>
        /// The possibility of main button working with no files uploaded
        /// </summary>
        public bool CanWorkWithoutFiles { get; set; }

        public bool DefaultFileBlockDisabled { get; set; }

        public ViewModel(BaseController controller, string app, string extension = null)
        {
            Controller = controller;
            Resources = controller.Resources;
            Extension = extension;
            AppName = Resources.ContainsKey($"{app}APPName") ? Resources[$"{app}APPName"] : app;
            Product = controller.Product;
            EmailTo = controller.Session["emailTo"]?.ToString();

            //var url = controller.Request.Url.AbsoluteUri;
            //fix for reverse proxy http://localhost/
            var url = Configuration.ProductsAsposeToolsURL + controller.Request.Url.PathAndQuery;
            AppURL = url.Substring(0, url.IndexOf("?", StringComparison.Ordinal) > 0 ? url.IndexOf("?", StringComparison.Ordinal) : url.Length);

            ProductAppName = Product + app;
            SetHtmlLocale();

            UploadButtonText = GetFromResources(ProductAppName + "Button");
            ViewerButtonText = GetFromResources(ProductAppName + "Viewer");
            SuccessMessage = GetFromResources(ProductAppName + "SuccessMessage");
            AnotherFileText = GetFromResources(ProductAppName + "AnotherFile");
            CellsAnotherFileText = GetFromResources(ProductAppName + "AnotherFile");
            CellsWatermarkSuccessMessage = GetFromResources(ProductAppName + "SuccessMessage");

            if (AppName.Equals("Merger"))
            {
                DeleteButtonText = GetFromResources(ProductAppName + "Delete");
            }

            InitOtherApps(Product.ToLower());
            SetExtensions();
            PrepareExtensionInfoModel();

            if (!IsSupportedExtensions(Extension, Extension2) && !AppName.Equals("Conversion") && !AppName.Equals("Merger"))
            {
                RedirectToMainApp = true;
                return;
            }

            PrepareOtherFeaturesModel();
            PrepareHowToModel();
            // PrepareFaqPageModel();

            SetTitles();
            SetAppFeatures(app);
            // PrepareBreadcrumbList();

            if (_otherAppsStatic.ContainsKey(Product))
                OtherApps = _otherAppsStatic[Product].Values;

            ShowViewerButton = true;
            SaveAsOriginal = true;
            SaveAsComponent = false;
            SetExtensionsString();
            AddFileFormatLinks();

            PrepareStructuralDataJson();
        }

        protected virtual void SetExtensions()
        {
            var routeValues = Controller.RouteData.Values;
            if (routeValues.ContainsKey("fileformat") && !string.IsNullOrEmpty(routeValues["fileformat"].ToString()))
            {
                var fileFormat = routeValues["fileformat"].ToString();
                if (fileFormat.Contains("-"))
                {
                    var values = fileFormat.Split('-');
                    Extension = values.First().ToLower();
                    Extension2 = values.Last().ToLower();
                }
                else
                    Extension = fileFormat.ToLower();

                if (Extension.Equals("excel"))
                {
                    Extension = "xlsx";
                }

                if (!Extension2.IsEmpty())
                {
                    if (Extension2.Equals("word"))
                    {
                        Extension2 = "docx";
                    }

                    if (Extension2.Equals("ppt") || Extension2.Equals("powerpoint"))
                    {
                        Extension2 = "pptx";
                    }
                }

                if (AppName.Equals("Chart"))
                {
                    if (Resources[ProductAppName + "SaveAsOptions"].Contains(Extension.ToUpper()))
                    {
                        Extension2 = Extension;
                        Extension = "xlsx";
                    }

                    if (Extension.Equals("image") || Extension.Equals("to") && Extension2.Equals("image"))
                    {
                        Extension = "xlsx";
                        Extension2 = "jpg";
                    }

                    if (Extension.Equals("to") && !Extension2.Equals("image"))
                    {
                        Extension = "xlsx";
                    }
                }

                try
                {
                    GeneratedPage = GeneratedPage.GetByURL(Controller.Request.Url.AbsolutePath.ToLower());
                }
                catch
                {
                    GeneratedPage = null;
                }
            }

            IsCanonical = string.IsNullOrEmpty(Extension);
        }

        private void PrepareExtensionInfoModel()
        {
            if (!string.IsNullOrEmpty(Extension) && !IsCanonical && Extension != "all")
                try
                {
                    ExtensionInfoModel = new ExtensionInfoModel(this, Extension);
                }
                catch // No generated extension info for this url
                {
                    ExtensionInfoModel = null;
                }

            if (string.IsNullOrEmpty(Extension2) || IsCanonical) return;

            try
            {
                ExtensionInfoModel2 = new ExtensionInfoModel(this, Extension2);
            }
            catch // No generated extension info for this url
            {
                ExtensionInfoModel2 = null;
            }
        }

        protected virtual void PrepareOtherFeaturesModel()
        {
            if (!Resources.ContainsKey(ProductAppName + "OtherFeaturesTitle")) return;

            try
            {
                OtherFeaturesModel = new OtherFeaturesModel(this);
            }
            catch // No other features for this page
            {
                OtherFeaturesModel = null;
            }
        }

        protected virtual void PrepareHowToModel()
        {
            if (string.IsNullOrEmpty(Extension) && !IsCanonical) return;

            try
            {
                HowToModel = new HowToModel(this);
            }
            catch
            {
                HowToModel = null;
            }
        }

        /// <summary>
        /// Returns Excel, Markdown
        /// </summary>
        /// <param name="extension"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        protected internal string DesktopAppNameByExtension(string extension, string defaultValue = null)
        {
            if (string.IsNullOrEmpty(extension)) return defaultValue;

            switch (extension.ToLower())
            {
                case "xlsx":
                    return "Excel";
                case "md":
                    return "Markdown";
                default:
                    return !string.IsNullOrEmpty(defaultValue) ? extension.ToUpper() : defaultValue;
            }
        }

        virtual public string this[string key]
        {
            get
            {
                var res = GetAppResourceOrDefault(key) ??
                          GetResourceOrDefault(key) ?? $"NoKey:{ProductAppName + key}";
                if (res.Contains("{"))
                {
                    res = string.Format(res, cellsDefaultTitleAddition);
                }

                return res;
            }
        }

        public string GetResourceOrDefault(string resourceName) => Resources.GetValueOrDefault(resourceName);
        public string GetAppResourceOrDefault(string resourceName) => Resources.GetValueOrDefault(ProductAppName + resourceName);

        private void SetHtmlLocale()
        {
            var locale = "en-us";
            if ("en".Equals(locale, StringComparison.InvariantCultureIgnoreCase))
                locale = "en-us";
            HtmlLocale = locale;
        }

        private void SetTitles()
        {
            SetTitles_Impl();
        }

        protected virtual void SetTitles_Impl()
        {
            // H1 and H4 texts are bad for SEO
            //Title = Resources.ContainsKey(pm + "H1") ? Resources[pm + "H1"] : Resources[pm + "Title"];
            //TitleSub = Resources.ContainsKey(pm + "H4") ? Resources[pm + "H4"] : Resources[pm + "TitleSub"];

            if (string.IsNullOrEmpty(Extension2))
            {
                if (string.IsNullOrEmpty(Title))
                    Title = Resources[ProductAppName + "Title"];
                if (string.IsNullOrEmpty(TitleSub))
                    TitleSub = Resources[ProductAppName + "TitleSub"];

                if (string.IsNullOrEmpty(PageTitle))
                    PageTitle = Resources.ContainsKey(ProductAppName + "PageTitle")
                        ? Resources[ProductAppName + "PageTitle"]
                        : Title;
                if (string.IsNullOrEmpty(MetaDescription))
                    MetaDescription = Resources.ContainsKey(ProductAppName + "MetaDescription")
                        ? Resources[ProductAppName + "MetaDescription"]
                        : Title;
                if (string.IsNullOrEmpty(MetaKeywords))
                    MetaKeywords = Resources.ContainsKey(ProductAppName + "MetaKeywords")
                        ? Resources[ProductAppName + "MetaKeywords"]
                        : "";

                var additional = cellsDefaultTitleAddition; // Excel
                if (!string.IsNullOrEmpty(Extension))
                {
                    additional = Extension.ToUpper();
                    // don't specify Extension2
                    //Extension2 = additional;
                }

                if (PageTitle.Contains("{"))
                    PageTitle = string.Format(PageTitle, additional);
                if (MetaDescription.Contains("{"))
                    MetaDescription = string.Format(MetaDescription, additional);
                if (Title.Contains("{"))
                    Title = string.Format(Title, additional);
                if (TitleSub.Contains("{"))
                    TitleSub = string.Format(TitleSub, additional);
            }
            else // Extension2
            {
                var additional = Extension.ToUpper();
                var additional2 = Extension2.ToUpper();

                PageTitle = string.Format(Resources[ProductAppName + "PageTitle2"], additional, additional2);
                MetaDescription = string.Format(Resources[ProductAppName + "MetaDescription2"], additional, additional2);
                MetaKeywords = Resources.ContainsKey(ProductAppName + "MetaKeywords2")
                    ? string.Format(Resources[ProductAppName + "MetaKeywords2"], additional, additional2)
                    : "";
                Title = string.Format(Resources[ProductAppName + "Title2"], additional, additional2);
                TitleSub = string.Format(Resources[ProductAppName + "TitleSub2"], Extension.ToUpper(), additional2);
            }

            Controller.ViewBag.CanonicalTag = null;
        }

        protected virtual void SetAppFeatures(string app)
        {
            AppFeatures = new List<string>();

            var i = 1;
            while (Resources.ContainsKey($"{ProductAppName}LiFeature{i}"))
                AppFeatures.Add(Resources[$"{ProductAppName}LiFeature{i++}"]);

            // Stop other developers to add unnecessary features.
            if (AppFeatures.Count != 0) return;
            i = 1;
            while (Resources.ContainsKey($"{app}LiFeature{i}"))
            {
                if (!Resources[$"{app}LiFeature{i}"].Contains("Instantly download") || AppFeatures.Count == 0)
                    AppFeatures.Add(Resources[$"{app}LiFeature{i}"]);
                i++;
            }
        }


        private string GetFromResources(string key, string defaultKey = null)
        {
            if (Resources.ContainsKey(key))
                return Resources[key];
            if (!string.IsNullOrEmpty(defaultKey) && Resources.ContainsKey(defaultKey))
                return Resources[defaultKey];
            return "";
        }

        protected virtual void SetExtensionsString()
        {
            if (!ShowExtensionInfo)
            {
                var key1 = $"{ProductAppName}ValidationExpression";
                // var key2 = $"{Product}ValidationExpression";
                // ExtensionsString = Resources.ContainsKey(key1) ? Resources[key1] : Resources[key2];
                ExtensionsString = Resources[key1];
            }
            else
            {
                switch (Extension)
                {
                    case "doc":
                    case "docx":
                        ExtensionsString = ".docx|.doc";
                        break;
                    /*case "html":
                    case "htm":
                    case "mhtml":
                    case "mht":
                        ExtensionsString = ".htm|.html|.mht|.mhtml";
                        break;*/
                    default:
                        ExtensionsString = $".{Extension}";
                        break;
                }

                if (AppName == "Comparison" && !string.IsNullOrEmpty(Extension2))
                    ExtensionsString += $"|.{Extension2}";
            }
        }

        /// <summary>
        /// Product, (AppName, AnotherApp)
        /// </summary>
        private readonly Dictionary<string, Dictionary<string, AnotherApp>> _otherAppsStatic = new Dictionary<string, Dictionary<string, AnotherApp>>();

        protected virtual void InitOtherApps(string product)
        {
            var appList = new Dictionary<string, AnotherApp>();
            _otherAppsStatic.Add(product, appList);

            if (!product.Equals("cells")) return;

            var apps = new[]
            {
                "Editor", "Conversion", "Parser", "Metadata", "Viewer",
                "Watermark", "Merger", "Search",
                "Assembly", "Annotation", "Unlock", "Protect", "Splitter", "Chart"
            };
            foreach (var appName in apps)
                appList.Add(appName, new AnotherApp(appName));
        }

        private bool IsSupportedExtensions(string extFrom, string extTo)
        {
            if (string.IsNullOrEmpty(extFrom))
            {
                return true;
            }

            extTo = string.IsNullOrEmpty(extTo) ? "" : extTo.ToUpper();

            var isValExist = Resources[ProductAppName + "ValidationExpression"].Contains(extFrom.ToLower());
            if (!isValExist)
                return false;

            return string.IsNullOrEmpty(extTo) || Resources[ProductAppName + "SaveAsOptions"].Contains(extTo);
        }

        private static readonly Dictionary<string, string> FileFormatLinks = new Dictionary<string, string>
        {
            {"DOC", "https://wiki.fileformat.com/word-processing/doc/"},
            {"DOCM", "https://wiki.fileformat.com/word-processing/docm/"},
            {"DOCX", "https://wiki.fileformat.com/word-processing/docx/"},
            {"DOT", "https://wiki.fileformat.com/word-processing/dot/"},
            {"DOTM", "https://wiki.fileformat.com/word-processing/dotm/"},
            {"DOTX", "https://wiki.fileformat.com/word-processing/dotx/"},
            {"ODT", "https://wiki.fileformat.com/word-processing/odt/"},
            {"MD", "https://wiki.fileformat.com/word-processing/md/"},
            {"OTT", "https://wiki.fileformat.com/word-processing/ott/"},
            {"RTF", "https://wiki.fileformat.com/word-processing/rtf/"},
            {"TXT", "https://wiki.fileformat.com/word-processing/txt/"},
            {"EPUB", "https://wiki.fileformat.com/ebook/epub/"},
            {"PDF", "https://wiki.fileformat.com/view/pdf/"},
            {"HTML", "https://wiki.fileformat.com/web/html/"},
            {"XHTML", "https://wiki.fileformat.com/web/xhtml/"},
            {"MHTML", "https://wiki.fileformat.com/web/mhtml/"},
            {"MHT", "https://wiki.fileformat.com/web/mhtml/"},
            {"JPG", "https://wiki.fileformat.com/image/jpeg/"},
            {"JPEG", "https://wiki.fileformat.com/image/jpeg/"},
            {"PNG", "https://wiki.fileformat.com/image/png/"},
            {"TEX", "https://wiki.fileformat.com/page-description-language/tex/"},
            {"XLS", "https://wiki.fileformat.com/spreadsheet/xls/"},
            {"XLSX", "https://wiki.fileformat.com/spreadsheet/xlsx/"},
            {"XLSM", "https://wiki.fileformat.com/spreadsheet/xlsm/"},
            {"XLSB", "https://wiki.fileformat.com/spreadsheet/xlsb/"},
            {"ODS", "https://wiki.fileformat.com/spreadsheet/ods/"},
            {"CSV", "https://wiki.fileformat.com/spreadsheet/csv/"},
            {"TSV", "https://wiki.fileformat.com/spreadsheet/tsv/"},
            {"PPTX", "https://wiki.fileformat.com/presentation/pptx/"},
            {"PS", "https://wiki.fileformat.com/page-description-language/ps/"},
            {"EPS", "https://wiki.fileformat.com/page-description-language/eps/"},
            {"XPS", "https://wiki.fileformat.com/page-description-language/xps/"},
            {"BMP", "https://wiki.fileformat.com/image/bmp/"},
            {"TIFF", "https://wiki.fileformat.com/image/tiff/"},
            {"EMF", "https://wiki.fileformat.com/image/emf/"},
            {"WMF", "https://wiki.fileformat.com/image/wmf/"},
            {"SVG", "https://wiki.fileformat.com/page-description-language/svg/"}
        };

        private void AddFileFormatLinks()
        {
            if (AppFeatures == null) return;
            if (!Resources.ContainsKey(ProductAppName + "Action")) return;

            var str = new StringBuilder($"{Resources[ProductAppName + "Action"]} ");
            var extensions = ExtensionsString.Replace(".", "").ToUpper().Split('|');
            foreach (var ext in extensions)
                str.Append(FileFormatLinks.ContainsKey(ext)
                    ? $"<a target=\"_blank\" href=\"{FileFormatLinks[ext]}\">{ext}</a>, "
                    : $"{ext}, ");
            str.Remove(str.Length - 2, 2);
            AppFeatures.Insert(0, str.ToString());
        }

        protected virtual string PrepareJsonLdBreadcrumbList()
        {
            var list = new List<(string Name, string Href)> {("Aspose Product Family", "https://products.aspose.app/"), ("cells", "https://products.aspose.app/cells/family"), ($"{AppName}", "https://products.aspose.app/cells/" + AppName.ToLower())};

            if (string.IsNullOrEmpty(Extension)) return Breadcrumb.GenerateJson(list.ToArray());
            var add1 = Extension == null ? "" : Extension.ToUpper();
            var add2 = Extension2 == null ? "" : Extension2.ToUpper();

            string name;
            switch (AppName)
            {
                case "Conversion":
                    name = string.Format(Resources[$"{ProductAppName}Breadcrumb"], add1, add2);
                    break;
                case "Viewer":
                    name = string.Format(Resources[$"{ProductAppName}Breadcrumb"], add1);
                    break;
                case "Merger":
                    if (string.IsNullOrEmpty(add2))
                    {
                        name = string.Format(Resources[$"{ProductAppName}Breadcrumb1"], add1);
                    }
                    else
                    {
                        name = string.Format(Resources[$"{ProductAppName}Breadcrumb2"], add1, add2);
                    }

                    break;
                case "Protect":
                    name = string.Format(Resources[$"{ProductAppName}Breadcrumb"], add1);
                    break;
                case "Splitter":
                    name = string.Format(Resources[$"{ProductAppName}Breadcrumb"], add1);
                    break;
                case "Editor":
                    name = string.Format(Resources[$"{ProductAppName}Breadcrumb"], add1);
                    break;
                default:
                    name = Resources.ContainsKey($"{ProductAppName}Breadcrumb")
                        ? string.Format(Resources[$"{ProductAppName}Breadcrumb"], add1, add2)
                        : $"{Resources[$"{AppName}Action"]} {add1}";
                    break;
            }

            list.Add((name, "https://products.aspose.app" + Controller.Request.Url.PathAndQuery.ToLower()));

            return Breadcrumb.GenerateJson(list.ToArray());
        }

        protected virtual string PrepareJsonLdSoftware()
        {
            var obj = new SoftwareApplication
            {
                Name = Title,
                Description = MetaDescription,
                SoftwareRequirements = new URL {Id = "https://docs.aspose.com/display/cellsnet/System+Requirements"},
                SoftwareHelp = "https://docs.aspose.com/display/cellsnet/Home"
            };
            return JsonConvert.SerializeObject(obj);
        }

        protected virtual string PrepareJsonLdHowTo()
        {
            var obj = new HowTo(HowToModel, TitleSub, Title);
            return JsonConvert.SerializeObject(obj);
        }

        protected virtual void PrepareStructuralDataJson()
        {
            if (AppName != "Merger" && AppName != "Editor" && AppName != "Splitter" && AppName != "Protect")
            {
                return;
            }

            var list = new List<string>();
            try
            {
                list.Add(PrepareJsonLdSoftware());
                if (HowToModel != null)
                {
                    list.Add(PrepareJsonLdHowTo());
                }
            }
            catch (Exception ex)
            {
                NLogger.LogError(ex, ex.Message, "", ProductFamilyNameKeysEnum.cells, "");
            }

            Controller.ViewBag.JsonLd = list;
        }
    }
}