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

namespace Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.PivotTable
{
    public partial class CreatePivotTableFromWorksheet : System.Web.UI.Page
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
            // Create path to xls file
            string path = (this.Master as Site).GetDataDir();

            // Set filename
            string fileName = path + "\\Miscellaneous\\PivotTable.xls";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            InitData();
        }

        // Handles creating report from WebWorksheet
        protected void btnWorksheet_Click(object sender, EventArgs e)
        {
            // Extract cells from source sheet
            GridWorksheet sourceSheet = GridWeb1.WorkSheets[0];
            Aspose.Cells.GridWeb.Data.GridCellArea sourceRange = new GridCellArea();
            sourceRange.StartRow = 0;
            sourceRange.StartColumn = 0;
            sourceRange.EndRow = 29;
            sourceRange.EndColumn = 5;

            GridWorksheet sheet = GridWeb1.WorkSheets["From WebWorksheet"];

            if (sheet == null)
            {
                // Add worksheet
                sheet = GridWeb1.WorkSheets.Add("From WebWorksheet");

                GridCells cells = GridWeb1.WorkSheets[0].Cells;
                
                // Add pivot table
                int id = sheet.PivotTables.Add(sourceSheet, sourceRange, "A1", "Form WebWorksheet");
                GridPivotTable pivotTable = sheet.PivotTables[id];

                // Apply formatting
                GridWeb1.DefaultFontName = "Arial";
                GridWeb1.DefaultFontSize = new System.Web.UI.WebControls.FontUnit(10);

                pivotTable.AddFieldToArea(GridPivotFieldType.Row, 0);
                pivotTable.AddFieldToArea(GridPivotFieldType.Row, 2);
                pivotTable.AddFieldToArea(GridPivotFieldType.Column, 3);
                pivotTable.AddFieldToArea(GridPivotFieldType.Column, 4);
                pivotTable.AddFieldToArea(GridPivotFieldType.Data, 5);
                pivotTable.Fields(GridPivotFieldType.Data)[0].Function = GridPivotFieldFunction.Sum;

                // Paints PivotTable report
                pivotTable.CalculateData();
            }

            GridWeb1.ActiveSheetIndex = sheet.Index;
        }
        
        protected void GridWeb1_SaveCommand(object sender, EventArgs e)
        {
            // Generates a temporary file name.
            string filename = Session.SessionID + "_out.xls";

            string path = (this.Master as Site).GetDataDir() + "\\";

            // Saves to the file.
            this.GridWeb1.SaveToExcelFile(path + filename);

            // Sents the file to browser.
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=" + filename);
            Response.WriteFile(path + filename);
            Response.End();  
        }

        protected void lnkFile_Click(object sender, EventArgs e)
        {
            // Create path to xls file
            string path = (this.Master as Site).GetDataDir() + "\\Miscellaneous\\";

            // Set filename
            string fileName = "PivotTable.xls";

            // Sents the file to browser.
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            Response.WriteFile(path + fileName);
            Response.End();  
        }
    }
}

