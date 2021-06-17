using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Annotation.Controllers
{
    public class AnnotationController : UIControllerBase
    {
        public AnnotationController(IWebHostEnvironment env, ILogger<AnnotationController> logger) : base(env, logger)
        {
        }

        public ActionResult Annotation()
        {
            var model = new ViewModel(this, "Annotation");
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Annotation.cshtml", model);
        }
    }
}