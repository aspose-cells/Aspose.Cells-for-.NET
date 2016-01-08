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
using Aspose.Cells.GridWeb.DemosCS;

public partial class demos_Common_FreezePaneCustom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //if first visit this page clear GridWeb1 
      if (!IsPostBack&&!GridWeb1.IsPostBack)
      {
           
          GridWeb1.WorkSheets.Add();

        //set sheets selectedIndex to 0
          GridWeb1.WorkSheets.ActiveSheetIndex = 0;
      }
    }
  protected void Button1_Click(object sender, EventArgs e)
  {    
    int row = Convert.ToInt16(TextBox1.Text.Trim());
    int column = Convert.ToInt16(TextBox2.Text.Trim());
    int rowNumber = Convert.ToInt16(TextBox3.Text.Trim());
    int columnNumber = Convert.ToInt16(TextBox4.Text.Trim());

    GridWorksheet sheet = GridWeb1.WorkSheets[0];
    sheet.FreezePanes(row, column, rowNumber, columnNumber);
  }

  protected void Button2_Click(object sender, EventArgs e)
  {
      GridWeb1.WorkSheets[0].UnFreezePanes();
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
