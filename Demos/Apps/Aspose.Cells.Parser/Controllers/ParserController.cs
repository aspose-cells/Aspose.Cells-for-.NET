using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Parser.Controllers
{
    public class ParserController : UIControllerBase
    {
        public ParserController(IWebHostEnvironment env, ILogger<ParserController> logger) : base(env, logger)
        {
        }

        public ActionResult Parser()
        {
            var model = new ViewModel(this, "Parser");
            if (model.RedirectToMainApp)
                return Redirect("/cells/" + model.AppName.ToLower());
            return View("~/Pages/Parser.cshtml", model);
        }
    }
}