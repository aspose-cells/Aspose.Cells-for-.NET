using Aspose.Cells.Live.Demos.UI.Models.Common;
using Aspose.Cells.Live.Demos.UI.Models;
using Aspose.Cells.Live.Demos.UI.Services;
using System;
using System.Collections;
using System.Web;
using System.Web.Mvc;

namespace Aspose.Cells.Live.Demos.UI.Controllers
{
	public class UnlockController : BaseController  
	{
		public override string Product => (string)RouteData.Values["product"];


		[HttpPost]
		public Response Unlock( string passw)
		{
			Response response = null;
			if (Request.Files.Count > 0)
			{
				string _sourceFolder = Guid.NewGuid().ToString();
				var docs = UploadFiles (Request, _sourceFolder, passw);

				AsposeCellsUnlock asposeCellsUnlock = new AsposeCellsUnlock();
				response = asposeCellsUnlock.Unlock(docs, passw);

			}

			return response;				
		}
		public ActionResult Unlock()
		{
			var model = new ViewModel(this, "Unlock")
			{
				ControlsView = "UnlockControls",
				SaveAsComponent = true,
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
