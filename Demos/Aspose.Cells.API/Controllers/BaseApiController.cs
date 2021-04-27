using System.Web.Http;
using Aspose.Cells.API.Helpers;

namespace Aspose.Cells.API.Controllers
{
    /// <summary>
    /// Base class for API controllers.
    /// </summary>
    // [EnableCors("*", "*", "*")]
    [DefaultExceptionFilter]
    public abstract class BaseApiController : ApiController
    {
    }
}