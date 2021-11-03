using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.Routing;
using System.Web.SessionState;

namespace Aspose.Cells.GridWeb.Examples.CSharp 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
            
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
#if SITE_BUILD
            // NOTE that in production you would want to call 
            // new License().SetLicense("path-to-license-file")
            try
			{
				//Aspose.Cells.License lic = new Aspose.Cells.License();
                //Aspose.Demos.Common.WebOperationsBridge.InitLicense(lic);

                //Aspose.Cells.GridWeb.License lic2 = new Aspose.Cells.GridWeb.License();
                //Aspose.Demos.Common.WebOperationsBridge.InitLicense(lic2);
			}
			catch
			{
			}
#endif
        }

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
		}
		#endregion
	}
}

