using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Splitter.Controllers
{
    public class SplitterController : UIControllerBase
    {
        public SplitterController(IWebHostEnvironment env, ILogger<SplitterController> logger) : base(env, logger)
        {
        }

        public ActionResult Splitter()
        {
            var model = new ViewModel(this, "Splitter")
            {
                SaveAsComponent = true,
                ShowViewerButton = false
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Splitter.cshtml", model);
        }
    }
}