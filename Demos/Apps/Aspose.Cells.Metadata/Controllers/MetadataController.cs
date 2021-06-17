using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Metadata.Controllers
{
    public class MetadataController : UIControllerBase
    {
        public MetadataController(IWebHostEnvironment env, ILogger<MetadataController> logger) : base(env, logger)
        {
        }

        public ActionResult Metadata()
        {
            var model = new ViewModel(this, "Metadata")
            {
                UploadAndRedirect = true,
                ControlsView = "~/Pages/MetadataControls.cshtml"
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Metadata.cshtml", model);
        }
    }
}