using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Editor.Controllers
{
    public class EditorController : UIControllerBase
    {
        public EditorController(IWebHostEnvironment env, ILogger<EditorController> logger) : base(env, logger)
        {
        }

        public ActionResult Editor()
        {
            var model = new ViewModel(this, "Editor");
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Editor.cshtml", model);
        }

        public ActionResult Edit()
        {
            return View("~/Pages/index.cshtml");
        }
    }
}