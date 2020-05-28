using Aspose.Cells.Live.Demos.UI.Models.Common;
using Aspose.Cells.Live.Demos.UI.Models;
using Aspose.Cells.Live.Demos.UI.Services;
using System;
using System.Collections;
using System.Web;
using System.Web.Mvc;

namespace Aspose.Cells.Live.Demos.UI.Controllers
{
	public class SearchController : BaseController
	{
		public override string Product => (string)RouteData.Values["product"];


		[HttpPost]
		public Response Search( string query)
		{
			Response response = null;
			if (Request.Files.Count > 0)
			{
				string _sourceFolder = Guid.NewGuid().ToString();
				var docs = UploadWorkBooks(Request, _sourceFolder);


				AsposeCellsSearch asposeCellsSearch = new AsposeCellsSearch();
				response = asposeCellsSearch.Search(docs,  query);

			}

			return response;
		}
		public ActionResult Search()
		{
			var model = new ViewModel(this, "Search")
			{
				ControlsView = "SearchControls",
				
				MaximumUploadFiles = 10,
				DropOrUploadFileLabel = Resources["DropOrUploadFiles"]
			};
			if (model.RedirectToMainApp)
				return Redirect("/cells/" + model.AppName.ToLower());
			return View(model);
		}

	}
}
