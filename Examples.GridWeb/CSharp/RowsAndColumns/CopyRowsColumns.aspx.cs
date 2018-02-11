using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns
{
    public partial class CopyRowsColumns : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && !GridWeb1.IsPostBack)
            {
                LoadData();

                // Set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0;

                Label1.Text = "";
            }
        }

        private void LoadData()
        {
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

            string fileName = path + "\\RowsAndColumns\\CopyData.xlsx";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
            GridWeb1.ActiveCell = GridWeb1.WorkSheets[0].Cells["A1"];
        }

        protected void btnCopyRow_Click(object sender, EventArgs e)
        {
            // Set sheets selectedIndex to 0
            GridWeb1.WorkSheets.ActiveSheetIndex = 0;

            // ExStart:CopyRow
            // Get the instance of active GridWorksheet
            var activeSheet = GridWeb1.ActiveSheet;

            // Copy first row to next row
            activeSheet.Cells.CopyRow(activeSheet.Cells, 0, 1);

            Label1.Text = "Row 1 copied to row 2 in worksheet " + activeSheet.Name;
            // ExEnd:CopyRow
        }

        protected void btnCopyMultipleRows_Click(object sender, EventArgs e)
        {
            // Set sheets selectedIndex to 1
            GridWeb1.WorkSheets.ActiveSheetIndex = 1;

            // ExStart:CopyMultipleRows
            // Get the instance of active GridWorksheet
            var activeSheet = GridWeb1.ActiveSheet;

            // Copy first 3 rows to 7th row
            activeSheet.Cells.CopyRows(activeSheet.Cells, 0, 6, 3);

            Label1.Text = "Rows 1 to 3 copied to rows 7 to 9 in worksheet " + activeSheet.Name;
            // ExEnd:CopyMultipleRows
        }

        protected void btnCopyColumn_Click(object sender, EventArgs e)
        {
            // Set sheets selectedIndex to 2
            GridWeb1.WorkSheets.ActiveSheetIndex = 2;

            // ExStart:CopyColumn
            // Get the instance of active GridWorksheet
            var activeSheet = GridWeb1.ActiveSheet;

            // Copy first column to next column
            activeSheet.Cells.CopyColumn(activeSheet.Cells, 0, 1);

            Label1.Text = "Column 1 copied to column 2 in worksheet " + activeSheet.Name;
            // ExEnd:CopyColumn
        }

        protected void btnCopyMultipleColumns_Click(object sender, EventArgs e)
        {
            // Set sheets selectedIndex to 3
            GridWeb1.WorkSheets.ActiveSheetIndex = 3;

            // ExStart:CopyMultipleColumns
            // Get the instance of active GridWorksheet
            var activeSheet = GridWeb1.ActiveSheet;

            // Copy first 3 column to 7th column
            activeSheet.Cells.CopyColumns(activeSheet.Cells, 0, 6, 3);

            Label1.Text = "Columns 1 to 3 copied to columns 7 to 9 in worksheet " + activeSheet.Name;
            // ExEnd:CopyMultipleColumns
        }
    }
}