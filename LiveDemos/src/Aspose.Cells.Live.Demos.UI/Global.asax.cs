using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Aspose.Cells.Live.Demos.UI.Config;


namespace Aspose.Cells.Live.Demos.UI
{
	public class Global : HttpApplication
	{
		
		protected void Application_Error(object sender, EventArgs e)
		{			
			
		}

		void Application_Start(object sender, EventArgs e)
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);			
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			RegisterCustomRoutes(RouteTable.Routes);
		}
		void Session_Start(object sender, EventArgs e)
		{
			//Check URL to set language resource file
			string _language = "EN";
			
			SetResourceFile(_language);
		}

		private void SetResourceFile(string strLanguage)
		{
			if (Session["AsposeCellsResources"] == null)
				Session["AsposeCellsResources"] = new GlobalAppHelper(HttpContext.Current, Application, Configuration.ResourceFileSessionName, strLanguage);
		}
		
			void RegisterCustomRoutes(RouteCollection routes)
		{
			routes.RouteExistingFiles = true;
			routes.Ignore("{resource}.axd/{*pathInfo}");
					

			routes.MapRoute(
				name: "Default",
				url: "Default",
				defaults: new { controller = "Home", action = "Default" }
			);
			
			routes.MapRoute(
				"AsposeCellsConversionRoute",
				"{product}/Conversion",
				 new { controller = "Conversion", action = "Conversion" }
			);
			routes.MapRoute(
				"AsposeCellsRemoveAnnotationRoute",
				"annotation/remove",
				 new { controller = "Annotation", action = "Remove" }
			);
			routes.MapRoute(
				"AsposeCellsUnlockRoute",
				"{product}/unlock",
				 new { controller = "Unlock", action = "Unlock" }
			);
			routes.MapRoute(
				"AsposeCellsSearchRoute",
				"{product}/search",
				 new { controller = "Search", action = "Search" }
			);
			routes.MapRoute(
				"AsposeCellsWatermarkRoute",
				"{product}/watermark",
				 new { controller = "Watermark", action = "Watermark" }
			);
			routes.MapRoute(
				"AsposeCellsParserRoute",
				"{product}/parser",
				 new { controller = "Parser", action = "Parser" }
			);
			routes.MapRoute(
				"AsposeCellsAnnotationRoute",
				"{product}/annotation",
				 new { controller = "Annotation", action = "Annotation" }
			);
			routes.MapRoute(
				"AsposeCellsMergerRoute",
				"{product}/merger",
				 new { controller = "Merger", action = "Merger" }
			);
			routes.MapRoute(
				"AsposeCellsProtectRoute",
				"{product}/protect",
				 new { controller = "Protect", action = "Protect" }
			);
			routes.MapRoute(
				"AsposeCellsViewerRoute",
				"{product}/viewer",
				 new { controller = "Viewer", action = "Viewer" }
			);
			routes.MapPageRoute(
			  "AsposeCellsDefaultViewerRoute",
			  "cells/view",
			  "~/ViewerApp/Default.aspx"
			);
			routes.MapPageRoute(
			  "AsposeCellsAssemblyRoute",
			  "{Product}/assembly",
			  "~/Assembly/AssemblyApp.aspx"
			);
			routes.MapRoute(
				"DownloadFileRoute",
				"common/download",
				new { controller = "Common", action = "DownloadFile" }				
				
			);
			routes.MapRoute(
				"UploadFileRoute",
				"common/uploadfile",
				new { controller = "Common", action = "UploadFile" }

			);
		}

		private void MapProductToolPageRoute(RouteCollection routes, string routeName, string routeUrl, string physicalFile, string productRegex)
		{
			routes.MapPageRoute(routeName, routeUrl, physicalFile, false, null, new RouteValueDictionary { { "Product", productRegex } });
		}
	}
}
