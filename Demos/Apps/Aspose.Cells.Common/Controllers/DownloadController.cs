using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Services;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Common.Controllers
{
    public class DownloadController : ControllerBase
    {
        private readonly IStorageService _storage;
        private readonly ILogger<DownloadController> _logger;

        public DownloadController(IStorageService storage, ILogger<DownloadController> logger)
        {
            _storage = storage;
            _logger = logger;
        }

        [HttpGet]
        public async Task<FileStreamResult> Download([FromRoute] string id, [FromQuery] string file)
        {
            var convertPath = $"{Configuration.ConvertFolder}/{id}";
            var url = AwsStorageService.Join(convertPath, file);
            if (!await _storage.CheckExists(url))
            {
                Response.StatusCode = (int) HttpStatusCode.NotFound;
                throw new KeyNotFoundException();
            }

            var (stream, contentType, info) = await _storage.DownloadEx(url);
            return new FileStreamResult(stream, contentType)
            {
                FileDownloadName = info.OriginalFileName ?? id
            };
        }
    }
}