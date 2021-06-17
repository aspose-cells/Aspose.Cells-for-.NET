using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Models;
using Aspose.Cells.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Aspose.Cells.Common.Controllers
{
    public class CommonController : ControllerBase
    {
        private readonly IStorageService _storage;
        private readonly ILogger<CommonController> _logger;

        public CommonController(IStorageService storage, ILogger<CommonController> logger)
        {
            _storage = storage;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] JObject obj)
        {
            var folderName = Convert.ToString(obj["FolderName"]);
            var filename = Convert.ToString(obj["Filename"]);
            var objectPath = $"{Configuration.ConvertFolder}/{folderName}/{filename}";

            if (folderName.IsNullOrEmpty() || !await _storage.CheckExists(objectPath))
            {
                return NotFound();
            }

            try
            {
                await _storage.Delete(objectPath);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("AppName = {AppName} | Message = {Message} | FolderName = {FolderName}",
                    "Common.Delete", e.Message, folderName);
                return BadRequest();
            }
        }

        [HttpPost]
        [ActionName("UploadFile")]
        public async Task<FileSafeResult> UploadFile() => (await Upload(Guid.NewGuid().ToString())).First();

        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        private async Task<IEnumerable<FileSafeResult>> Upload(string sessionId)
        {
            IEnumerable<IFormFile> uploadProvider = HttpContext.Request.Form.Files;
            uploadProvider = uploadProvider.Union(await UploadLinks());
            var formFiles = uploadProvider.ToList();

            foreach (var formFile in formFiles)
            {
                var objectPath = $"{Configuration.SourceFolder}/{sessionId}/{formFile.FileName}";
                
                await using var memoryStream = new MemoryStream();
                await formFile.CopyToAsync(memoryStream);
                
                await _storage.Upload(objectPath, memoryStream, new AwsMetaInfo
                {
                    OriginalFileName = formFile.FileName,
                    Title = formFile.FileName
                });
            }

            return
                from formFile in formFiles
                let localFileName = formFile.FileName
                select new FileSafeResult(localFileName)
                {
                    id = sessionId,
                    FileName = Path.GetFileName(localFileName)
                };
        }

        private async Task<FormFile[]> UploadLinks()
        {
            var form = await HttpContext.Request.ReadFormAsync();
            var service = new WebClientService();
            var internalService = new InternalLinkService(_storage);
            var files = await Task.WhenAll(
                form
                    .Where(item =>
                        Uri.IsWellFormedUriString(item.Value, UriKind.Absolute))
                    .AsParallel()
                    .Where(item =>
                        item.Key.StartsWith("link_"))
                    .Select(async item => await service.Upload(item.Value)));

            var internalFiles = await Task.WhenAll(
                form
                    .Where(item => Uri.IsWellFormedUriString(item.Value, UriKind.Relative))
                    .AsParallel()
                    .Where(item =>
                        item.Key.StartsWith("link_"))
                    .Select(async item => await internalService.Upload(item.Value)));
            return files.Union(internalFiles).Where(f => f != null).ToArray();
        }
    }
}