using System;
using System.Web;
using System.Web.UI;
using Aspose.Cells.UI.Models;

namespace Aspose.Cells.UI.Config
{
    public class BaseUserControl : UserControl
    {
        private AsposeToolsContext _atcContext;

        /// <summary>
        /// Main context object to access all the dcContent specific context info
        /// </summary>
        public AsposeToolsContext AsposeToolsContext
        {
            get
            {
                if (_atcContext == null) _atcContext = new AsposeToolsContext(HttpContext.Current);
                return _atcContext;
            }
        }

        private FlexibleResources _resources;

        /// <summary>
        /// key/value pair containing all the error messages defined in resources.xml file
        /// </summary>
        public FlexibleResources Resources
        {
            get
            {
                if (_resources == null) _resources = AsposeToolsContext.Resources;
                return _resources;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            AsposeToolsContext.atcc = AsposeToolsContext;
        }
    }
}