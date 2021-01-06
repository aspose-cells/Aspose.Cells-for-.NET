using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.WebPages;
using Aspose.Cells.API.Config;
using Aspose.Cells.API.Helpers;
using Aspose.Cells.API.Models;
using Aspose.Cells.API.Services;
using Newtonsoft.Json.Linq;
using Tools.Foundation.Models;
using File = System.IO.File;

namespace Aspose.Cells.API.Controllers
{
    /// <summary>
    /// Common  API controller.
    /// </summary>
    public sealed class CommonController : BaseApiController
    {
        /// <summary>
        /// Receives upload files from multi-part request to specified folder inside WorkingDirectory.
        /// </summary>
        /// <param name="request">Request with files.</param>
        /// <param name="folder">Folder to safe files to.</param>
        /// <returns>Files upload results.</returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        private async Task<IEnumerable<FileSafeResult>> Upload(HttpRequestMessage request, string folder)
        {
            var pathProcessor = new PathProcessor(folder);
            var uploadProvider = new MultipartFormDataStreamProviderSafe(pathProcessor.SourceFolder);
            await request.Content.ReadAsMultipartAsync(uploadProvider);

            var idUpload = uploadProvider.FormData["idUpload"];

            return
                from fileData in uploadProvider.FileData
                let localFileName = fileData.LocalFileName
                select new FileSafeResult(localFileName)
                {
                    id = folder,
                    FileName = Path.GetFileName(localFileName),
                    idUpload = idUpload,
                };
        }

        private FileSafeResult MoveFile(string destinationFolder, string idUpload, MultipartFileData file)
        {
            var destinationPath = Path.Combine(destinationFolder, Path.GetFileName(file.LocalFileName));
            var count = 2;
            while (File.Exists(destinationPath))
            {
                var extension = Path.GetExtension(destinationPath);
                destinationPath = Path.Combine(destinationFolder, $"{Path.GetFileNameWithoutExtension(file.LocalFileName)}_{count}{extension}");
                count++;
            }

            File.Move(file.LocalFileName, destinationPath);
            return new FileSafeResult(destinationPath)
                {id = idUpload, FileName = Path.GetFileName(destinationPath), idUpload = idUpload};
        }

        /// <summary>
        /// Sends back specified file from specified folder inside OutputDirectory.
        /// </summary>
        /// <param name="folder">Folder inside OutputDirectory.</param>
        /// <param name="file">File.</param>
        /// <returns>HTTP response with file.</returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        private HttpResponseMessage Download(string folder, string file)
        {
            var pathProcessor = new PathProcessor(folder, file);
            var stream = new FileStream(pathProcessor.DefaultOutFile, FileMode.Open, FileAccess.Read, FileShare.None, 4096, true);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(stream)
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = file
            };
            return result;
        }

        /// <summary>
        /// Sends download url to specified email.
        /// </summary>
        /// <param name="product">Product.</param>
        /// <param name="action">Action.</param>
        /// <param name="folder">Folder inside OutputDirectory.</param>
        /// <param name="file">File.</param>
        /// <param name="email">Email.</param>
        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        private string SendDownloadUrlToEmail(ProductFamilyNameKeysEnum product, string action, string folder, string file, string email)
        {
            throw new NotImplementedException("Too many dependencies from Resources. Need to refactor first.");
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CommonController() : base(ProductFamilyNameKeysEnum.unassigned)
        {
        }

        /// <summary>
        /// Uploads file.
        /// Returns upload id and filename.
        /// </summary>
        /// <returns>File upload result.</returns>
        [MimeMultipart]
        [HttpPost]
        [ActionName("UploadFile")]
        public async Task<FileSafeResult> UploadFile(HttpRequestMessage request) => (await Upload(request, Guid.NewGuid().ToString())).First();

        /// <summary>
        /// Uploads files.
        /// Returns collection of upload id and filename.
        /// </summary>
        /// <returns>Files upload results.</returns>
        [MimeMultipart]
        [HttpPost]
        [ActionName("UploadFiles")]
        public async Task<IEnumerable<FileSafeResult>> UploadFiles(HttpRequestMessage request) => await Upload(request, Guid.NewGuid().ToString());

        /// <summary>
        /// Uploads files.
        /// Returns collection of upload id and filename.
        /// </summary>
        /// <returns>Files upload results.</returns>
        [MimeMultipart]
        [HttpPost]
        [ActionName("UploadMultipleFiles")]
        public async Task<IEnumerable<FileSafeResult>> UploadMultipleFiles(HttpRequestMessage request)
        {
            // MultipartFormDataStreamProvider reads form data only after file processing
            // so we have to put files to the temporary folder firstly
            var tempFolder = PathProcessor.CreateFolder(Guid.NewGuid().ToString());
            var uploadProvider = new MultipartFormDataStreamProviderSafe(tempFolder);
            await request.Content.ReadAsMultipartAsync(uploadProvider);

            // and now we can move files to the "idUpload" folder
            var idUpload = uploadProvider.FormData["idUpload"];
            var idUploadFolder = PathProcessor.CreateFolder(idUpload);
            return uploadProvider.FileData.Select(file => MoveFile(idUploadFolder, idUpload, file));
        }


        /// <summary>
        /// Downloads file with specified upload id and filename.
        /// </summary>
        /// <param name="id">Download id.</param>
        /// <param name="file">File name.</param>
        /// <returns>Binary stream mime type application/octet-stream</returns>	
        [HttpGet]
        [ActionName("DownloadFile")]
        public HttpResponseMessage DownloadFile(string id, string file) => Download(id, file);

        /// <summary>
        /// Sends download url to specified email.
        /// </summary>
        /// <param name="product">Product.</param>
        /// <param name="action">Action.</param>
        /// <param name="id">Download id.</param>
        /// <param name="file">File name.</param>
        /// <param name="email">Email.</param>
        [MimeMultipart]
        [HttpPost]
        [ActionName("UrlToEmail")]
        public void UrlToEmail(ProductFamilyNameKeysEnum product, string action, string id, string file, string email) => SendDownloadUrlToEmail(product, action, id, file, email);

        /// <summary>
        /// Test fail inside controller.
        /// If code not specified thrown NotImplementedException
        /// </summary>
        /// <param name="id">HTTP code</param>
        /// <param name="message">Optional message</param>
        /// <returns>Throws exception</returns>
        [MimeMultipart]
        [HttpGet]
        [ActionName("TestFail")]
        public HttpResponseMessage TestFail(int? id = null, string message = null)
        {
            if (id == null)
                throw new NotImplementedException(message);
            throw HttpHelper.HttpResult((HttpStatusCode) id, message);
        }

        [HttpPost]
        [ActionName("Delete")]
        public HttpResponseMessage Delete(JObject obj)
        {
            var folderName = Convert.ToString(obj["FolderName"]);
            var sourceFolder = AppSettings.OutputDirectory + folderName;

            if (folderName.IsEmpty() || !Directory.Exists(sourceFolder))
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            var httpResponseMessage = new HttpResponseMessage();
            try
            {
                Directory.Delete(sourceFolder, true);
            }
            catch (Exception e)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.InternalServerError;

                Console.WriteLine(e);
                throw;
            }
            finally
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
            }

            return httpResponseMessage;
        }
    }
}