using Aspose.Cells.Live.Demos.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aspose.Cells.Live.Demos.UI.Controllers
{
	public class HomeController : BaseController
	{
	
		public override string Product => (string)RouteData.Values["productname"];
		

		

		public ActionResult Default()
		{
			ViewBag.PageTitle = "Free C# MVC Excel Document Processing APPs - aspose.app";
			ViewBag.MetaDescription = "Create Excel file manipulation applications using On Premise or Cloud APIs, or simply use cross-platform apps to view, compare, inspect or convert Excel files.";
			var model = new LandingPageModel(this);

			return View(model);
		}
	}
}
