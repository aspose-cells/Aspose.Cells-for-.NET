using System.IO;
using System.Net;

namespace Aspose.Cells.API.Internal
{
    internal interface IRequestHandler
    {
        string ProcessUrl(string url);

        void BeforeSend(WebRequest request, Stream streamToSend);

        void ProcessResponse(HttpWebResponse response, Stream resultStream);
    }
}