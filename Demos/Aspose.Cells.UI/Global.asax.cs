using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Aspose.Cells.UI.Config;
using Tools.Foundation.Models;

namespace Aspose.Cells.UI
{
    public class Global : HttpApplication
    {
        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = ((HttpApplication) sender).Context.Error;
            NLogger.LogError(
                ex,
                $"ControllerName = {nameof(Global)}, MethodName = {nameof(Application_Error)}",
                "",
                ProductFamilyNameKeysEnum.unassigned,
                ""
            );
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            // TODO: LocalizationModule.OnAcquireRequestState(sender, e);
        }

        private void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterCustomRoutes(RouteTable.Routes);

            // Set aspose cells gridweb font folder
            GridWeb.GridWeb.SetFontFolder(Configuration.GridWebFontFolderPath, true);
        }

        private void Session_Start(object sender, EventArgs e)
        {
            //Check URL to set language resource file
            var language = "EN";

            if (Request.Url.Host.StartsWith("zh."))
            {
                language = "ZH";
            }

            var sessionId = Configuration.ResourceFileSessionName + Request.Url.Host.Trim().Replace(".", "");

            SetResourceFile(language, sessionId);
        }

        private void SetResourceFile(string strLanguage, string sessionId)
        {
            if (Session["AsposeAppResources"] == null)
                Session["AsposeAppResources"] = new GlobalAppHelper(HttpContext.Current, sessionId, strLanguage);
        }

        private static void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.RouteExistingFiles = true;

            routes.Ignore("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                "SEOSitemapRoute",
                "sitemaps/{product}.xml",
                new {controller = "SEO", action = "Sitemap"}
            );

            routes.MapRoute(
                "SEOFillResourcesRoute",
                "SEO/FillResources",
                new {controller = "SEO", action = "FillResources"}
            );
            routes.MapRoute(
                "SEOResetResourcesCacheRoute",
                "SEO/ResetResourcesCache",
                new {controller = "SEO", action = "ResetResourcesCache"}
            );

            routes.MapRoute(
                "CommonResourcesRoute",
                "common/resources",
                new {controller = "Common", action = "GetResources"}
            );

            routes.MapRoute(
                "CommonTestFail",
                "common/TestFail",
                new {controller = "Common", action = "TestFail"}
            );

            routes.MapRoute(
                "CommonSendUrlToEmailRoute",
                "common/SendUrlToEmail/{product}/{method}",
                new {controller = "Common", action = "SendUrlToEmail"}
            );
            routes.MapRoute(
                "CellsConversionRoute",
                "cells/conversion/{fileformat}",
                new {controller = "Cells", action = "Conversion", fileformat = ""}
            );
            routes.MapRoute(
                "CellsSendEmailRoute",
                "cells/sendemail",
                new {controller = "Cells", action = "SendEmail"}
            );
            routes.MapRoute(
                "CellsSendFeedbackRoute",
                "cells/sendfeedback",
                new {controller = "Cells", action = "SendFeedback"}
            );
            routes.MapRoute(
                "CellsParserRoute",
                "cells/parser/{fileformat}",
                new {controller = "Cells", action = "Parser", fileformat = ""}
            );
            routes.MapRoute(
                "CellsMetadataRoute",
                "cells/metadata/{fileformat}",
                new {controller = "Cells", action = "Metadata", fileformat = ""}
            );
            routes.MapRoute(
                "CellsViewerRoute",
                "cells/viewer/{fileformat}",
                new {controller = "Cells", action = "Viewer", fileformat = ""}
            );
            routes.MapPageRoute(
                "AsposeToolsViewerCells",
                "cells/view",
                "~/cells/Viewer/index.html"
            );
            routes.MapRoute(
                "CellsWatermarkRoute",
                "cells/watermark/{fileformat}",
                new {controller = "Cells", action = "Watermark", fileformat = ""}
            );
            routes.MapRoute(
                "CellsMergerRoute",
                "cells/merger/{fileformat}",
                new {controller = "Cells", action = "Merger", fileformat = ""}
            );
            routes.MapRoute(
                "CellsSearchRoute",
                "cells/search/{fileformat}",
                new {controller = "Cells", action = "Search", fileformat = ""}
            );
            routes.MapRoute(
                "CellsAssemblyRoute",
                "cells/assembly/{fileformat}",
                new {controller = "Cells", action = "Assembly", fileformat = ""}
            );
            routes.MapRoute(
                "CellsAnnotationRoute",
                "cells/annotation/{fileformat}",
                new {controller = "Cells", action = "Annotation", fileformat = ""}
            );
            routes.MapRoute(
                "CellsUnlockRoute",
                "cells/unlock/{fileformat}",
                new {controller = "Cells", action = "Unlock", fileformat = ""}
            );
            routes.MapRoute(
                "CellsProtectRoute",
                "cells/protect/{fileformat}",
                new {controller = "Cells", action = "Protect", fileformat = ""}
            );
            routes.MapRoute(
                "CellsChartRoute",
                "cells/chart/{fileformat}",
                new {controller = "Cells", action = "Chart", fileformat = ""}
            );
            routes.MapRoute(
                "CellsEditorRoute",
                "cells/editor/{fileformat}",
                new {controller = "Cells", action = "Editor", fileformat = ""}
            );
            routes.MapPageRoute(
                "AsposeToolsEditorCells",
                "cells/edit",
                "~/cells/Editor/index.html"
            );
            routes.MapRoute(
                "CellsSplitterRoute",
                "cells/splitter/{fileformat}",
                new {controller = "Cells", action = "Splitter", fileformat = ""}
            );

            RegisterEmailDefaultRoutes(routes);

            MapProductToolPageRoute(routes,
                "AsposeToolsTaskDownloaderRoute",
                "{Product}/downloader",
                "~/DownloaderApp/DownloaderTasksApp.aspx",
                "^tasks$"
            );

            routes.MapRoute(
                "BaseSendFeedbackRoute",
                "common/sendfeedback",
                new {controller = "Common", action = "SendFeedback"}
            );

            routes.MapPageRoute(
                "AsposeToolsProductsRoute",
                "{PageName}",
                "~/Default.aspx"
            );
        }

        private static void RegisterEmailDefaultRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                "AsposeAppEmailApps",
                "email/{action}/{extension}",
                new {controller = "Email", extension = UrlParameter.Optional}
            );
        }

        private static void MapProductToolPageRoute(RouteCollection routes, string routeName, string routeUrl, string physicalFile, string productRegex)
        {
            routes.MapPageRoute(
                routeName,
                routeUrl,
                physicalFile,
                false,
                null,
                new RouteValueDictionary
                {
                    {"Product", productRegex}
                }
            );
        }
    }
}