using Aspose.Cells.UI.Models.DTO.SEOApi;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aspose.Cells.UI.Services
{
    public class FileFormatService : BaseApiCacheService
    {
        public async Task<FileFormat> GetFromLocal(string extension)
        {
            var jsonFilePath = GetVirtualPath("~/App_Data/file_format.json");
            using (var sr = new StreamReader(jsonFilePath))
            {
                var json = await sr.ReadToEndAsync();
                var formats = JsonConvert.DeserializeObject<Dictionary<string, FileFormat>>(json);

                return formats.Keys.Contains(extension) ? formats[extension] : null;
            }
        }

        public async Task<Dictionary<string, FileFormat>> GetAllFromLocal()
        {
            var jsonFilePath = GetVirtualPath("~/App_Data/file_format.json");
            using (var sr = new StreamReader(jsonFilePath))
            {
                var json = await sr.ReadToEndAsync();
                return JsonConvert.DeserializeObject<Dictionary<string, FileFormat>>(json);
            }
        }

        public FileFormat GetCached(string extension) => GetCached(_allFileFormats ?? FileFormats, extension, async () => await GetFromLocal(extension));

        private readonly object _locker = new object();

        public Dictionary<string, FileFormat> GetAllCached()
        {
            lock (_locker)
            {
                if (_allFileFormats == null)
                    _allFileFormats = Task.Run(async () => await GetAllFromLocal()).Result;

                return _allFileFormats.ToDictionary(k => k.Key, v => v.Value);
            }
        }

        private static readonly Dictionary<string, FileFormat> FileFormats = new Dictionary<string, FileFormat>();
        private static Dictionary<string, FileFormat> _allFileFormats;
    }
}