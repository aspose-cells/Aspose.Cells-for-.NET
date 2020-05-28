using Aspose.Cells.Live.Demos.UI.Models.Common;
using Aspose.Cells.Live.Demos.UI.Models;
using Aspose.Cells.Live.Demos.UI.Services;
using System;
using System.Collections;
using System.Web;
using System.Web.Mvc;

namespace Aspose.Cells.Live.Demos.UI.Controllers
{
	public class MetadataController : BaseController
	{
		public override string Product => (string)RouteData.Values["product"];

		public ActionResult Metadata()
		{
			var model = new ViewModel(this, "Metadata")
			{
				ControlsView = "MetadataControls",
				UploadAndRedirect = true,
				MaximumUploadFiles = 10,
				DropOrUploadFileLabel = Resources["DropOrUploadFiles"]
			};
			if (model.RedirectToMainApp)
				return Redirect("/cells/" + model.AppName.ToLower());
			return View(model);
		}

	}
}
