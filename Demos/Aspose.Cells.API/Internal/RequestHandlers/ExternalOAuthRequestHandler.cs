using System.IO;
using System.Net;
using Aspose.Cells.API.Api;

namespace Aspose.Cells.API.Internal.RequestHandlers
{
    internal class ExternalAuthorizationRequestHandler : IRequestHandler
    {
        private readonly Configuration _configuration;

        public ExternalAuthorizationRequestHandler(Configuration configuration)
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