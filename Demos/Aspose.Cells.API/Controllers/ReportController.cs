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
                return await Task.Run(() => ReportService.Submit(model));
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                NLogger.LogError("Report", "Error", exception.Message, "null");

                return new ReportResult
                {
                    StatusCode = 500,
                    Status = exception.Message
                };
            }
        }
    }
}