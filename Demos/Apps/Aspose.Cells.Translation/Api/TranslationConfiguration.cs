 namespace Aspose.Cells.Translation.Api
{
    public class TranslationConfiguration
    {
        public string ApiBaseUrl { get; set; }

        public string ClientSecret { get; set; }

        public string ClientId { get; set; }

        public string JwtToken { get; set; }

        public bool DebugMode { get; set; }

        public AuthType AuthType { get; set; }

        public ApiVersion ApiVersion { get; set; }

        public TranslationConfiguration()
        {
            ApiBaseUrl = "https://api.groupdocs.cloud";
            DebugMode = false;
            ApiVersion = ApiVersion.V1;
            AuthType = AuthType.JWT;
        }

        internal string GetApiRootUrl()
        {
            var result = ApiBaseUrl + "/v" + ApiVersion + "/translation";

            return result.EndsWith("/") ? result.Substring(0, result.Length - 1) : result;
        }
    }
}