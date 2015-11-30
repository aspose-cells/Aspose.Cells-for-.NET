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

public partial class demos_Common_Pagination : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //if first visit this page clear GridWeb1 
      if (!IsPostBack&&!GridWeb1.IsPostBack)
      {
        LoadData();
      }
    }

  private void LoadData()
  {
    // Gets the web application's path.
    string path = Server.MapPath("~");

    // Upper level.
    path = path.Substring(0, path.LastIndexOf("\\"));
    string fileName = path + "\\File\\EmployeeSales.xls";

    // Clears datasheets first.
    GridWeb1.WorkSheets.Clear();
    // Imports from a excel file.
    GridWeb1.ImportExcelFile(fileName);

    //Freeze sheet2
    GridWeb1.WorkSheets[1].FreezePanes(2, 0, 2, 0);

    //set sheets selectedIndex to 0
    GridWeb1.WorkSheets.ActiveSheetIndex = 0;
  }

  protected void Button1_Click(object sender, EventArgs e)
  {
    LoadData();
  }

  protected void GridWeb1_SaveCommand(object sender, EventArgs e)
  {
    // Generates a temporary file name.
    string filename = System.IO.Path.GetTempPath() + Session.SessionID + ".xls";

    // Saves to the file.
    this.GridWeb1.SaveToExcelFile(filename);

    // Sents the file to browser.
    Response.ContentType = "application/vnd.ms-excel";

    //Adds header.
    Response.AddHeader("content-disposition", "attachment; filename=book1.xls");

    // Writes file content to the response stream.
    Response.WriteFile(filename);

    // OK.
    Response.End();
  }
}
