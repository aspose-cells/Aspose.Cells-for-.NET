using Aspose.Cells.UI.Config;
using Aspose.Cells.UI.Models.DTO.SEOApi;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tools.Foundation.Helpers;

namespace Aspose.Cells.UI.Services
{
	public class GeneratedPagesService : BaseAPICacheService
	{
		static HttpClient _httpClient = new HttpClient();

		public async Task<GeneratedPage> GetByURL(string url)
		{
			using (var response = await _httpClient.GetAsync($"{Configuration.OptimizationSEOUrl}/GeneratedPages/ByURL?url={url}&AuthenticationToken={Configuration.OptimizationSEOKey}"))
			{
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsAsync<GeneratedPage>();
			}
		}

		public async Task<GeneratedPage> GetByAppURL(string url)
		{
			using (var response = await _httpClient.GetAsync($"{Configuration.OptimizationSEOUrl}/GeneratedPages/ByAppURL?url={url}&AuthenticationToken={Configuration.OptimizationSEOKey}"))
			{
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsAsync<GeneratedPage>();
			}
		}

		public async Task<List<GeneratedPage>> GetByExtension(string extension1)
		{
			using (var response = await _httpClient.GetAsync($"{Configuration.OptimizationSEOUrl}/GeneratedPages/ByExtension?extension1={extension1}&AuthenticationToken={Configuration.OptimizationSEOKey}"))
			{
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsAsync<List<GeneratedPage>>();
			}
		}

		public async Task<List<GeneratedPage>> GetByExtensions(params string[] extensions)
		{
			using (var response = await _httpClient.PostAsync(
				$"{Configuration.OptimizationSEOUrl}/GeneratedPages/ByExtensions?AuthenticationToken={Configuration.OptimizationSEOKey}",
				new StringContent(extensions.ToJson(false), Encoding.UTF8, "application/json")
			))
			{
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsAsync<List<GeneratedPage>>();
			}
		}

		public async Task<List<GeneratedPage>> GetByAppIDandNotExtension(string appUrlId, string extension1)
		{
			using (var response = await _httpClient.GetAsync($"{Configuration.OptimizationSEOUrl}/GeneratedPages/ByAppIDandNotExtension?appUrlId={appUrlId}&extension1={extension1}&AuthenticationToken={Configuration.OptimizationSEOKey}"))
			{
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsAsync<List<GeneratedPage>>();
			}
		}

		public async Task<List<GeneratedPage>> GetByAppUrlAndExtension(string url, string extension1)
		{
			using (var response = await _httpClient.GetAsync($"{Configuration.OptimizationSEOUrl}/GeneratedPages/ByAppUrlAndExtension?url={url}&extension1={extension1}&AuthenticationToken={Configuration.OptimizationSEOKey}"))
			{
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsAsync<List<GeneratedPage>>();
			}
		}

		public async Task<List<GeneratedPage>> GetAllByAppURL(string url)
		{
			using (var response = await _httpClient.GetAsync($"{Configuration.OptimizationSEOUrl}/GeneratedPages/AllByAppURL?url={url}&AuthenticationToken={Configuration.OptimizationSEOKey}"))
			{
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsAsync<List<GeneratedPage>>();
			}
		}		

		public GeneratedPage GetCachedByURL(string url)
			=> GetCached(_ByUrls, url, async () => await GetByURL(url));

		public GeneratedPage GetCachedByAppURL(string url)
			=> GetCached(_ByAppUrls, url, async () => await GetByAppURL(url));

		public List<GeneratedPage> GetCachedByExtension(string extension1)
			=> GetCached(_ByExtension, extension1, async () => await GetByExtension(extension1));

		public List<GeneratedPage> GetCachedByExtensions(params string[] extensions)
			=> GetCached(_ByExtensions, extensions.ToJson(false), async () => await GetByExtensions(extensions));

		public List<GeneratedPage> GetCachedByAppIDandNotExtension(string appUrlId, string extension1)
			=> GetCached(_ByAppIDandNotExtension, (appUrlId, extension1), async () => await GetByAppIDandNotExtension(appUrlId, extension1));

		public List<GeneratedPage> GetCachedByAppUrlAndExtension(string url, string extension1)
			=> GetCached(_ByAppUrlAndExtension, (url, extension1), async () => await GetByAppUrlAndExtension(url, extension1));

		public List<GeneratedPage> GetCachedAllByAppURL(string url)
			=> GetCached(_AllByAppURL, url, async () => await GetAllByAppURL(url));
		
		static Dictionary<string, GeneratedPage> _ByUrls = new Dictionary<string, GeneratedPage>();
		static Dictionary<string, GeneratedPage> _ByAppUrls = new Dictionary<string, GeneratedPage>();
		static Dictionary<string, List<GeneratedPage>> _ByExtension = new Dictionary<string, List<GeneratedPage>>();
		static Dictionary<string, List<GeneratedPage>> _ByExtensions = new Dictionary<string, List<GeneratedPage>>();
		static Dictionary<(string, string), List<GeneratedPage>> _ByAppIDandNotExtension = new Dictionary<(string, string), List<GeneratedPage>>();
		static Dictionary<(string, string), List<GeneratedPage>> _ByAppUrlAndExtension = new Dictionary<(string, string), List<GeneratedPage>>();
		static Dictionary<string, List<GeneratedPage>> _AllByAppURL = new Dictionary<string, List<GeneratedPage>>();

		


		public static void PurgeCache()
		{
			lock (_ByUrls) _ByUrls.Clear();
			lock (_ByAppUrls) _ByAppUrls.Clear();
			lock (_ByExtension) _ByExtension.Clear();
			lock (_ByExtensions) _ByExtensions.Clear();
			lock (_ByAppIDandNotExtension) _ByAppIDandNotExtension.Clear();
			lock (_ByAppUrlAndExtension) _ByAppUrlAndExtension.Clear();
			lock (_AllByAppURL) _AllByAppURL.Clear();
			
		}
	}
}
