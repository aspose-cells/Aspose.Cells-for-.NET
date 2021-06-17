using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Comparison.Controllers
{
    public class ComparisonController : UIControllerBase
    {
        public ComparisonController(IWebHostEnvironment env, ILogger<ComparisonController> logger) : base(env, logger)
        {
        }

        public ActionResult Comparison()
        {
            var model = new ViewModel(this, "Comparison");
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Comparison.cshtml", model);
        }

        public ActionResult Compare()
        {
            return View("~/Pages/index.cshtml");
        }
    }
}