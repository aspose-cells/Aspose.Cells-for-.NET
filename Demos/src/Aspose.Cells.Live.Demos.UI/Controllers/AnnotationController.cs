using Aspose.Cells.Live.Demos.UI.Models.Common;
using Aspose.Cells.Live.Demos.UI.Models;
using Aspose.Cells.Live.Demos.UI.Services;
using System;
using System.Collections;
using System.Web;
using System.Web.Mvc;

namespace Aspose.Cells.Live.Demos.UI.Controllers
{
	public class AnnotationController : BaseController  
	{
		public override string Product => (string)RouteData.Values["product"];


		[HttpPost]
		public Response Remove()
		{
			Response response = null;
			if (Request.Files.Count > 0)
			{
				string _sourceFolder = Guid.NewGuid().ToString();
				var docs = UploadWorkBooks(Request, _sourceFolder);

				AsposeCellsAnnotation cellsAnnotation = new AsposeCellsAnnotation();
				response = cellsAnnotation.Remove(docs);

			}

			return response;			
				
		}

		

		public ActionResult Annotation()
		{
			var model = new ViewModel(this, "Annotation")
			{
				
				MaximumUploadFiles = 10,
				
				DropOrUploadFileLabel = Resources["DropOrUploadFiles"]
			};
			return View(model);
		}
		

	}
}
