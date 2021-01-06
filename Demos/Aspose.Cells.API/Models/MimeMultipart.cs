using System.Web.Http.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Web.Http.Filters;

namespace Aspose.Cells.API.Models
{
    ///<Summary>
    /// MimeMultipart class
    ///</Summary>
    public class MimeMultipart : ActionFilterAttribute
    {
        ///<Summary>
        /// MimeMultipart class OnActionExecuting method
        ///</Summary>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(
                        HttpStatusCode.UnsupportedMediaType)
                );
            }
        }

        ///<Summary>
        /// MimeMultipart class OnActionExecuting method
        ///</Summary>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
        }
    }
}