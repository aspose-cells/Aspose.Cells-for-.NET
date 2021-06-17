using Aspose.Cells.Common.Models.DTO.SEOApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aspose.Cells.Common.Services
{
    public class FileFormatService : BaseApiCacheService
    {
        public async Task<FileFormat> GetFromLocal(string extension)
        {
            var jsonFilePath = Path.Combine(AppContext.BaseDirectory, "App_Data/file_format.json");
            using (var sr = new StreamReader(jsonFilePath))
            {
                var json = await sr.ReadToEndAsync();
                var formats = JsonConvert.DeserializeObject<Dictionary<string, FileFormat>>(json);

                return formats.Keys.Contains(extension) ? formats[extension] : null;
            }
        }

        public async Task<Dictionary<string, FileFormat>> GetAllFromLocal()
        {
            var jsonFilePath = Path.Combine(AppContext.BaseDirectory, "App_Data/file_format.json");
            using (var sr = new StreamReader(jsonFilePath))
            {
                var json = await sr.ReadToEndAsync();
                return JsonConvert.DeserializeObject<Dictionary<string, FileFormat>>(json);
            }
        }

        public FileFormat GetCached(string extension) => GetCached(FileFormats, extension, async () => await GetFromLocal(extension));

        private static readonly Dictionary<string, FileFormat> FileFormats = new Dictionary<string, FileFormat>();
    }
}