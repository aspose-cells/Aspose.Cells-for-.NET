using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Aspose.Cells.API.Helpers
{
    /// <summary>
    /// HttpHelper Class
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// Instantiates HttpResponseException instance.
        /// </summary>
        /// <param name="message">Reason message</param>
        /// <param name="httpCode">HTTP status code.</param>
        /// <returns></returns>
        public static HttpResponseException HttpResult(HttpStatusCode httpCode, string message = null)
            =>
                new HttpResponseException(
                    new HttpResponseMessage(httpCode)
                    {
                        ReasonPhrase = message
                    }
                );

        /// <summary>
        /// Instantiate HTTP 400 exception.
        /// </summary>
        /// <param name="message">Reason message</param>
        /// <returns>HttpResponseException</returns>
        public static HttpResponseException Http400(string message = null) => HttpResult(HttpStatusCode.BadRequest, message);

        /// <summary>
        /// Throws HTTP 400 exception.
        /// </summary>
        /// <param name="message">Reason message</param>
        public static void Throw400(string message = null) => throw Http400(message);

        /// <summary>
        /// Instantiate HTTP 404 exception.
        /// </summary>
        /// <param name="message">Reason message</param>
        /// <returns>HttpResponseException</returns>
        public static HttpResponseException Http404(string message = null) => HttpResult(HttpStatusCode.NotFound, message);

        /// <summary>
        /// Throws HTTP 404 exception.
        /// </summary>
        /// <param name="message">Reason message</param>
        public static void Throw404(string message = null) => throw Http404(message);

        /// <summary>
        /// Instantiate HTTP 500 exception.
        /// </summary>
        /// <param name="message">Reason message</param>
        /// <returns></returns>
        public static HttpResponseException Http500(string message = null) => HttpResult(HttpStatusCode.InternalServerError, message);

        /// <summary>
        /// Throws HTTP 500 exception.
        /// </summary>
        /// <param name="message">Reason message</param>
        public static void Throw500(string message = null) => throw Http500(message);
    }
}