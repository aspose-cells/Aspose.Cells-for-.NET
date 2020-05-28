using Aspose.Cells.Live.Demos.UI.Config;
using Aspose.Cells.Live.Demos.UI.Models;
using Aspose.Cells.Live.Demos.UI.Models.Common;
using Aspose.Cells.Live.Demos.UI.Services;
using Aspose.Cells.Live.Demos.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Aspose.Cells;

namespace Aspose.Cells.Live.Demos.UI.Controllers
{
	public abstract class BaseController : Controller
	{

		protected CellsBase.DocumentInfo[] UploadWorkBooks(HttpRequestBase Request, string sourceFolder)
		{
			try
			{
				var pathProcessor = new PathProcessor(sourceFolder);
				List<CellsBase.DocumentInfo> documents = new List<CellsBase.DocumentInfo>();
				// foreach (string fileName in Request.Files)
				for (int i = 0; i < Request.Files.Count; i++)
				{
					HttpPostedFileBase postedFile = Request.Files[i];

					if (postedFile != null)
					{
						// Check if File is available.
						if (postedFile != null && postedFile.ContentLength > 0)
						{
							string _savepath = pathProcessor.SourceFolder + "\\" + System.IO.Path.GetFileName(postedFile.FileName);
							postedFile.SaveAs(_savepath);
							documents.Add(new CellsBase.DocumentInfo
							{
								FolderName = sourceFolder,
								FileName = postedFile.FileName,
								Workbook = new Workbook(_savepath)
							});
						}
					}
				}
				return documents.ToArray();
			}
			
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return new CellsBase.DocumentInfo[0];
			}
		}

		protected CellsBase.DocumentInfo[] UploadFiles(HttpRequestBase Request, string sourceFolder, string password)
		{
			try
			{
				var pathProcessor = new PathProcessor(sourceFolder);
				List<CellsBase.DocumentInfo> documents = new List<CellsBase.DocumentInfo>();
				// foreach (string fileName in Request.Files)
				for (int i = 0; i < Request.Files.Count; i++)
				{
					HttpPostedFileBase postedFile = Request.Files[i];

					if (postedFile != null)
					{
						// Check if File is available.
						if (postedFile != null && postedFile.ContentLength > 0)
						{
							string _savepath = pathProcessor.SourceFolder + "\\" + System.IO.Path.GetFileName(postedFile.FileName);
							postedFile.SaveAs(_savepath);
							documents.Add(new CellsBase.DocumentInfo
							{
								FolderName = sourceFolder,
								FileName = postedFile.FileName,
								Workbook = new Workbook(_savepath, new LoadOptions { Password = password })
							});
						}
					}
				}
				return documents.ToArray();
			}

			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return new CellsBase.DocumentInfo[0];
			}
		}
		/// <summary>
		/// Response when uploaded files exceed the limits
		/// </summary>
		protected Response BadDocumentResponse = new Response()
		{
			Status = "Some of your documents are corrupted",
			StatusCode = 500
		};


		public abstract string Product { get; }

		protected override void OnActionExecuted(ActionExecutedContext ctx)
		{
			base.OnActionExecuted(ctx);
			ViewBag.Title = ViewBag.Title ?? Resources["ApplicationTitle"];
			ViewBag.MetaDescription = ViewBag.MetaDescription ?? "Save time and software maintenance costs by running single instance of software, but serving multiple tenants/websites. Customization available for Joomla, Wordpress, Discourse, Confluence and other popular applications.";
		}

		private AsposeCellsContext _atcContext;


		/// <summary>
		/// Main context object to access all the dcContent specific context info
		/// </summary>
		public AsposeCellsContext AsposeToolsContext
		{
			get
			{
				if (_atcContext == null) _atcContext = new AsposeCellsContext(HttpContext.ApplicationInstance.Context);
				return _atcContext;
			}
		}

		private Dictionary<string, string> _resources;

		/// <summary>
		/// key/value pair containing all the error messages defined in resources.xml file
		/// </summary>
		public Dictionary<string, string> Resources
		{
			get
			{
				if (_resources == null) _resources = AsposeToolsContext.Resources;
				return _resources;
			}
		}

		protected bool IsValidEmail(string email)
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);
				return addr.Address == email;
			}
			catch
			{
				return false;
			}
		}


	}
}
