using System.Diagnostics;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Aspose.Cells.API.Controllers;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Helpers
{
    /// <summary>
    /// Default Exception Filter Attribute
    /// </summary>
    public class DefaultExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// On Exception
        /// </summary>
        public override void OnException(HttpActionExecutedContext context)
        {
            var productFamily = (context.ActionContext?.ControllerContext?.Controller as BaseApiController)?.ProductFamily ?? ProductFamilyNameKeysEnum.unassigned;
            var actionName = (context.ActionContext?.ActionDescriptor as ReflectedHttpActionDescriptor)?.ActionName ?? new StackTrace(context.Exception).GetFrame(0).GetMethod().Name;

            NLogger.LogError(context.Exception, $"{actionName} error", actionName, productFamily, "");

            context.Response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
            {
                ReasonPhrase = actionName
            };
        }
    }
}