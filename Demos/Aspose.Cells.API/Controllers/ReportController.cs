using System;
using System.Threading.Tasks;
using System.Web.Http;
using Aspose.Cells.API.Services;
using Tools.Foundation.Models;

namespace Aspose.Cells.API.Controllers
{
    public sealed class ReportController : BaseApiController
    {
        [HttpPost]
        [ActionName("Error")]
        public async Task<ReportResult> Error([FromBody] ReportModel model)
        {
            try
            {
                return ReportService.Submit(model);
            }
            catch (Exception ex)
            {
                NLogger.LogError(ex, "Report Error Forum");
                return new ReportResult
                {
                    StatusCode = 500,
                    Status = ex.Message
                };
            }
        }

        public ReportController() : base(ProductFamilyNameKeysEnum.unassigned)
        {
        }
    }
}