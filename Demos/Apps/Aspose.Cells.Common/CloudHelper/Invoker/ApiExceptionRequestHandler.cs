
namespace Aspose.Cells.Common.CloudHelper.Invoker
{
    using System;
    using System.IO;
    using System.Net;

    /// <summary>
    ///     Api Exception Request Handler
    /// </summary>
    internal class ApiExceptionRequestHandler : IRequestHandler
    {
        private string method;

        public string ProcessUrl(string url)
        {
            return url;
        }

        public void BeforeSend(WebRequest request, Stream streamToSend)
        {
            method = request.Method;
        }

        public void ProcessResponse(HttpWebResponse response, Stream resultStream)
        {
            if (method == "DELETE" && response.StatusCode == HttpStatusCode.NoContent)
                return;

            if (method == "POST" && response.StatusCode == HttpStatusCode.Created)
                return;

            if (method == "PUT" && response.StatusCode == HttpStatusCode.Created)
                return;

            if (response.StatusCode != HttpStatusCode.OK)
                ThrowApiException(response, resultStream);
        }

        private void ThrowApiException(HttpWebResponse webResponse, Stream resultStream)
        {
            try
            {
                resultStream.Position = 0;
                using (var responseReader = new StreamReader(resultStream))
                {
                    var responseData = responseReader.ReadToEnd();
                    if (string.IsNullOrEmpty(responseData))
                    {
                        var message = webResponse.GetResponseHeader("WWW-Authenticate");
                        if (webResponse.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            throw new ApplicationException(message);
                        }
                        else
                        {
                            throw new ApplicationException("An error occured.");
                        }
                    }

                    var errorResponse = (ApiErrorResponse)JsonSerializationHelper.Deserialize(responseData, typeof(ApiErrorResponse));

                    if (errorResponse == null)
                    {
                        errorResponse = new ApiErrorResponse();
                        errorResponse.Error = new ApplicationException(responseData);
                    }

                    throw errorResponse.Error;
                }
            }
           
            catch (Exception)
            {
                throw ;
            }
        }
    }
}