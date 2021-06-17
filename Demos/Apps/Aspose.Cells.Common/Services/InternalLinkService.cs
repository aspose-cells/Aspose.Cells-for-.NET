using System;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace Aspose.Cells.Common.Services
{
    public class InternalLinkService
    {
        private readonly IStorageService _service;

        public InternalLinkService(IStorageService service)
        {
            _service = service;
        }

        public async Task<FormFile> Upload(string url)
        {
            var arr = url.Split("/", StringSplitOptions.RemoveEmptyEntries);
            var id = HttpUtility.UrlDecode(arr[^1].Replace("?file=", "/"));

            var (stream, _, awsMetaInfo) = await _service.DownloadEx(id);
            return new FormFile(stream, 0, stream.Length, awsMetaInfo.OriginalFileName, awsMetaInfo.OriginalFileName);
        }
    }
}