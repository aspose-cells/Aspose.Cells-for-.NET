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

public partial class demos_Format_CreateReport : System.Web.UI.Page
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

     
   
   

    
   GridWorksheet sourceSheet = GridWeb1.WorkSheets[0];
    Aspose.Cells.GridWeb.Data.GridCellArea sourceRange = new GridCellArea();
    sourceRange.StartRow = 0;
    sourceRange.StartColumn = 0;
    sourceRange.EndRow = 29;
    sourceRange.EndColumn = 5;
    

    //Add sheet and get index
    GridWorksheet sheet = GridWeb1.WorkSheets.Add("PivotTable Report");
    GridCells cells = GridWeb1.WorkSheets[0].Cells;
    int id=sheet.PivotTables.Add(sourceSheet, sourceRange, "A1", "PivotTable Report");
    //Apply formatting
    GridWeb1.WorkSheets.DefaultFontName = "Arial";
    GridWeb1.WorkSheets.DefaultFontSize = new System.Web.UI.WebControls.FontUnit(10);

    
    //Clears all list box
    lbxFields.Items.Clear();
    lbxRowFields.Items.Clear();
    lbxColumnFields.Items.Clear();
    lbxDataFields.Items.Clear();
   // GridPivotTable pivotTable=sheet.PivotTables[id];
    //Adds PivotFields to lbxFields box.
   // GridPivotFieldCollection fields = pivotTable.Fields(GridPivotFieldType.Column);
    
    for (int i = 0; i < 6; i++)
    {
        lbxFields.Items.Add(new ListItem(cells[0, i].StringValue, cells[0, i].StringValue));
    }
      

  }

  protected void btnReload_Click(object sender, EventArgs e)
  {
    InitData();
  }

  protected void btnRowField_Click(object sender, EventArgs e)
  {
    if (lbxFields.SelectedItem != null)
    {
      ListItem item = new ListItem(lbxFields.SelectedItem.Text, lbxFields.SelectedItem.Value);
      //Removes from column fields and row fields
      lbxColumnFields.Items.Remove(item);
      lbxRowFields.Items.Remove(item);

      //Adds to the end of row fields 
      lbxRowFields.Items.Add(item);
    }
  }
  protected void btnColumnField_Click(object sender, EventArgs e)
  {
    if (lbxFields.SelectedItem != null)
    {
      ListItem item = new ListItem(lbxFields.SelectedItem.Text, lbxFields.SelectedItem.Value);
      //Removes from row fields and column fields
      lbxRowFields.Items.Remove(item);
      lbxColumnFields.Items.Remove(item);

      //Adds to the end of column fields
      lbxColumnFields.Items.Add(item);
    }
  }

  protected void btnDataField_Click(object sender, EventArgs e)
  {
    if (lbxFields.SelectedItem != null)
    {
      ListItem item = new ListItem(lbxFields.SelectedItem.Text, lbxFields.SelectedItem.Value);

      //Removes from data fields
      lbxDataFields.Items.Remove(item);

      //Adds to the end of column fields
      lbxDataFields.Items.Add(item);
    }
  }

  protected void btnRemove_Click(object sender, EventArgs e)
  {
    //Clear list box items
    lbxRowFields.Items.Clear();
  }
  protected void btnRemove1_Click(object sender, EventArgs e)
  {
      //Clear list box items
      lbxColumnFields.Items.Clear();
  }
  protected void btnRemove2_Click(object sender, EventArgs e)
  {
      //Clear list box items
      lbxDataFields.Items.Clear();
  }
  protected void btnCreateReport_Click(object sender, EventArgs e)
  {
    //Validates
    if (lbxRowFields.Items.Count < 1)
    {
      Util.ShowMessage(this, "Please Sets row field");
      return;
    }
    if (lbxColumnFields.Items.Count < 1)
    {
      Util.ShowMessage(this, "Please Sets column field");
      return;
    }
    if (lbxDataFields.Items.Count < 1)
    {
      Util.ShowMessage(this, "Please Sets data field");
      return;
    }

    //Sets PivotTable report row fields .
    GridPivotTable pivotTable = GridWeb1.WorkSheets[1].PivotTables[0];
    pivotTable.ClearAllFields();
    for (int i = 0; i < lbxRowFields.Items.Count; i++)
    {

        pivotTable.AddFieldToArea(GridPivotFieldType.Row, lbxRowFields.Items[i].Text);
      
    }
    //Set PivotTable report column fields
    for (int i = 0; i < lbxColumnFields.Items.Count; i++)
    {
        pivotTable.AddFieldToArea(GridPivotFieldType.Column, lbxColumnFields.Items[i].Text);
    }
    //Set PivotTable data fields
    for (int i = 0; i < lbxDataFields.Items.Count; i++)
    {
        int j = pivotTable.AddFieldToArea(GridPivotFieldType.Data, lbxDataFields.Items[i].Text);
          if (lbxDataFields.Items[i].Text == "Sale")
          {
            pivotTable.Fields(GridPivotFieldType.Data)[j].Function = GridPivotFieldFunction.Sum;
          }
      
    }
    //Paints PivotTable report
    pivotTable.CalculateData();
    
      //Set Activesheet
    GridWeb1.ActiveSheetIndex = GridWeb1.WorkSheets["PivotTable Report"].Index;
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
