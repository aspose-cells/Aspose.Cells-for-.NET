namespace Aspose.Cells.Common.CloudHelper.Invoker
{
    using Newtonsoft.Json;
    /// <summary>
    ///     Access Token Result
    /// </summary>
    internal class JwtTokenResource
    {
        /// <summary>
        ///     JWT access token
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        ///     Expires in
        /// </summary>
        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }

        /// <summary>
        ///     Token type
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}