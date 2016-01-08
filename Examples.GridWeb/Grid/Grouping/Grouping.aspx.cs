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
using Aspose.Cells.GridWeb.DemosCS.DataBind;

public partial class demos_Grouping_Grouping : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  protected void btnLoad_Click(object sender, EventArgs e)
  {
    // Loads data from access database.
    DataSet ds = new DataSet();

    //Create demo database object
    DemoDatabase db = new DemoDatabase();
    string path = Server.MapPath("~");
    path = path.Substring(0, path.LastIndexOf("\\"));

    //Create connection string to database
    db.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\Database\\demos.mdb";
    try
    {
      // Connects to database and fetches data.
      db.oleDbDataAdapter1.Fill(ds);
      
     

      //Import data from database to grid web
      GridWeb1.WorkSheets.ImportDataView(ds.Tables["Products"].DefaultView, null, null);
    }
    finally
    {
      //Close connection
      db.oleDbConnection1.Close();
    }
  }

  protected void GridWeb1_CustomCommand(object sender, string command)
  {
    // Groups Rows or Ungroup Rows.
    if (GridWeb1.ActiveSheetIndex == 0)
    {
      switch (command)
      {
        case "GROUP":
          if (GridWeb1.SelectCells != null && GridWeb1.SelectCells.Count > 0)
          {
              //get Cell Selected CellArea
              WebCellArea SelectedCells = (WebCellArea)GridWeb1.SelectCells[0];

              //Group rows from starting cell to ending cell
              GridWeb1.WebWorksheets[0].GroupRows(SelectedCells.StartRow, SelectedCells.EndRow);
          }
          break;

        case "UNGROUP":
          if (GridWeb1.SelectCells != null && GridWeb1.SelectCells.Count > 0)
          {
              //get Cell Selected CellArea
              WebCellArea SelectedCells = (WebCellArea)GridWeb1.SelectCells[0];

              //Group rows from starting cell to ending cell
              GridWeb1.WebWorksheets[0].UngroupRows(SelectedCells.StartRow, SelectedCells.EndRow); ;
          }
          break;
      }
    }
  }

  protected void GridWeb1_SaveCommand(object sender, System.EventArgs e)
  {
    // Generates a memory stream.
    System.IO.MemoryStream ms = new System.IO.MemoryStream();

    // Saves to the stream.
    this.GridWeb1.SaveToExcelFile(ms);

    // Sents the file to browser.
    Response.ContentType = "application/vnd.ms-excel";

    //Adds header.
    Response.AddHeader("content-disposition", "attachment; filename=book1.xls");

    // Writes file content to the response stream.
    Response.OutputStream.Write(ms.GetBuffer(), 0, (int)ms.Length);

    // OK.
    Response.End();
  }

}
