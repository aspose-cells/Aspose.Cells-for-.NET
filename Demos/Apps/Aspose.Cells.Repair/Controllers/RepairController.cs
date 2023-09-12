using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Repair.Controllers
{
    public class RepairController : UIControllerBase
    {
        public RepairController(IWebHostEnvironment env, ILogger<RepairController> logger) : base(env, logger)
        {
        }

        public IActionResult Repair()
        {
            var model = new ViewModel(this, "Repair")
            {
                ControlsView = "~/Pages/RepairControls.cshtml",
                ShowViewerButton = false
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Repair.cshtml", model);
        }
    }
}