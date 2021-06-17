using System.IO;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Services;
using Aspose.Cells.GridJs;

namespace Aspose.Cells.Common.Models
{
    public class AwsCache : GridCacheForStream
    {
        private readonly IStorageService _storage;

        public AwsCache(IStorageService storage)
        {
            _storage = storage;
        }

        private static string GetKey(string uid)
        {
            return $"{Configuration.GridJsCacheFolder}/{uid}";
        }

        public override void SaveStream(Stream s, string uid)
        {
            s.Position = 0;
            _storage.Upload(GetKey(uid), s).Wait();
        }

        public override Stream LoadStream(string uid)
        {
            return _storage.Download(GetKey(uid)).Result;
        }

        public override string GetImageUrl(string uid)
        {
            return _storage.GetUrl(2, GetKey(uid));
        }
    }
}