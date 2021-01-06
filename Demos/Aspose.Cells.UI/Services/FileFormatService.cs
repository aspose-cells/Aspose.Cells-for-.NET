using Aspose.Cells.UI.Config;
using Aspose.Cells.UI.Models.DTO.SEOApi;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aspose.Cells.UI.Services
{
	public class FileFormatService : BaseAPICacheService
	{
		public async Task<FileFormat> Get(
			string extension
		)
		{
			using (var response = await _httpClient.GetAsync($"{Configuration.OptimizationSEOUrl}/FileFormat?extension={extension}&AuthenticationToken={Configuration.OptimizationSEOKey}"))
			{
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsAsync<FileFormat>();
			}
		}

		public async Task<Dictionary<string, FileFormat>> GetAll()
		{
			using (var response = await _httpClient.GetAsync($"{Configuration.OptimizationSEOUrl}/FileFormat/All?AuthenticationToken={Configuration.OptimizationSEOKey}"))
			{
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsAsync<Dictionary<string, FileFormat>>();
			}
		}

		public FileFormat GetCached(string extension) =>
			GetCached(_AllFileFormats ?? _FileFormats, extension, async () => await Get(extension));

		object locker = new object();
		public Dictionary<string, FileFormat> GetAllCached()
		{
			lock (locker)
			{
				if (_AllFileFormats == null)
					_AllFileFormats = Task.Run(async () => await GetAll()).Result;

				return _AllFileFormats.ToDictionary(k => k.Key, v => v.Value);
			}
		}

		static Dictionary<string, FileFormat> _FileFormats = new Dictionary<string, FileFormat>();
		static Dictionary<string, FileFormat> _AllFileFormats = null;

		public static void PurgeCache()
		{
			lock (_FileFormats)
			{
				_FileFormats.Clear();
				_AllFileFormats?.Clear();
			}
		}
	}
}
