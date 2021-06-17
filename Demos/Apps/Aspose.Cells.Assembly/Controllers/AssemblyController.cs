using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Assembly.Controllers
{
    public class AssemblyController : UIControllerBase
    {
        public AssemblyController(IWebHostEnvironment env, ILogger<AssemblyController> logger) : base(env, logger)
        {
        }

        public ActionResult Assembly()
        {
            var model = new ViewModel(this, "Assembly")
            {
                ShowViewerButton = false
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Assembly.cshtml", model);
        }
    }
}