using System;
using System.Collections.Generic;
using System.Linq;

namespace Aspose.Cells.UI.Models
{
    public class GeneratedPage : BaseDataProvider
    {
        private string _url = string.Empty;
        private string _name = string.Empty;

        private string[] _extensions;

        private string _extension1 = string.Empty;
        private string _header1 = string.Empty;
        private string _extension2 = string.Empty;
        private string _header2 = string.Empty;
        private string _app_url_id = string.Empty;
        private string _main_headline = string.Empty;
        private string _sub_headline = string.Empty;

        public GeneratedPage()
        {
        }

        public GeneratedPage(DTO.SEOApi.GeneratedPage source)
        {
            URL = source.Url;
            Name = source.Name;
            Extension1 = source.Extension1;
            Header1 = source.Header1;
            Extension2 = source.Extension2;
            Header2 = source.Header2;
            App_URL_ID = source.AppUrlId;
            App_url = source.AppUrl;
            MainHeadline = source.MainHeadlineDesc;
            SubHeadline = source.SubHeadlineDesc;
        }

        public GeneratedPage(string url)
        {
            _url = url;
        }

        public GeneratedPage(string extension1, string extension2, string appUrl)
        {
            _extension1 = extension1;
            _extension2 = extension2;
            _url = appUrl;
        }

        public GeneratedPage(string extension1, string extension2)
        {
            _extension1 = extension1;
            _extension2 = extension2;
        }

        public GeneratedPage(params string[] extensions)
        {
            _extensions = extensions;
        }

        public GeneratedPage(string extension1, string appURLID, bool byApprUrl)
        {
            _extension1 = extension1;
            _app_url_id = appURLID;
        }

        public string MainHeadline
        {
            get => _main_headline;
            set => _main_headline = value;
        }

        public string SubHeadline
        {
            get => _sub_headline;
            set => _sub_headline = value;
        }

        public string AnyHeadline => MainHeadline.IsNullOrWhiteSpace() ? SubHeadline : MainHeadline;

        public string URL
        {
            get => _url;
            set => _url = value;
        }

        public string App_url { get; set; }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Extension1
        {
            get => _extension1;
            set => _extension1 = value;
        }

        public string Header1
        {
            get => _header1;
            set => _header1 = value;
        }

        public string Extension2
        {
            get => _extension2;
            set => _extension2 = value;
        }

        public string App_URL_ID
        {
            get => _app_url_id;
            set => _app_url_id = value;
        }

        public string Header2
        {
            get => _header2;
            set => _header2 = value;
        }

        public GeneratedPage GetByAppURL()
        {
            var result = _GeneratedPagesService.GetCachedByAppURL(URL);
            return result != null ? new GeneratedPage(result) : null;
        }

        public GeneratedPages GetAllByAppURL()
        {
            var result = _GeneratedPagesService.GetCachedAllByAppURL(URL);

            var generatedPages = new GeneratedPages();
            generatedPages.AddRange(result.Select(r => new GeneratedPage(r)));
            return generatedPages;
        }

        public GeneratedPage GetByURL()
        {
            var result = _GeneratedPagesService.GetCachedByURL(URL);
            return result != null ? new GeneratedPage(result) : null;
        }

        public GeneratedPages GetByExtensions()
        {
            List<DTO.SEOApi.GeneratedPage> result;
            if (_extensions != null && _extensions.Length > 0)
                result = _GeneratedPagesService.GetCachedByExtensions(_extensions.Select(x => x.ToLowerInvariant()).ToArray());
            else
                result = _GeneratedPagesService.GetCachedByExtension(Extension1);

            var generatedPages = new GeneratedPages();
            generatedPages.AddRange(
                result
                    .Where(r => r.Url.Contains("/conversion") && !r.Url.StartsWith("/conversion"))
                    .Select(r => new GeneratedPage(r))
            );
            return generatedPages;
        }

        public GeneratedPages GetByAppIDandNotExtension()
        {
            var result = _GeneratedPagesService.GetCachedByAppIDandNotExtension(App_URL_ID, Extension1);

            var generatedPages = new GeneratedPages();
            generatedPages.AddRange(result.Select(r => new GeneratedPage(r)));
            return generatedPages;
        }

        public GeneratedPages GetByAppUrlAndExtension()
        {
            var result = _GeneratedPagesService.GetCachedByAppUrlAndExtension(URL, Extension1);

            var generatedPages = new GeneratedPages();
            generatedPages.AddRange(result.Select(r => new GeneratedPage(r)));
            return generatedPages;
        }

        public static GeneratedPage GetByURL(string url)
        {
            return new GeneratedPage(url).GetByURL();
        }

        public IEnumerable<(bool isParent, string url)> GetUrls(string baseUrl, string product)
        {
            var result = _SitemapService.GetCachedUrls(baseUrl, product);
            return result.Select(r => (isParent: r.IsParent, url: r.Url));
        }

        public string GetExtensionDescription(string ext)
        {
            return _GeneratedPagesService.GetCachedByExtension(ext).Where(x => ext.Equals(x.Extension2, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault()?.MainHeadlineDesc;
        }
    }

    public class GeneratedPages : List<GeneratedPage>
    {
    }
}