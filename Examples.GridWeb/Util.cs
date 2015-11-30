using System;

namespace Aspose.Cells.GridWeb.DemosCS
{
	/// <summary>
	/// some common Methods for demos
	/// </summary>
	public class Util
	{
		public static void ShowMessage(System.Web.UI.Page page, String msg)
		{
			string script;
			script = "<script language='javascript'>alert('"
				   + msg
				   + "')</script>";
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "Util.alertMessage", script);
			//page.RegisterClientScriptBlock("Util.alertMessage", script);      
		}
	}
}
