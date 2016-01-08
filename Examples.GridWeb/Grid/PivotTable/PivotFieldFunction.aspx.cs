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
using System.ComponentModel;

public partial class demos_PivotTable_PivotFieldFunction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack&&!GridWeb1.IsPostBack)
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

    GridWorksheet sourceSheet = GridWeb1.WorkSheets[0];
    Aspose.Cells.GridWeb.Data.GridCellArea sourceRange = new GridCellArea();
    sourceRange.StartRow = 0;
    sourceRange.StartColumn = 0;
    sourceRange.EndRow = 29;
    sourceRange.EndColumn = 5;

    GridWorksheet sheet = GridWeb1.WorkSheets.Add("PivotTable Report");
    GridCells cells = GridWeb1.WorkSheets[0].Cells;
    int id = sheet.PivotTables.Add(sourceSheet, sourceRange, "A1", "PivotTable Report");
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

    //Get sheet index
    GridWeb1.ActiveSheetIndex = sheet.Index;
  }
 

  protected void btnReload_Click(object sender, EventArgs e)
  {
    InitData();
  }
  protected void ddlSummary_SelectedIndexChanged(object sender, System.EventArgs e)
  {
    //Create pivot table object against selected dropdownlist value
      GridWorksheet sheet = GridWeb1.WorkSheets["PivotTable Report"];
      GridPivotTable pivotTable = sheet.PivotTables[0];

    //Bind pivot table
      pivotTable.Fields(GridPivotFieldType.Data)[0].Function =
      (GridPivotFieldFunction)TypeDescriptor.GetConverter
      (typeof(GridPivotFieldFunction)).ConvertFrom
      (ddlSummary.SelectedItem.Value);
      //Paints PivotTable report
      pivotTable.CalculateData();
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
