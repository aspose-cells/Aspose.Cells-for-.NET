using System.Collections.Generic;
using System.Linq;
using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Mortgage.Controllers
{
    public class MortgageController : UIControllerBase
    {
        public MortgageController(IWebHostEnvironment env, ILogger<MortgageController> logger) : base(env, logger)
        {
        }

        public ActionResult Mortgage()
        {
            var model = new ViewModel(this, "Mortgage-Calculator")
            {
                SaveAsComponent = true,
                SaveAsOriginal = false,
                ControlsView = "~/Pages/MortgageInput.cshtml",
                ControlsView2 = "~/Pages/MortgageOutput.cshtml",
            };
            return View("~/Pages/Mortgage.cshtml", model);
        }

    }
}