using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Worksheets
{
    public partial class ExportDataTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If first visit to the page init GridWeb data
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                InitData();

                // Set sheets selectedIndex to 0
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


        protected void btnExportDataTable_Click(object sender, EventArgs e)
        {
            // ExStart:ExportDataTable
            // Creating a new DataTable object
            DataTable dataTable = new DataTable();

            // Adding specific columns to the DataTable object
            dataTable.Columns.Add("Name", System.Type.GetType("System.String"));
            dataTable.Columns.Add("Gender", System.Type.GetType("System.String"));
            dataTable.Columns.Add("Age", System.Type.GetType("System.Int32"));
            dataTable.Columns.Add("Class", System.Type.GetType("System.String"));

            // Accessing the reference of the worksheet that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Getting the total number of rows and columns inside the worksheet
            int totalColumns = sheet.Cells.MaxColumn + 1;
            int totalRows = sheet.Cells.MaxRow + 1;

            // Exporting the data of the active worksheet to a specific DataTable object
            dataTable = sheet.Cells.Export(0, 0, totalRows, totalColumns, true, true);
            
            // Display exported data table in GridView
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
            // ExEnd:ExportDataTable

            // ExStart:ExportNewDataTable
            // Accessing the reference of the worksheet that is currently active
            GridWorksheet sheet1 = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Getting the total number of rows and columns inside the worksheet
            int totalColumns1 = sheet.Cells.MaxColumn + 1;
            int totalRows1 = sheet.Cells.MaxRow + 1;

            // Exporting the data of the active worksheet to a new DataTable object
            DataTable dt = sheet.Cells.Export(0, 0, totalRows1, totalColumns1, true, true);
            
            // Display exported data table in GridView
            GridView2.DataSource = dataTable;
            GridView2.DataBind();
            // ExEnd:ExportNewDataTable

            trResult.Visible = true;

        }
    }
}