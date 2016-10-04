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

public partial class demos_Format_CustomFormat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack&&!GridWeb1.IsPostBack)
      {
        initData();

        //set sheets selectedIndex to 0
        GridWeb1.ActiveSheetIndex = 0;
      }
    }
  private void initData()
  { 
    GridWeb1.WorkSheets.Clear();
    GridWeb1.WorkSheets.Add("Custom Format");

    GridCell cell;
    GridCells cells = GridWeb1.WorkSheets[0].Cells;
    cells["A1"].PutValue("Custom Format");
    cells["A2"].PutValue("0.0");
    cells["A3"].PutValue("0.000");
    cells["A4"].PutValue("#,##0.0");
    cells["A5"].PutValue("US$#,##0;US$-#,##0");
    cells["A6"].PutValue("0.0%");
    cells["A7"].PutValue("0.000E+00");
    cells["A8"].PutValue("yyyy-m-d h:mm");

    cell = cells["B1"];
    cell.PutValue("Format Results");

    cell = cells["B2"];
    cell.PutValue(12345.6789);
    cell.SetCustom("0.0");
     

    cell = cells["B3"];
    cell.PutValue(12345.6789);
    cell.SetCustom("0.000");
     

    cell = cells["B4"];
    cell.PutValue(543123456.789);
    cell.SetCustom("#,##0.0");
    

    cell = cells["B5"];
    cell.PutValue(-543123456.789);
    cell.SetCustom("US$#,##0;US$-#,##0");
    

    cell = cells["B6"];
    cell.PutValue(0.925687);
    cell.SetCustom( "0.0%");
    

    cell = cells["B7"];
    cell.PutValue(-1234567890.5687);
    cell.SetCustom( "0.000E+00");
    

    cell = cells["B8"];
    cell.PutValue(DateTime.Now);
    cell.SetCustom( "yyyy-m-d h:mm");
   

    cells.SetColumnWidthPixel(0, 220);
    cells.SetColumnWidthPixel(1, 220);
  }

  protected void Button1_Click(object sender, EventArgs e)
  {
    initData();
  }

  protected void Button2_Click(object sender, EventArgs e)
  {
      GridWeb1.WorkSheets.Clear();
      GridWeb1.WorkSheets.Add();

    GridCells cells = GridWeb1.WorkSheets[0].Cells;

    cells["A1"].PutValue("Custom Format");
    cells["B1"].PutValue("Format Results");

    cells["A2"].PutValue(TextBox1.Text.Trim());
    cells["B2"].PutValue(TextBox2.Text.Trim(), true);

    
    cells["B2"].SetCustom(TextBox1.Text.Trim());

    cells.SetColumnWidthPixel(0, 120);
    cells.SetColumnWidthPixel(1, 220);
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
    Response.AddHeader("content-disposition", "attachment; filename=CustomFormat.xls");

    // Writes file content to the response stream.
    Response.WriteFile(filename);

    // OK.
    Response.End();
  }
}
