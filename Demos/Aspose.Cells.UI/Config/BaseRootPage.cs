using Aspose.Cells.UI.Models;
using System;
using System.Web;
using System.Web.UI;

namespace Aspose.Cells.UI.Config
{
    /// <summary>
    /// The base page for all the other base page types, initializes access to the provider libraries and context
    /// </summary>
    public class BaseRootPage : Page
    {
        private AsposeToolsContext _atcContext;

        private static string _url;

        public static string URL
        {
            get => _url;
            set => _url = "~/Default.aspx";
        }

        /// <summary>
        /// Main context object to access all the dcContent specific context info
        /// </summary>
        public AsposeToolsContext AsposeToolsContext => _atcContext ?? (_atcContext = new AsposeToolsContext(HttpContext.Current));

        private FlexibleResources _resources;

        /// <summary>
        /// key/value pair containing all the error messages defined in resources.xml file
        /// </summary>
        public FlexibleResources Resources => _resources ?? (_resources = AsposeToolsContext.Resources);

        protected override void OnInit(EventArgs e)
        {
            // Initialize our base class (System.Web,UI.Page) 
            base.OnInit(e);
            // Check to see if the Session is null (doesnt exist) 
            if (AsposeToolsContext.Session == null) return;
            // Check the IsNewSession value, this will tell us if the session has been reset. 
            // IsNewSession will also let us know if the users session has timed out 
            if (!Session.IsNewSession) return;
            // Now we know it's a new session, so we check to see if a cookie is present 
            var cookie = Request.Headers["Cookie"];
            // Now we determine if there is a cookie does it contains what we're looking for 
            if (null != cookie && cookie.IndexOf("ASP.NET_SessionId", StringComparison.Ordinal) >= 0)
            {
                //since it's a new session but a ASP.Net cookie exist we know 
                //the session has expired so we need to redirect them 
                //if ((Request.RawUrl.ToString().IndexOf("Index.aspx") < 0) && (Request.RawUrl.ToString().IndexOf("User.aspx") < 0))
                //{
                //   Response.Redirect("~/Default.aspx");
                //}
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            // Sync the central context store with the first loaded context for this page
            AsposeToolsContext.atcc = AsposeToolsContext;
            base.OnLoad(e);
        }
    }
}