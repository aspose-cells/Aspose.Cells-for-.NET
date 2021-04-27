using System;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Tools.Foundation.Models;

namespace Aspose.Cells.API
{
    ///<Summary>
    /// WebApiApplication class to set application level events
    ///</Summary>
    public class WebApiApplication : HttpApplication
    {
        ///<Summary>
        /// Application_Start event
        ///</Summary>
        protected void Application_Start()
        {
            //License awLic = new License();
            //awLic.SetLicense("Aspose.Total.lic");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void Application_Error(object sender, EventArgs e)
        {
            var ex = ((HttpApplication) sender).Context.Error;
            NLogger.LogError(ex.Message + "\n" + ex.StackTrace);
        }
    }
}