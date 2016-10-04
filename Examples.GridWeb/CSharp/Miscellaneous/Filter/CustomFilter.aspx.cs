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

public partial class demos_Filter_CustomFilter : System.Web.UI.Page
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
        GridWeb1.WorkSheets.Clear();
        // Imports from a excel file.
         GridWeb1.ImportExcelFile(fileName);

        // Sets the filter.
        //GridWeb1.WebWorksheets[0].RowFilter.StartColumn = 0;
        //GridWeb1.WebWorksheets[0].RowFilter.EndColumn = 5;
      }
    }

    protected void Button1_Click(object sender, System.EventArgs e)
    {
      
      string Criteria = "CELL0=" + TextBox1.Text ;

      Label2.Text = "The formula is: " + Criteria;
      GridWeb1.WorkSheets[0].AddCustomFilter(0, Criteria);
      GridWeb1.WorkSheets[0].RefreshFilter();
    }

    protected void Button2_Click(object sender, System.EventArgs e)
    {
        GridWeb1.WorkSheets[0].ResetFilter(0);
        GridWeb1.WorkSheets[0].RefreshFilter();
     
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        GridWeb1.WorkSheets[0].RemoveAutoFilter();
        GridWeb1.WorkSheets[0].RefreshFilter();
    }
}
