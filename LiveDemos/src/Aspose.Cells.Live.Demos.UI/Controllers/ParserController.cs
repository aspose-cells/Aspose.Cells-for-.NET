using Aspose.Cells.Live.Demos.UI.Models.Common;
using Aspose.Cells.Live.Demos.UI.Models;
using Aspose.Cells.Live.Demos.UI.Services;
using System;
using System.Collections;
using System.Web;
using System.Web.Mvc;

namespace Aspose.Cells.Live.Demos.UI.Controllers
{
	public class ParserController : BaseController  
	{
		public override string Product => (string)RouteData.Values["product"];


		[HttpPost]
		public Response Parser(string outputType = "")
		{
			Response response = null;
			if (Request.Files.Count > 0)
			{
				string _sourceFolder = Guid.NewGuid().ToString();
				var docs = UploadWorkBooks(Request, _sourceFolder);

				AsposeCellsParser cellsParser = new AsposeCellsParser();
				response = cellsParser.Parse(docs);

			}

			return response;			
				
		}

		

		public ActionResult Parser()
		{
			var model = new ViewModel(this, "Parser")
			{
				
				MaximumUploadFiles = 10,
				
				DropOrUploadFileLabel = Resources["DropOrUploadFiles"]
			};
			return View(model);
		}
		

	}
}
