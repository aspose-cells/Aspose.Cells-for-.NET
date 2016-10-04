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
using Aspose.Cells.GridWeb.Data;

public partial class demos_Common_FreezePane : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //if first visit this page clear GridWeb1 
      if (!IsPostBack&&!GridWeb1.IsPostBack)
      {
        LoadData();

        //set sheets selectedIndex to 0
        GridWeb1.WorkSheets.ActiveSheetIndex = 0;
      }
    }

  private void LoadData()
  {
    // Gets the web application's path.
    string path = Server.MapPath("~");
    path = path.Substring(0, path.LastIndexOf("\\"));
    string fileName = path + "\\File\\FreezePane.xls";

    // Imports from a Grid file.
    GridWeb1.ImportExcelFile(fileName);

    GridWorksheet sheet = GridWeb1.WorkSheets[0];

    sheet.FreezePanes(3, 3, 3, 3);
  }

  // Handles the load file button click event and load an excel file from disk
  protected void Button1_Click(object sender, EventArgs e)
  {
    LoadData();
  }

  protected void GridWeb1_SaveCommand(object sender, System.EventArgs e)
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
