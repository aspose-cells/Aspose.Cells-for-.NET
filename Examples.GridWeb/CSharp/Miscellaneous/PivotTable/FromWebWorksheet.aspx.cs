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

public partial class demos_PivotTable_FromWebWorksheet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && !GridWeb1.IsPostBack)
      {
        InitData();
      }
    }

  private void InitData()
  {
    //Create path to xls file
    string path = Server.MapPath("~");
    path = path.Substring(0, path.LastIndexOf("\\"));	
    string fileName = path + "\\File\\PivotTable.xls";

    
    // Imports from a excel file.
    GridWeb1.ImportExcelFile(fileName);

   
  }

  protected void btnReload_Click(object sender, EventArgs e)
  {
    InitData();
  }

  //Handles creating report from WebWorksheet
 protected void btnWorksheet_Click(object sender, EventArgs e)
  {
     


      GridWorksheet sourceSheet = GridWeb1.WorkSheets[0];
      Aspose.Cells.GridWeb.Data.GridCellArea sourceRange = new GridCellArea();
      sourceRange.StartRow = 0;
      sourceRange.StartColumn = 0;
      sourceRange.EndRow = 29;
      sourceRange.EndColumn = 5;
      GridWorksheet sheet = GridWeb1.WorkSheets["Form WebWorksheet"];
      if (sheet == null)
      {
          sheet = GridWeb1.WorkSheets.Add("Form WebWorksheet");
          GridCells cells = GridWeb1.WorkSheets[0].Cells;
          int id = sheet.PivotTables.Add(sourceSheet, sourceRange, "A1", "Form WebWorksheet");
          GridPivotTable pivotTable = sheet.PivotTables[id];





          //Apply formatting
          GridWeb1.DefaultFontName = "Arial";
          GridWeb1.DefaultFontSize = new System.Web.UI.WebControls.FontUnit(10);

          pivotTable.AddFieldToArea(GridPivotFieldType.Row, 0);
          pivotTable.AddFieldToArea(GridPivotFieldType.Row, 2);
          pivotTable.AddFieldToArea(GridPivotFieldType.Column, 3);
          pivotTable.AddFieldToArea(GridPivotFieldType.Column, 4);
          pivotTable.AddFieldToArea(GridPivotFieldType.Data, 5);
          pivotTable.Fields(GridPivotFieldType.Data)[0].Function = GridPivotFieldFunction.Sum;

          //Paints PivotTable report
          pivotTable.CalculateData();
      }

      GridWeb1.ActiveSheetIndex = sheet.Index;

     
  }
  
 

  private DataTable CreateDataTable(WebWorksheet sheet, WebCellArea area)
  {
    // Create a new DataTable.
    System.Data.DataTable myDataTable = new DataTable("FromDataTable");
    // Declare variables for DataColumn and DataRow objects.
    DataColumn myDataColumn;
    DataRow myDataRow;

    for (int i = area.StartColumn; i < area.EndColumn; i++)
    {
      // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
      myDataColumn = new DataColumn();
      myDataColumn.DataType = System.Type.GetType("System.String");
      myDataColumn.ColumnName = sheet.Cells[area.StartRow, i].Value.ToString();
      // Add the Column to the DataColumnCollection.
      myDataTable.Columns.Add(myDataColumn);
    }

    // Create six column.
    myDataColumn = new DataColumn();
    myDataColumn.DataType = System.Type.GetType("System.Int32");
    myDataColumn.ColumnName = sheet.Cells[area.StartRow, area.EndColumn].Value.ToString();
    // Add the column to the table.
    myDataTable.Columns.Add(myDataColumn);

    for (int i = area.StartRow + 1; i <= area.EndRow; i++)
    {
      myDataRow = myDataTable.NewRow();
      for (int j = area.StartColumn; j <= area.EndColumn; j++)
      {
        myDataRow[sheet.Cells[0, j].Value.ToString()] = sheet.Cells[i, j].Value;
      }
      myDataTable.Rows.Add(myDataRow);
    }

    return myDataTable;
  }

  protected void GridWeb1_SaveCommand(object sender, EventArgs e)
  {
    // Generates a temporary file name.
    string filename = System.IO.Path.GetTempPath() + Session.SessionID + ".xls";

    // Saves to the file.
    this.GridWeb1.WebWorksheets.SaveToExcelFile(filename);

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
