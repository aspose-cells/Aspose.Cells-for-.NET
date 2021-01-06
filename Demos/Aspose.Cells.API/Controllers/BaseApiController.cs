using System.Web.Http;
using Aspose.Cells.API.Helpers;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    /// <summary>
    /// Base class for API controllers.
    /// </summary>
    // [EnableCors("*", "*", "*")]
    [DefaultExceptionFilter]
    public abstract class BaseApiController : ApiController
    {
        /// <summary>
        /// Product family.
        /// </summary>
        public ProductFamilyNameKeysEnum ProductFamily { get; private set; }

        /// <summary>
        /// BaseApiController constructor
        /// </summary>
        /// <param name="productFamily">Product family. Used in logging.</param>
        public BaseApiController(ProductFamilyNameKeysEnum productFamily)
        {
            ProductFamily = productFamily;
        }
    }
}