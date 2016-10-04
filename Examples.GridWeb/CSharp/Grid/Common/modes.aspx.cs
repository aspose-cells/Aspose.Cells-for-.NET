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

public partial class demos_Common_modes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //if first visit this page clear GridWeb1 
      if (!IsPostBack&&!GridWeb1.IsPostBack)
      {
          GridWeb1.WorkSheets.Clear();
          GridWeb1.WorkSheets.Add();

        //set sheets selectedIndex to 0
        GridWeb1.WorkSheets.ActiveSheetIndex = 0;

        GridWeb1.ForceValidation = false;
      }
    }

  protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
  {
    GridWeb1.EditMode = CheckBox1.Checked;
    Panel2.Visible = GridWeb1.EditMode;
    Panel3.Visible = GridWeb1.EditMode;
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

  protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
  {   int row=int.Parse(this.TextBox1.Text);
      GridWeb1.WorkSheets[0].SetRowReadonly(row, CheckBox2.Checked);
      
  }

  protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
  {
      int col = int.Parse(this.TextBox2.Text);
      GridWeb1.WorkSheets[0].SetColumnReadonly(col, CheckBox3.Checked);
  }
}
