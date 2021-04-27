using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using Aspose.Cells.API.Api;

namespace Aspose.Cells.API.Internal.RequestHandlers
{
    internal class DebugLogRequestHandler : IRequestHandler
    {
        private readonly Configuration _configuration;

        public DebugLogRequestHandler(Configuration configuration)
        {
            _configuration = configuration;
        }

        public string ProcessUrl(string url)
        {
            return url;
        }

        public void BeforeSend(WebRequest request, Stream streamToSend)
        {
            if (_configuration.DebugMode)
            {
                LogRequest(request, streamToSend);
            }
        }

        public void ProcessResponse(HttpWebResponse response, Stream resultStream)
        {
            if (!_configuration.DebugMode) return;
            resultStream.Position = 0;
            LogResponse(response, resultStream);
        }

        private static void LogRequest(WebRequest request, Stream streamToSend)
        {
            var header = $"{request.Method}: {request.RequestUri}";
            var sb = new StringBuilder();

            FormatHeaders(sb, request.Headers);
            if (streamToSend != null)
            {
                streamToSend.Position = 0;
                StreamHelper.CopyStreamToStringBuilder(sb, streamToSend);
                streamToSend.Position = 0;
            }

            Log(header, sb);
        }

        private static void LogResponse(HttpWebResponse response, Stream resultStream)
        {
            var header = $"\r\nResponse {(int) response.StatusCode}: {response.StatusCode}";
            var sb = new StringBuilder();

            FormatHeaders(sb, response.Headers);
            StreamHelper.CopyStreamToStringBuilder(sb, resultStream);
            Log(header, sb);
        }

        private static void FormatHeaders(StringBuilder sb, WebHeaderCollection headerDictionary)
        {
            foreach (var key in headerDictionary.AllKeys)
            {
                sb.Append(key);
                sb.Append(": ");
                sb.AppendLine(headerDictionary[key]);
            }
        }

        private static void Log(string header, StringBuilder sb)
        {
            Trace.WriteLine(header);
            Trace.WriteLine(sb.ToString());
        }
    }
}