using System.Web.Http;

namespace Aspose.Cells.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{action}/{id}",
                new {id = RouteParameter.Optional}
            );

            config.EnableCors();

            // Set aspose cells font folder
            FontConfigs.SetFontFolder(Config.AppSettings.FontFolderPath, true);
        }
    }
}