using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Aspose.Cells.Translation.Api;

namespace Aspose.Cells.Translation.Internal.RequestHandlers
{
    internal class AuthWithSignatureRequestHandler : IRequestHandler
    {
        private readonly TranslationConfiguration _configuration;

        public AuthWithSignatureRequestHandler(TranslationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ProcessUrl(string url)
        {
            if (_configuration.AuthType != AuthType.RequestSignature)
            {
                return url;
            }

            url = UrlHelper.AddQueryParameterToUrl(url, "appSid", _configuration.ClientId);
            url = Sign(url);

            return url;
        }

        public void BeforeSend(WebRequest request, Stream streamToSend)
        {
        }

        public void ProcessResponse(HttpWebResponse response, Stream resultStream)
        {
        }

        private string Sign(string url)
        {
            var uriBuilder = new UriBuilder(url);

            // Remove final slash here as it can be added automatically.
            uriBuilder.Path = uriBuilder.Path.TrimEnd('/');

            // Compute the hash.
            var privateKey = Encoding.UTF8.GetBytes(_configuration.ClientSecret);
            var algorithm = new HMACSHA1(privateKey);

            var sequence = Encoding.ASCII.GetBytes(uriBuilder.Uri.AbsoluteUri);
            var hash = algorithm.ComputeHash(sequence);
            var signature = Convert.ToBase64String(hash);

            // Remove invalid symbols.
            signature = signature.TrimEnd('=');
            signature = HttpUtility.UrlEncode(signature);

            // Convert codes to upper case as they can be updated automatically.
            signature = Regex.Replace(signature, "%[0-9a-f]{2}", e => e.Value.ToUpper());

            // Add the signature to query string.
            return $"{uriBuilder.Uri.AbsoluteUri}&signature={signature}";
        }
    }
}