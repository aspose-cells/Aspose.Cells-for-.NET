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

public partial class demos_Common_HeaderBarAndCommandButton : System.Web.UI.Page
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

    // Upper level.
    path = path.Substring(0, path.LastIndexOf("\\"));
    string fileName = path + "\\File\\ShowHeaderBar.xls";

    // Imports from a excel file.
    GridWeb1.ImportExcelFile(fileName);

    GridWorksheet sheet = GridWeb1.WorkSheets[0];
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

  protected void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
  {
    GridWeb1.ShowHeaderBar = CheckBox1.Checked;
  }

  protected void Checkbox2_CheckedChanged(object sender, System.EventArgs e)
  {
    GridWeb1.ShowSubmitButton = CheckBox2.Checked;
  }

  protected void Checkbox3_CheckedChanged(object sender, System.EventArgs e)
  {
    GridWeb1.ShowSaveButton = CheckBox3.Checked;
  }

  protected void Checkbox4_CheckedChanged(object sender, System.EventArgs e)
  {
    GridWeb1.ShowUndoButton = CheckBox4.Checked;
  }

  protected void chkNoScrollBar_CheckedChanged(object sender, System.EventArgs e)
  {
    GridWeb1.NoScroll = chkNoScrollBar.Checked;
  }

  protected void chkNoTabBar_CheckedChanged(object sender, EventArgs e)
  {
       GridWeb1.ShowTabNavigation = !CheckBox5.Checked;
  }

}
