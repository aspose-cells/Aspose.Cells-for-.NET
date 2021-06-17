using System;
using System.Threading.Tasks;
using Aspose.Cells.Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aspose.Cells.Common.Controllers
{
    public sealed class ReportController : ControllerBase
    {
        private readonly IStorageService _storage;

        public ReportController(IStorageService storage)
        {
            _storage = storage;
        }

        [HttpPost]
        [ActionName("Error")]
        public async Task<ReportResult> Error(ReportModel model)
        {
            try
            {
                return await Task.Run(() => ReportService.Submit(model, _storage));
            }
            catch (Exception e)
            {
                return new ReportResult
                {
                    StatusCode = 500,
                    Status = e.Message
                };
            }
        }
    }
}