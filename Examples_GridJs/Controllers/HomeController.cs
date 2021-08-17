using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Cells.GridJsDemo.Models;
using Microsoft.AspNetCore.Mvc;
 

namespace Aspose.Cells.GridJsDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToRoute("default",
          new { controller = "GridJs2", action = "List" });
        }

        public IActionResult Privacy()
        {
            return Redirect("https://about.aspose.app/legal/privacy-policy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
