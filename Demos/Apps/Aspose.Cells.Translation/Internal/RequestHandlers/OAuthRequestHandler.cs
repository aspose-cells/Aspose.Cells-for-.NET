using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Aspose.Cells.Translation.Api;
using Newtonsoft.Json;

namespace Aspose.Cells.Translation.Internal.RequestHandlers
{
    internal class OAuthRequestHandler : IRequestHandler
    {
        private readonly TranslationConfiguration _configuration;
        private readonly ApiInvoker _apiInvoker;

        private string _accessToken;
        private string _refreshToken;

        public OAuthRequestHandler(TranslationConfiguration configuration)
        {
            _configuration = configuration;

            var requestHandlers = new List<IRequestHandler>
            {
                new DebugLogRequestHandler(_configuration),
                new ApiExceptionRequestHandler()
            };
            _apiInvoker = new ApiInvoker(requestHandlers);
        }

        public string ProcessUrl(string url)
        {
            if (_configuration.AuthType != AuthType.OAuth2)
            {
                return url;
            }

            if (string.IsNullOrEmpty(_accessToken))
            {
                RequestToken();
            }

            return url;
        }

        public void BeforeSend(WebRequest request, Stream streamToSend)
        {
            if (_configuration.AuthType != AuthType.OAuth2)
            {
                return;
            }

            request.Headers.Add("Authorization", "Bearer " + _accessToken);
        }

        public void ProcessResponse(HttpWebResponse response, Stream resultStream)
        {
            if (_configuration.AuthType != AuthType.OAuth2)
            {
                return;
            }

            if (response.StatusCode != HttpStatusCode.Unauthorized) return;
            RefreshToken();

            throw new Exception();
        }

        private void RefreshToken()
        {
            var requestUrl = _configuration.ApiBaseUrl + "/oauth2/token";

            var postData = "grant_type=refresh_token";
            postData += "&refresh_token=" + _refreshToken;

            var responseString = _apiInvoker.InvokeApi(
                requestUrl,
                "POST",
                postData,
                contentType: "application/x-www-form-urlencoded");

            var result =
                (GetAccessTokenResult) SerializationHelper.Deserialize(responseString, typeof(GetAccessTokenResult));

            _accessToken = result.AccessToken;
            _refreshToken = result.RefreshToken;
        }

        private void RequestToken()
        {
            var requestUrl = _configuration.ApiBaseUrl + "/oauth2/token";

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
            _refreshToken = result.RefreshToken;
        }

        private class GetAccessTokenResult
        {
            [JsonProperty(PropertyName = "access_token")]
            public string AccessToken { get; set; }

            [JsonProperty(PropertyName = "refresh_token")]
            public string RefreshToken { get; set; }
        }
    }
}