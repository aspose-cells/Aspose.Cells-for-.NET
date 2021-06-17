using System.Collections.Generic;
using System.IO;
using System.Net;
using Aspose.Cells.Translation.Api;
using Newtonsoft.Json;

namespace Aspose.Cells.Translation.Internal.RequestHandlers
{
    internal class JwtRequestHandler : IRequestHandler
    {
        private readonly TranslationConfiguration _configuration;
        private readonly ApiInvoker _apiInvoker;

        private string _accessToken;

        public JwtRequestHandler(TranslationConfiguration configuration)
        {
            _configuration = configuration;

            var requestHandlers = new List<IRequestHandler> {new DebugLogRequestHandler(_configuration), new ApiExceptionRequestHandler()};
            _apiInvoker = new ApiInvoker(requestHandlers);
        }

        public string ProcessUrl(string url)
        {
            if (string.IsNullOrEmpty(_accessToken))
                RequestToken();
            return url;
        }

        public void BeforeSend(WebRequest request, Stream streamToSend)
        {
            request.Headers.Add("Authorization", "Bearer " + _accessToken);
        }

        public void ProcessResponse(HttpWebResponse response, Stream resultStream)
        {
        }

        private void RequestToken()
        {
            var requestUrl = _configuration.ApiBaseUrl + "/connect/token";

            var postData = "grant_type=client_credentials";
            postData += "&client_id=" + _configuration.ClientId;
            postData += "&client_secret=" + _configuration.ClientSecret;

            var responseString = _apiInvoker.InvokeApi(
                requestUrl,
                "POST",
                postData,
                contentType: "application/x-www-form-urlencoded");

            var result =
                (GetAccessTokenResult) SerializationHelper.Deserialize(responseString, typeof(GetAccessTokenResult));

            _accessToken = result.AccessToken;
        }

        private class GetAccessTokenResult
        {
            [JsonProperty(PropertyName = "access_token")]
            public string AccessToken { get; set; }
        }
    }
}