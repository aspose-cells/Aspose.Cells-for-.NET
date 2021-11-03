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
using System.Drawing;
using Aspose.Cells.GridWeb.DemosCS;
using Aspose.Cells.GridWeb;

namespace Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns
{
    public partial class AddRowsColumns : System.Web.UI.Page
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
            
        protected void btnAddColumn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // ExStart:AddColumn
                // Accessing the reference of the worksheet that is currently active
                GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                // Get column index entered by user
                int columnIndex = Convert.ToInt16(txtColumnIndex.Text.Trim());

                // Add column at specified index
                sheet.Cells.InsertColumn(columnIndex);
                // ExEnd:AddColumn
            }            
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // ExStart:AddRow
                // Accessing the reference of the worksheet that is currently active
                GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                // Get row index entered by user
                int rowIndex = Convert.ToInt16(txtRowIndex.Text.Trim());

                // Add row at specified index
                sheet.Cells.InsertRow(rowIndex);
                // ExEnd:AddRow            
            }
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }       
    }
}
