using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Esign.Controllers
{
    public class EsignController : UIControllerBase
    {
        public EsignController(IWebHostEnvironment env, ILogger<EsignController> logger) : base(env, logger)
        {
        }

        public IActionResult Esign()
        {
            var model = new ViewModel(this, "Esign")
            {
                ControlsView = "~/Pages/EsignControls.cshtml",
                ShowViewerButton = false
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Esign.cshtml", model);
        }
    }
}