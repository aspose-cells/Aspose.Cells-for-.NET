using System.IO;
using System.Net;
using Aspose.Cells.Translation.Api;

namespace Aspose.Cells.Translation.Internal.RequestHandlers
{
    internal class ExternalAuthorizationRequestHandler : IRequestHandler
    {
        private readonly TranslationConfiguration _configuration;

        public ExternalAuthorizationRequestHandler(TranslationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ProcessUrl(string url)
        {
            return url;
        }

        public void BeforeSend(WebRequest request, Stream streamToSend)
        {
            if (_configuration.AuthType == AuthType.OAuth2 && string.IsNullOrEmpty(_configuration.JwtToken))
            {
                throw new ApiException(401, "Authorization header value required");
            }

            request.Headers.Add("Authorization", "Bearer " + _configuration.JwtToken);
        }

        public void ProcessResponse(HttpWebResponse response, Stream resultStream)
        {
        }
    }
}