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
using System.ComponentModel;

public partial class demos_PivotTable_CustomReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InitData();
     
    }

  private void InitData()
  {
      if (!(!IsPostBack && !GridWeb1.IsPostBack))
          return;
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
      GridPivotTable pivotTable=sheet.PivotTables[id];
 
  

    

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

    GridWeb1.ActiveSheetIndex = sheet.Index;
  }

  protected void btnReload_Click(object sender, EventArgs e)
  {
    InitData();
  }

  //Renames field label to show
  protected void btnSubmit4_Click(object sender, EventArgs e)
  {
    //initialization
    InitData();

    GridWorksheet sheet = GridWeb1.WorkSheets["PivotTable Report"];
   
    GridPivotTable pivotTable = sheet.PivotTables[0];

    //Sets field Caption property to be show in the report
    pivotTable.Fields("Employee").DisplayName = txtEmployee.Text.Trim();
    pivotTable.Fields("Product").DisplayName = txtCountry.Text.Trim();

    //Paints PivotTable report
     pivotTable.CalculateData(); 
  }

  //Sets row or column field position
  protected void btnSubmit3_Click(object sender, EventArgs e)
  { 
    //initialization
    InitData();
    GridWorksheet sheet = GridWeb1.WorkSheets["PivotTable Report"];

    GridPivotTable pivotTable = sheet.PivotTables[0];

    //Sets feild Position property determining the location of the field
    pivotTable.Fields("Employee").Position = int.Parse(TextBox3.Text.Trim());
    pivotTable.Fields("Country").Position = int.Parse(TextBox4.Text.Trim());

    //Paints PivotTable report
    pivotTable.CalculateData(); 
  }

  //Sets row or column order
  protected void btnSubmit2_Click(object sender, EventArgs e)
  {
    //initialization
    InitData();
    GridWorksheet sheet = GridWeb1.WorkSheets["PivotTable Report"];

    GridPivotTable pivotTable = sheet.PivotTables[0];

    //Sets field SortOrder property determining the order of the field item
    pivotTable.Fields("Employee").IsAscendSort = (ddlEmployee.SelectedItem.Value.Equals("Asc"));


    pivotTable.Fields("Country").IsAscendSort = (ddlCountry.SelectedItem.Value.Equals("Asc"));


      //Paints PivotTable report
      
      pivotTable.CalculateData();
  }

  //Hides some row or column
  protected void btnSubmit_Click(object sender, EventArgs e)
  {
    //initialization
    InitData();
    GridWorksheet sheet = GridWeb1.WorkSheets["PivotTable Report"];

    GridPivotTable pivotTable = sheet.PivotTables[0];

    //Sets field item visible property indicating whether the item is visible
    pivotTable.Fields("Employee").HideItemByName("David", !CheckBox1.Checked);
    pivotTable.Fields("Product").HideItemByName ( "Maxilaku",!CheckBox2.Checked);
    pivotTable.Fields("Continent").HideItemByName( "Europe",!CheckBox3.Checked);
    pivotTable.Fields("Country").HideItemByName( "China",!CheckBox4.Checked);

    //Paints PivotTable report
    pivotTable.CalculateData(); 
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
