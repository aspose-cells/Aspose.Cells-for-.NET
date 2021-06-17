namespace Aspose.Cells.Common.CloudHelper.Invoker
{
    using System.IO;
    using System.Net;
    /// <summary>
    ///     IRequestHandler
    /// </summary>
    internal interface IRequestHandler
    {
        /// <summary>
        ///     ProcessUrl
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        string ProcessUrl(string url);

        /// <summary>
        ///     BeforeSend
        /// </summary>
        /// <param name="request"></param>
        /// <param name="streamToSend"></param>
        void BeforeSend(WebRequest request, Stream streamToSend);

        /// <summary>
        ///     ProcessResponse
        /// </summary>
        /// <param name="response"></param>
        /// <param name="resultStream"></param>
        void ProcessResponse(HttpWebResponse response, Stream resultStream);
    }
}