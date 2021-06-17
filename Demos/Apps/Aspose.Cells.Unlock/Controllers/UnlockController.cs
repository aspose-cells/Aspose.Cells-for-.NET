using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Unlock.Controllers
{
    public class UnlockController : UIControllerBase
    {
        public UnlockController(IWebHostEnvironment env, ILogger<UnlockController> logger) : base(env, logger)
        {
        }

        public ActionResult Unlock()
        {
            var model = new ViewModel(this, "Unlock")
            {
                ControlsView = "~/Pages/UnlockControls.cshtml",
                ShowViewerButton = false
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Unlock.cshtml", model);
        }
    }
}