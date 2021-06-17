using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Viewer.Controllers
{
    public class ViewerController : UIControllerBase
    {
        public ViewerController(IWebHostEnvironment env, ILogger<ViewerController> logger) : base(env, logger)
        {
        }

        public ActionResult Viewer()
        {
            var model = new ViewModel(this, "Viewer")
            {
                UploadAndRedirect = true
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Viewer.cshtml", model);
        }

        public ActionResult View()
        {
            return View("~/Pages/index.cshtml");
        }
    }
}