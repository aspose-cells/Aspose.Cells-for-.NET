namespace Aspose.Cells.Common.CloudHelper.Invoker
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    ///     Api Invoker
    /// </summary>
    internal class ApiInvoker
    {
        private readonly Dictionary<string, string> defaultHeaderMap = new Dictionary<string, string>();
        private readonly List<IRequestHandler> requestHandlers;
        private readonly int timeout;

        /// <summary>
        ///     Public constructor
        /// </summary>
        /// <param name="requestHandlers"></param>
        /// <param name="timeout"></param>
        public ApiInvoker(List<IRequestHandler> requestHandlers, int timeout)
        {
            this.requestHandlers = requestHandlers;
            this.timeout = timeout;
        }

        public async Task<T> InvokeApiAsync<T>(
            string path,
            string method,
            string body = null,
            Dictionary<string, string> headerParams = null,
            Dictionary<string, object> formParams = null,
            string contentType = "application/json") where T : class
        {
            return await InvokeInternalAsync<T>(path, method, body, headerParams, formParams, contentType);
        }

        private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
        {
            Stream formDataStream = new MemoryStream();
            var needsClrf = false;

            if (postParameters.Count > 1)
            {
                foreach (var param in postParameters)
                {
                    // Thanks to feedback from commenters, add a CRLF to allow multiple parameters to be added.
                    // Skip it on the first parameter, add it to subsequent parameters.
                    if (needsClrf)
                    {
                        formDataStream.Write(Encoding.UTF8.GetBytes("\r\n"), 0, Encoding.UTF8.GetByteCount("\r\n"));
                    }

                    needsClrf = true;

                    if (param.Value is FormFileInfo fileInfo)
                    {
                        var postData =
                            string.Format(
                                "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n",
                                boundary,
                                param.Key,
                                fileInfo.MimeType);
                        formDataStream.Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetByteCount(postData));

                        // Write the file data directly to the Stream, rather than serializing it to a string.
                        formDataStream.Write(fileInfo.FileContent, 0, fileInfo.FileContent.Length);
                    }
                    else
                    {
                        var stringData = JsonSerializationHelper.Serialize(param.Value);
                        var postData =
                            string.Format(
                                "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                                boundary,
                                param.Key,
                                stringData);
                        formDataStream.Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetByteCount(postData));
                    }
                }

                // Add the end of the request.  Start with a newline
                var footer = "\r\n--" + boundary + "--\r\n";
                formDataStream.Write(Encoding.UTF8.GetBytes(footer), 0, Encoding.UTF8.GetByteCount(footer));
            }
            else
            {
                foreach (var param in postParameters)
                    if (param.Value is FormFileInfo fileInfo)
                    {
                        var postData =
                            string.Format(
                                "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n",
                                boundary,
                                param.Key,
                                fileInfo.MimeType);
                        formDataStream.Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetByteCount(postData));

                        // Write the file data directly to the Stream, rather than serializing it to a string.
                        formDataStream.Write(fileInfo.FileContent, 0, fileInfo.FileContent.Length);
                        var footer = "\r\n--" + boundary + "--\r\n";
                        formDataStream.Write(Encoding.UTF8.GetBytes(footer), 0, Encoding.UTF8.GetByteCount(footer));
                        // Write the file data directly to the Stream, rather than serializing it to a string.
                        //formDataStream.Write(fileInfo.FileContent, 0, fileInfo.FileContent.Length);
                    }
                    else if (param.Value is byte[])
                    {
                        // Write the file data directly to the Stream, rather than serializing it to a string.
                        formDataStream.Write(param.Value as byte[], 0, (param.Value as byte[]).Length);
                    }
                    else
                    {
                        string postData;
                        if (!(param.Value is string))
                        {
                            postData = JsonSerializationHelper.Serialize(param.Value);
                        }
                        else
                        {
                            postData = (string)param.Value;
                        }

                        formDataStream.Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetByteCount(postData));
                    }
            }

            // Dump the Stream into a byte[]
            formDataStream.Position = 0;
            var formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length);
            formDataStream.Close();

            return formData;
        }

        private void AddDefaultHeader(string key, string value)
        {
            if (!defaultHeaderMap.ContainsKey(key))
            {
                defaultHeaderMap.Add(key, value);
            }
        }

        private async Task<T> InvokeInternalAsync<T>(
            string path,
            string method,
            string body,
            Dictionary<string, string> headerParams,
            Dictionary<string, object> formParams,
            string contentType) where T : class
        {
            if (formParams == null)
            {
                formParams = new Dictionary<string, object>();
            }

            if (headerParams == null)
            {
                headerParams = new Dictionary<string, string>();
            }

            requestHandlers.ForEach(p => path = p.ProcessUrl(path));

            WebRequest request;
            try
            {
                request = PrepareRequest(path, method, formParams, headerParams, body, contentType);
                return await ReadResponseAsync<T>(request);
            }
            catch (Exception)
            {
                request = PrepareRequest(path, method, formParams, headerParams, body, contentType);
                return await ReadResponseAsync<T>(request);
            }
        }

        private WebRequest PrepareRequest(string path, string method, Dictionary<string, object> formParams,
            Dictionary<string, string> headerParams, string body, string contentType)
        {
            var client = WebRequest.Create(path);
            client.Timeout = timeout;

            client.Method = method;

            byte[] formData = null;
            if (formParams.Count > 0)
            {
                if (formParams.Count > 0)
                {
                    string formDataBoundary = Guid.NewGuid().ToString("D");
                    client.ContentType = "multipart/form-data; boundary=" + formDataBoundary;
                    formData = GetMultipartFormData(formParams, formDataBoundary);
                }
                else
                {
                    client.ContentType = "multipart/form-data";
                    formData = GetMultipartFormData(formParams, string.Empty);
                }

                client.ContentLength = formData.Length;
            }
            else
            {
                client.ContentType = contentType;
            }

            foreach (var headerParamsItem in headerParams)
                client.Headers.Add(headerParamsItem.Key, headerParamsItem.Value);

            foreach (var defaultHeaderMapItem in defaultHeaderMap)
                if (!headerParams.ContainsKey(defaultHeaderMapItem.Key))
                    client.Headers.Add(defaultHeaderMapItem.Key, defaultHeaderMapItem.Value);

            MemoryStream streamToSend = null;
            try
            {
                switch (method)
                {
                    case "GET":
                        break;
                    case "POST":
                    case "PUT":
                    case "DELETE":
                        streamToSend = new MemoryStream();

                        if (formData != null)
                            streamToSend.Write(formData, 0, formData.Length);

                        if (body != null)
                        {
                            var requestWriter = new StreamWriter(streamToSend);
                            requestWriter.Write(body);
                            requestWriter.Flush();
                        }

                        break;
                    default:
                        throw new ApplicationException("Unknown method type " + method);
                }

                requestHandlers.ForEach(p => p.BeforeSend(client, streamToSend));

                if (streamToSend != null)
                    using (var requestStream = client.GetRequestStream())
                    {
                        streamToSend.Seek(0, SeekOrigin.Begin);
                        streamToSend.CopyTo(requestStream);
                    }
            }
            finally
            {
                if (streamToSend != null)
                    streamToSend.Dispose();
            }

            return client;
        }

        private async Task<T> ReadResponseAsync<T>(WebRequest client) where T : class
        {
            var webResponse = (HttpWebResponse) await GetResponseAsync(client);
            var resultStream = new MemoryStream();

            var responseStream = webResponse.GetResponseStream();
            if (responseStream != null)
                responseStream.CopyTo(resultStream);

            try
            {
                requestHandlers.ForEach(p => p.ProcessResponse(webResponse, resultStream));

                resultStream.Position = 0;

                if (typeof(T) == typeof(HttpWebResponse))
                    return webResponse as T;

                if (typeof(T) == typeof(Stream))
                    return resultStream as T;

                var str = Encoding.UTF8.GetString(resultStream.ToArray());

                if (typeof(T) == typeof(string))
                    return str as T;

                if (typeof(T) == typeof(JObject))
                    return JObject.Parse(str) as T;

                return JsonSerializationHelper.Deserialize(str, typeof(T)) as T;
            }
            catch (Exception)
            {
                resultStream.Dispose();
                throw;
            }
        }

        private async Task<WebResponse> GetResponseAsync(WebRequest request)
        {
            try
            {
                return await request.GetResponseAsync();
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    return wex.Response;
                }

                throw;
            }
        }
    }
}