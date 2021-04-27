using Aspose.Cells.UI.Config;
using Aspose.Cells.UI.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Aspose.Cells.UI.Controllers
{
    public abstract class BaseController : Controller
    {
        public virtual IEnumerable<AnotherApp> Applications { get; } = null;

        public abstract string Product { get; }

        protected override void OnActionExecuted(ActionExecutedContext ctx)
        {
            base.OnActionExecuted(ctx);
            ViewBag.APIBasePath = Configuration.AsposeToolsAPIBasePath;
            ViewBag.Title = ViewBag.Title ?? Resources["ApplicationTitle"];
            ViewBag.MetaDescription = ViewBag.MetaDescription ?? "Save time and software maintenance costs by running single instance of software, but serving multiple tenants/websites. Customization available for Joomla, Wordpress, Discourse, Confluence and other popular applications.";
        }

        private AsposeToolsContext _atcContext;

        private FlexibleResources _resources;

        /// <summary>
        /// Main context object to access all the dcContent specific context info
        /// </summary>
        public AsposeToolsContext AsposeToolsContext => _atcContext ?? (_atcContext = new AsposeToolsContext(HttpContext.ApplicationInstance.Context));

        /// <summary>
        /// key/value pair containing all the error messages defined in resources.xml file
        /// </summary>
        public virtual FlexibleResources Resources => _resources ?? (_resources = AsposeToolsContext.Resources);

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