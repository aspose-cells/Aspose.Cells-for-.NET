using Aspose.Cells.Live.Demos.UI.Models.Common;
using Aspose.Cells.Live.Demos.UI.Models;
using Aspose.Cells.Live.Demos.UI.Services;
using System;
using System.Collections;
using System.Web;
using System.Web.Mvc;

namespace Aspose.Cells.Live.Demos.UI.Controllers
{
	public class WatermarkController : BaseController  
	{
		public override string Product => (string)RouteData.Values["product"];


		[HttpPost]
		public Response Watermark(string watermarkText, string watermarkColor)
		{
			Response response = null;
			if (Request.Files.Count > 0)
			{
				string _sourceFolder = Guid.NewGuid().ToString();
				var docs =  UploadWorkBooks(Request, _sourceFolder);

				AsposeCellsWatermark asposeCellsWatermark = new AsposeCellsWatermark();
				response = asposeCellsWatermark.AddTextWatermark(docs, watermarkText, watermarkColor);
			}

			return response;				
		}
		public ActionResult Watermark()
		{
			
			var model = new ViewModel(this, "Watermark")
			{
				ControlsView = "WatermarkControls",
				MaximumUploadFiles = 10,
				DropOrUploadFileLabel = Resources["DropOrUploadFiles"]
				//,
				//ShowViewerButton = false
			};
			if (model.RedirectToMainApp)
				return Redirect("/cells/" + model.AppName.ToLower());
			return View(model);			
		}	

	}
}
