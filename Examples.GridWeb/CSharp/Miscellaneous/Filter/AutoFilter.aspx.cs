using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class demos_Filter_AutoFilter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      // Put user code to initialize the page here
      if (!IsPostBack&&!GridWeb1.IsPostBack)
      {
        // Gets the web application's path.
        string path = Server.MapPath("~");

        // Upper level.
        path = path.Substring(0, path.LastIndexOf("\\"));
        string fileName = path + "\\File\\List.xls";

        // Clears datasheets first.
       
        // Imports from a excel file.
        GridWeb1.ImportExcelFile(fileName);
 
        // Enable the auto filter.

        GridWeb1.WorkSheets[0].AddAutoFilter(4, 0, 5);
        
      }
    }
}
