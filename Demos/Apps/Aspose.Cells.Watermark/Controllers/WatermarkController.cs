using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Watermark.Controllers
{
    public class WatermarkController : UIControllerBase
    {
        public WatermarkController(IWebHostEnvironment env, ILogger<WatermarkController> logger) : base(env, logger)
        {
        }

        public ActionResult Watermark()
        {
            var model = new ViewModel(this, "Watermark");
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Watermark.cshtml", model);
        }
    }
}