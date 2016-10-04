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
using Aspose.Cells.GridWeb;
using System.ComponentModel;

public partial class demos_Common_ChangeStyle : System.Web.UI.Page
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
    path = path.Substring(0, path.LastIndexOf("\\")) ;
    string fileName = path + "\\File\\Skins.xls";

    // Imports from a excel file.
    GridWeb1.ImportExcelFile(fileName);
  }

  // Handles the preset style dropdown list changing event
  protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
  {
    // Changes the preset style using custom style.
    if (DropDownList1.SelectedItem.Value.StartsWith("CustomStyle"))
    {
      string fileName = DropDownList1.SelectedItem.Value + ".xml";
      GridWeb1.CustomStyleFileName = fileName;
      return;
    }

    // Changes the preset style using standard style that The Aspose.Cells.GridWeb providing.
    GridWeb1.PresetStyle =
      (Aspose.Cells.GridWeb.PresetStyle)TypeDescriptor.GetConverter
      (typeof(Aspose.Cells.GridWeb.PresetStyle)).ConvertFrom
      (DropDownList1.SelectedItem.Value);
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
