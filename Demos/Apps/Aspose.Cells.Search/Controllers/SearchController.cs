using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Search.Controllers
{
    public class SearchController : UIControllerBase
    {
        public SearchController(IWebHostEnvironment env, ILogger<SearchController> logger) : base(env, logger)
        {
        }

        public ActionResult Search()
        {
            var model = new ViewModel(this, "Search")
            {
                ControlsView = "~/Pages/SearchControls.cshtml",
                ShowViewerButton = false
            };
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Search.cshtml", model);
        }
    }
}