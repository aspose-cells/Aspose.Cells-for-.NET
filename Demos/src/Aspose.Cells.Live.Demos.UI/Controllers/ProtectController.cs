using Aspose.Cells.Live.Demos.UI.Models.Common;
using Aspose.Cells.Live.Demos.UI.Models;
using Aspose.Cells.Live.Demos.UI.Services;
using System;
using System.Collections;
using System.Web;
using System.Web.Mvc;

namespace Aspose.Cells.Live.Demos.UI.Controllers
{
	public class ProtectController : BaseController  
	{
		public override string Product => (string)RouteData.Values["product"];


		[HttpPost]
		public Response Protect(string passw)
		{
			Response response = null;
			if (Request.Files.Count > 0)
			{
				string _sourceFolder = Guid.NewGuid().ToString();
				var docs =  UploadWorkBooks(Request, _sourceFolder);

				AsposeCellsProtect asposeCellsProtect = new AsposeCellsProtect();
				response = asposeCellsProtect.Protect(docs, passw);
			}

			return response;				
		}
		public ActionResult Protect()
		{
			var model = new ViewModel(this, "Protect")
			{
				ControlsView = "UnlockControls",				
				MaximumUploadFiles = 10,
				DropOrUploadFileLabel = Resources["DropOrUploadFiles"],
				ShowViewerButton = false
			};
			if (model.RedirectToMainApp)
				return Redirect("/cells/" + model.AppName.ToLower());
			return View(model);			
		}	

	}
}
