using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Cells.Translation.Internal;
using Aspose.Cells.Translation.Internal.RequestHandlers;
using Aspose.Cells.Translation.Models;
using Aspose.Cells.Translation.Models.Requests;

namespace Aspose.Cells.Translation.Api
{
    public class FileApi
    {
        private readonly ApiInvoker _apiInvoker;
        private readonly TranslationConfiguration _configuration;

        public FileApi(TranslationConfiguration configuration)
        {
            _configuration = configuration;

            var requestHandlers = new List<IRequestHandler>();
            switch (_configuration.AuthType)
            {
                case AuthType.RequestSignature:
                    requestHandlers.Add(new AuthWithSignatureRequestHandler(_configuration));
                    break;
                case AuthType.OAuth2:
                    requestHandlers.Add(new OAuthRequestHandler(_configuration));
                    break;
                case AuthType.ExternalAuth:
                    requestHandlers.Add(new ExternalAuthorizationRequestHandler(_configuration));
                    break;
                case AuthType.JWT:
                    requestHandlers.Add(new JwtRequestHandler(_configuration));
                    break;
            }

            requestHandlers.Add(new DebugLogRequestHandler(_configuration));
            requestHandlers.Add(new ApiExceptionRequestHandler());
            _apiInvoker = new ApiInvoker(requestHandlers);
        }

        public Stream DownloadFile(DownloadFileRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.Path == null)
            {
                throw new ApiException(400, "Missing required parameter 'path' when calling DownloadFile");
            }

            // create path and map variables
            var resourcePath = _configuration.GetApiRootUrl() + "/storage/file/{path}";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "path", request.Path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storageName", request.StorageName);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "versionId", request.VersionId);

            try
            {
                return _apiInvoker.InvokeBinaryApi(
                    resourcePath,
                    "GET",
                    null,
                    null,
                    null);
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }

        public FilesUploadResult UploadFile(UploadFileRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.Path == null)
            {
                throw new ApiException(400, "Missing required parameter 'path' when calling UploadFile");
            }

            // verify the required parameter 'file' is set
            if (request.File == null)
            {
                throw new ApiException(400, "Missing required parameter 'file' when calling UploadFile");
            }

            // create path and map variables
            var resourcePath = _configuration.GetApiRootUrl() + "/storage/file/{path}";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "path", request.Path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storageName", request.StorageName);

            if (request.File != null)
            {
                formParams.Add("file", _apiInvoker.ToFileInfo(request.File, "File"));
            }

            try
            {
                var response = _apiInvoker.InvokeApi(
                    resourcePath,
                    "PUT",
                    null,
                    null,
                    formParams);
                if (response != null)
                {
                    return (FilesUploadResult) SerializationHelper.Deserialize(response, typeof(FilesUploadResult));
                }

                var errors = new List<Error> {new Error {Code = "500", Message = "response null"}};
                return new FilesUploadResult {Errors = errors};
            }
            catch (ApiException ex)
            {
                var errors = new List<Error> {new Error {Code = ex.ErrorCode.ToString(), Message = ex.Message, Description = ex.StackTrace}};
                return new FilesUploadResult {Errors = errors};
            }
        }
    }
}