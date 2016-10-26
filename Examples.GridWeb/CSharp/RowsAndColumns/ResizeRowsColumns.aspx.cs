using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns
{
    public partial class ResizeRowsColumns : System.Web.UI.Page
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

        protected void btnSetColumnWidth_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // ExStart:SetColumnWidth
                // Get column index entered by user 
                int columnIndex = Convert.ToInt16(txtColumnIndex.Text.Trim());

                // Get column width entered by user
                int columnWidth = Convert.ToInt16(txtColumnWidth.Text.Trim());

                // Accessing the cells collection of the worksheet that is currently active
                GridCells cells = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex].Cells;

                // Resize column at specified index to specified width
                cells.SetColumnWidth(columnIndex, columnWidth);         
                // ExEnd:SetColumnWidth
            }            
        }

        protected void btnSetRowHeight_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // ExStart:SetRowHeight
                // Get row index entered by user
                int rowIndex = Convert.ToInt16(txtRowIndex.Text.Trim());

                // Get row height entered by user
                int rowHeight = Convert.ToInt16(txtRowHeight.Text.Trim());

                // Accessing the cells collection of the worksheet that is currently active
               GridCells cells = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex].Cells;

                // Resize row at specified index to specified height
                cells.SetRowHeight(rowIndex, rowHeight);
                // ExEnd:SetRowHeight
            }            
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }       
    }
}