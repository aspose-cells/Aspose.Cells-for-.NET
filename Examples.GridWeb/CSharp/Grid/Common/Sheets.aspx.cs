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
using System.Drawing;
using Aspose.Cells.GridWeb;

public partial class demos_Common_Sheets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack&&!GridWeb1.IsPostBack)
      {
        InitData();

        //set sheets selectedIndex to 0
        GridWeb1.WorkSheets.ActiveSheetIndex = 0;
      }
    }

  private void InitData()
  {
    GridWeb1.WorkSheets.Clear();
    GridWorksheet sheet = GridWeb1.WorkSheets.Add("Students");
    GridCells cells = sheet.Cells;
    cells[0, 0].PutValue("Name");
    GridTableItemStyle cellstyle = cells[0, 0].Style;
    cellstyle.Font.Size = new FontUnit("10pt");
    cellstyle.Font.Bold = true;
    cellstyle.ForeColor = Color.Black;
    cellstyle.HorizontalAlign = HorizontalAlign.Center;
    cellstyle.BorderWidth = 1;
    cells[0, 0].Style = cellstyle;

    cells[0, 1].PutValue("Gender");

    cells[0, 1].Style = cellstyle;

    cells[0, 2].PutValue("Age");
   
    cells[0, 2].Style = cellstyle;

    cells[0, 3].PutValue("Class");

    cells[0, 3].Style = cellstyle;

    cells[1, 0].PutValue("Jack");
    cells[1, 1].PutValue("M");
    cells[1, 2].PutValue(19);
    cells[1, 3].PutValue("One");

    cells[2, 0].PutValue("Tome");
    cells[2, 1].PutValue("M");
    cells[2, 2].PutValue(20);
    cells[2, 3].PutValue("Four");

    cells[3, 0].PutValue("Jeney");
    cells[3, 1].PutValue("W");
    cells[3, 2].PutValue(18);
    cells[3, 3].PutValue("Two");

    cells[4, 0].PutValue("Marry");
    cells[4, 1].PutValue("W");
    cells[4, 2].PutValue(17);
    cells[4, 3].PutValue("There");

    cells[5, 0].PutValue("Amy");
    cells[5, 1].PutValue("W");
    cells[5, 2].PutValue(16);
    cells[5, 3].PutValue("Four");

    cells[6, 0].PutValue("Ben");
    cells[6, 1].PutValue("M");
    cells[6, 2].PutValue(17);
    cells[6, 3].PutValue("Four");

    cells.SetColumnWidth(0, 10);
    cells.SetColumnWidth(1, 10);
    cells.SetColumnWidth(2, 10);
    cells.SetColumnWidth(3, 10);
  }

  protected void Button1_Click(object sender, EventArgs e)
  {
    InitData();
  }

  protected void Button2_Click(object sender, EventArgs e)
  {
      int i=GridWeb1.WorkSheets.Add();
      GridWeb1.WorkSheets.ActiveSheetIndex = i;
  }

  protected void Button3_Click(object sender, EventArgs e)
  {
      int i = GridWeb1.WorkSheets.AddCopy(0);
      GridWeb1.WorkSheets.ActiveSheetIndex = i;
  }

  protected void Button4_Click(object sender, EventArgs e)
  {
      if (GridWeb1.WorkSheets.ActiveSheetIndex != GridWeb1.WorkSheets.Count-1)
    {
        GridWeb1.WorkSheets.RemoveAt(GridWeb1.WorkSheets.ActiveSheetIndex);
    }
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
    Response.AddHeader("content-disposition", "attachment; filename=Sheets.xls");

    // Writes file content to the response stream.
    Response.WriteFile(filename);

    // OK.
    Response.End();
  }


}
