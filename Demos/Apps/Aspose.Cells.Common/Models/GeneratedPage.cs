using System.Collections.Generic;
using System.Linq;

namespace Aspose.Cells.Common.Models
{
    public class GeneratedPage : BaseDataProvider
    {
        public GeneratedPage(DTO.SEOApi.GeneratedPage source)
        {
            Url = source.Url;
            Name = source.Name;
            Extension1 = source.Extension1;
            Extension2 = source.Extension2;
            AppUrl = source.AppUrl;
        }

        public GeneratedPage(string url)
        {
            Url = url;
        }

        public GeneratedPage(string appUrl, bool byAppUrl)
        {
            AppUrl = appUrl;
            ByAppUrl = byAppUrl;
        }

        public string Url { get; set; } = string.Empty;

        public string AppUrl { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Extension1 { get; set; } = string.Empty;

        public string Extension2 { get; set; } = string.Empty;

        public bool ByAppUrl { get; set; }

        public GeneratedPage GetByUrl()
        {
            var result = GeneratedPagesService.GetCachedByUrl(Url);
            return result != null ? new GeneratedPage(result) : null;
        }

        public static GeneratedPage GetByUrl(string url)
        {
            return new GeneratedPage(url).GetByUrl();
        }

        public GeneratedPages GetByAppUrl()
        {
            var result = GeneratedPagesService.GetCachedByAppUrl(AppUrl);

            var generatedPages = new GeneratedPages();
            generatedPages.AddRange(result.Select(r => new GeneratedPage(r)));
            return generatedPages;
        }
    }

    public class GeneratedPages : List<GeneratedPage>
    {
    }
}