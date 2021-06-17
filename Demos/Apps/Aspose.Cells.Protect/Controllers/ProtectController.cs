using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Protect.Controllers
{
    public class ProtectController : UIControllerBase
    {
        public ProtectController(IWebHostEnvironment env, ILogger<ProtectController> logger) : base(env, logger)
        {
        }

        public ActionResult Protect()
        {
            var model = new ViewModel(this, "Protect")
            {
                ControlsView = "~/Pages/ProtectControls.cshtml",
                ShowViewerButton = false
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Protect.cshtml", model);
        }
    }
}
