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
using System.Data.OleDb;
using Aspose.Cells.GridWeb.Data;
using System.Drawing;
using Aspose.Cells.GridWeb;

public partial class demos_Common_importdataview : System.Web.UI.Page
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
      }
    }

    // Handles the "import" button click event and load data from a dataview object.
  protected void Button1_Click(object sender, EventArgs e)
  {

    //connect database
    System.Data.OleDb.OleDbConnection oleDbConnection1;
    System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
    System.Data.OleDb.OleDbCommand oleDbSelectCommand1;

    oleDbConnection1 = new OleDbConnection();
    oleDbDataAdapter1 = new OleDbDataAdapter();
    oleDbSelectCommand1 = new OleDbCommand();

    string path = Server.MapPath("~");
    path = path.Substring(0, path.LastIndexOf("\\")) ;	 
    oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\Database\\Northwind.mdb";

    oleDbSelectCommand1.Connection = oleDbConnection1;
    oleDbDataAdapter1.SelectCommand = oleDbSelectCommand1;

    DataTable dataTable1 = new DataTable();
    dataTable1.Reset();

    // Queries database.
    try
    {
      oleDbSelectCommand1.CommandText = "SELECT CategoryID, CategoryName, Description FROM Categories";
      oleDbDataAdapter1.Fill(dataTable1);
    }
    catch
    {
    }
    finally
    {
      oleDbConnection1.Close();
    }

    dataTable1.TableName = "Categories";
    GridWeb1.WorkSheets.Clear();
    // Imports data from dataview object.
    GridWeb1.WorkSheets.ImportDataView(dataTable1.DefaultView, null, null);

    // Imports data from dataview object with sheet name and position specified.
    GridWeb1.WorkSheets.ImportDataView(dataTable1.DefaultView, null, null, "SpecifiedName&Position", 2, 1);

    GridCells cells = GridWeb1.WorkSheets[0].Cells;
    // Sets column width.
    cells.SetColumnWidth(0, 10);
    cells.SetColumnWidth(1,10);
    cells.SetColumnWidth(2, 30);
    cells.SetRowHeight(2, 30);
    GridCells cellsb = GridWeb1.WorkSheets[1].Cells;
    cellsb.SetColumnWidth(1, 10);
    cellsb.SetColumnWidth(2,10);
    cellsb.SetColumnWidth(3, 30);
    cellsb.SetRowHeight(4, 30);

    GridTableItemStyle style = new GridTableItemStyle();
    style.HorizontalAlign = HorizontalAlign.Center;
    style.BorderStyle = BorderStyle.Solid;
    style.BorderColor = Color.Black;
    style.BorderWidth = 1;

    for (int i = 1; i <= cells.MaxRow; i++)
    {
        for (int j = 0; j <= cells.MaxColumn; j++)
      {
        GridCell cell = cells[i, j];
        cell.CopyStyle(style);
        
      }
    }
    for (int i = 3; i <= cellsb.MaxRow; i++)
    {
      for (int j = 1; j <= cellsb.MaxColumn; j++)
      {
        GridCell cell = cellsb[i, j];
        cell.CopyStyle(style);
        
      }
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
			Response.AddHeader( "content-disposition","attachment; filename=book1.xls");

			// Writes file content to the response stream.
			Response.WriteFile(filename);

			// OK.
			Response.End();
		}

}
