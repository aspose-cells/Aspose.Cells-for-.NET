using Aspose.Cells.UI.Models.DTO.SEOApi;
using System;
using System.Collections.Concurrent;
using System.Web;

namespace Aspose.Cells.UI.Services
{
    public class ResourcesService : BaseApiCacheService
    {
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

        public static readonly ConcurrentQueue<ResourcesUsage> ResourcesUsageQueue = new ConcurrentQueue<ResourcesUsage>();

        static ResourcesService()
        {
#if !NO_DATABASE
			new Task(async () => await Worker(), TaskCreationOptions.LongRunning).Start();
#endif
        }
    }
}