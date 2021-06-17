using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Cells.Common.Models.DTO.SEOApi;
using Newtonsoft.Json;

namespace Aspose.Cells.Common.Services
{
    public class GeneratedPagesService : BaseApiCacheService
    {
        public async Task<GeneratedPage> GetByUrlFromLocal(string url)
        {
            var jsonFilePath = Path.Combine(AppContext.BaseDirectory, "App_Data/generated_pages.json");
            using (var sr = new StreamReader(jsonFilePath))
            {
                var json = await sr.ReadToEndAsync();
                var list = JsonConvert.DeserializeObject<List<GeneratedPage>>(json);

                foreach (var generatedPage in list.Where(generatedPage => generatedPage.Url.Equals(url)))
                {
                    return generatedPage;
                }

                return new GeneratedPage();
            }
        }

        public async Task<List<GeneratedPage>> GetByAppUrlFromLocal(string appUrl)
        {
            var jsonFilePath = Path.Combine(AppContext.BaseDirectory, "App_Data/generated_pages.json");
            using (var sr = new StreamReader(jsonFilePath))
            {
                var json = await sr.ReadToEndAsync();
                var list = JsonConvert.DeserializeObject<List<GeneratedPage>>(json);

                return list.Where(generatedPage => generatedPage.AppUrl.Equals(appUrl)).ToList();
            }
        }

        public GeneratedPage GetCachedByUrl(string url) => GetCached(ByUrls, url, async () => await GetByUrlFromLocal(url));

        public List<GeneratedPage> GetCachedByAppUrl(string appUrl) => GetCached(ByAppUrls, appUrl, async () => await GetByAppUrlFromLocal(appUrl));

        public static readonly Dictionary<string, GeneratedPage> ByUrls = new Dictionary<string, GeneratedPage>();
        public static readonly Dictionary<string, List<GeneratedPage>> ByAppUrls = new Dictionary<string, List<GeneratedPage>>();
    }
}