using System.IO;
using System.Web.Http;
using Aspose.Cells.API.Config;

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
            FontConfigs.SetFontFolder(AppSettings.FontFolderPath, true);

            // Set GridJs cache/font folder
            var imageCacheDir = AppSettings.ImageCache;
            var fileCacheDir = AppSettings.FileCache;
            if (!Directory.Exists(imageCacheDir))
                Directory.CreateDirectory(imageCacheDir);
            if (!Directory.Exists(fileCacheDir))
                Directory.CreateDirectory(fileCacheDir);
            GridJs.Config.PictureCacheDirectory = imageCacheDir;
            GridJs.Config.FileCacheDirectory = fileCacheDir;
            GridJs.Config.SetFontFolder(AppSettings.FontFolderPath, true);
            
            // Set GridJs license
            var license = new GridJs.License();
            license.SetLicense("Aspose.Total.lic");
        }
    }
}