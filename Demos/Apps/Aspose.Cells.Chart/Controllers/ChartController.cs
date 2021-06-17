using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Chart.Controllers
{
    public class ChartController : UIControllerBase
    {
        public ChartController(IWebHostEnvironment env, ILogger<ChartController> logger) : base(env, logger)
        {
        }

        public ActionResult Chart()
        {
            var model = new ViewModel(this, "Chart")
            {
                SaveAsComponent = true,
                ShowViewerButton = false,
                SaveAsOriginal = false,
                ControlsView = "~/Pages/ChartControls.cshtml"
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Chart.cshtml", model);
        }
    }
}