namespace Aspose.Cells.Common.CloudHelper
{
    using Invoker;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    public class CellsCloudService : ICellsCloudService
    {
        private ApiInvoker apiInvoker;
        public CellsCloudService()
        {
            var requestHandlers = new List<IRequestHandler>
            {
                new ApiExceptionRequestHandler()
            };

            apiInvoker = new ApiInvoker(requestHandlers, 30000);
        }
        public async Task<string> GetJwtTokenUsingClientCredentialsAsync()
        {
            //sessionId, "https://api-qa.aspose.cloud", "91A2FD07-BBA1-4B32-9112-ABFB1FE8AEBD", "0fbf678c5ecabdb5caca48452a736dd0"

            var requestUrl = string.Format("{0}/connect/token", "https://api-qa.aspose.cloud");

            var postData = "grant_type=client_credentials";
            postData += "&client_id=" + "91A2FD07-BBA1-4B32-9112-ABFB1FE8AEBD";
            postData += "&client_secret=" + "0fbf678c5ecabdb5caca48452a736dd0";

            var result = await apiInvoker.InvokeApiAsync<JwtTokenResource>(requestUrl, "POST", postData, contentType: "application/x-www-form-urlencoded");
            return result.AccessToken;
        }
        public async Task<Stream> Convert( string requestId, string token, string filename, Stream stream, string format)
        {
            var requestUrl = string.Format("{0}/v3.0/cells/convert?format={1}", "https://api-qa.aspose.cloud", format.Substring(1));

            var headerParams = new Dictionary<string, string>();
            headerParams.Add("Authorization", "Bearer " + token);
            //headerParams.Add("RequestId", requestId);

            Dictionary<string, object> formParams = new Dictionary<string, object>();
            formParams.Add("File", new FormFileInfo
            {
                Name = filename,
                MimeType = format,
                FileContent = stream.ReadAll()
            });

            try
            {
                return await apiInvoker.InvokeApiAsync<Stream>(
                    requestUrl, "PUT", null, headerParams,
                    formParams, "application/octet-stream");
            }
            catch (Exception webException)
            {

                throw webException;
            }
        }

        public void Dispose()
        {
            
        }

       
    }
}
