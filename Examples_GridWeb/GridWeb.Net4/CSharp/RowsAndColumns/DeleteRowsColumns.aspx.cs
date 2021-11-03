using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns
{
    public partial class DeleteRowsColumns : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                LoadData();

                // Set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0;
            }
        }

        private void LoadData()
        {
            // License li = new  License();
            // li.SetLicense(@"D:\grid_project\ZZZZZZ_release_version\Aspose.Total.20141214.lic");

            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

            string fileName = path + "\\RowsAndColumns\\SampleData.xlsx";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
            GridWeb1.ActiveCell = GridWeb1.WorkSheets[0].Cells["A1"];
        }

        protected void btnDeleteColumn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // ExStart:DeleteColumn
                // Accessing the reference of the worksheet that is currently active
                GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                // Get column index entered by user
                int columnIndex = Convert.ToInt16(txtColumnIndex.Text.Trim());

                // Delete column at specified index
                sheet.Cells.DeleteColumn(columnIndex);
                // ExEnd:DeleteColumn
            }            
        }

        protected void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // ExStart:DeleteRow
                // Accessing the reference of the worksheet that is currently active
                GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                // Get row index entered by user
                int rowIndex = Convert.ToInt16(txtRowIndex.Text.Trim());

                // Delete row at specified index
                sheet.Cells.DeleteRow(rowIndex);
                // ExEnd:DeleteRow
            }            
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }    
    }
}