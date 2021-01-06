using Aspose.Cells.UI.Config;
using Aspose.Cells.UI.Models.DTO.SEOApi;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Tools.Foundation.Helpers;

namespace Aspose.Cells.UI.Services
{
	public class ResourcesService : BaseAPICacheService
	{
		static HttpClient _httpClient = new HttpClient();

		public async Task<Dictionary<string, string>> GetResources(string locale)
		{
			using (var response = await _httpClient.GetAsync($"{Configuration.OptimizationSEOUrl}/Resources?locale={locale}&AuthenticationToken={Configuration.OptimizationSEOKey}"))
			{
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsAsync<Dictionary<string, string>>();
			}
		}

		public async Task FillResources(string locale, Dictionary<string, string> resources)
		{
			using (var response = await _httpClient.PutAsync(
				$"{Configuration.OptimizationSEOUrl}/Resources/FillResources?locale={locale}&AuthenticationToken={Configuration.OptimizationSEOKey}",
				new StringContent(resources.ToJson(false), Encoding.UTF8, "application/json")
			))
			{
				response.EnsureSuccessStatusCode();
			}
		}

		internal void TrackKey(HttpContext context, string key)
		{
			var used = DateTime.UtcNow;
			var locale = "EN";
			if (context.Request.Url.Host.StartsWith("zh."))
				locale = "ZH";

			var url = context.Request.Url.ToString();
			url = url.Substring(0, Math.Min(url.Length, 500));

			ResourcesUsageQueue.Enqueue(
				new ResourcesUsage
				{
					Used = used,
					Locale = locale,
					Key = key,
					Url = url
				}
			);
		}

		static Dictionary<string, Dictionary<string, string>> _Resources = new Dictionary<string, Dictionary<string, string>>();

		public static void PurgeCache()
		{
			lock (_Resources)
			{
				_Resources.Clear();
			}
		}

		public Dictionary<string, string> GetCachedResources(string locale)
			=> GetCached(_Resources, locale, async () => await GetResources(locale));
	
		static ConcurrentQueue<ResourcesUsage> ResourcesUsageQueue = new ConcurrentQueue<ResourcesUsage>();

		static ResourcesService()
		{
#if !NO_DATABASE
			new Task(async () => await Worker(), TaskCreationOptions.LongRunning).Start();
#endif
		}

		static async Task Worker()
		{
			while (true)
			{
				try
				{
					var list = new List<ResourcesUsage>();
					while (ResourcesUsageQueue.TryDequeue(out var record))
					{
						list.Add(record);
					}
					if (list.Any())
						await SaveTrackKeys(list);
				}
				catch (Exception ex)
				{
					Tools.Foundation.Models.NLogger.LogError(
						ex,
						$"ControllerName = {nameof(ResourcesService)}, MethodName = {nameof(Worker)}",
						"",
						Tools.Foundation.Models.ProductFamilyNameKeysEnum.unassigned,
						""
					);

				}
				finally
				{
					await Task.Delay(5000);
				}
			}
		}

		public static async Task SaveTrackKeys(List<ResourcesUsage> usage)
		{
			using (var response = await _httpClient.PostAsync(
				$"{Configuration.OptimizationSEOUrl}/Resources/TrackUsage?&AuthenticationToken={Configuration.OptimizationSEOKey}",
				new StringContent(usage.ToJson(false), Encoding.UTF8, "application/json")
			))
			{
				response.EnsureSuccessStatusCode();
			}
		}
	}
}
