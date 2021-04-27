using System;
using System.IO;
using System.Net;
using Aspose.Cells.API.Api;
using Aspose.Cells.API.Models;

namespace Aspose.Cells.API.Internal.RequestHandlers
{
    internal class ApiExceptionRequestHandler : IRequestHandler
    {
        public string ProcessUrl(string url)
        {
            return url;
        }

        public void BeforeSend(WebRequest request, Stream streamToSend)
        {
        }

        public void ProcessResponse(HttpWebResponse response, Stream resultStream)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                ThrowApiException(response, resultStream);
            }
        }

        private static void ThrowApiException(HttpWebResponse webResponse, Stream resultStream)
        {
            Exception resultException;
            try
            {
                resultStream.Position = 0;
                using (var responseReader = new StreamReader(resultStream))
                {
                    var responseData = responseReader.ReadToEnd();
                    Console.WriteLine(responseData);
                    var errorResponse = (TranslationErrorResponse) SerializationHelper.Deserialize(responseData, typeof(TranslationErrorResponse));
                    if (string.IsNullOrEmpty(errorResponse.Status))
                    {
                        errorResponse.Message = responseData;
                    }

                    resultException = new ApiException((int) webResponse.StatusCode, errorResponse.Message);
                }
            }
            catch (Exception)
            {
                throw new ApiException((int) webResponse.StatusCode, webResponse.StatusDescription);
            }

            throw resultException;
        }
    }
}