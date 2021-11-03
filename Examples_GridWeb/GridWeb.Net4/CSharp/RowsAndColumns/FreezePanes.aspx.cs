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

namespace Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns
{
    public partial class FreezePanes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If first visit this page clear GridWeb and load data
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {

                GridWeb1.WorkSheets.Add();

                // Set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0;

                LoadData();
            }
        }

        private void LoadData()
        {
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

            string fileName = path + "\\RowsAndColumns\\FreezePane.xls";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
            GridWeb1.ActiveCell = GridWeb1.WorkSheets[0].Cells["A1"];
        }              
        
        protected void btnFreeze_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // ExStart:FreezePanes
                // Get user inputs for row, column, number of rows and number of columns
                int row = Convert.ToInt16(txtRow.Text.Trim());
                int column = Convert.ToInt16(txtColumn.Text.Trim());
                int noOfRows = Convert.ToInt16(txtNoOfRows.Text.Trim());
                int noOfColumns = Convert.ToInt16(txtNoOfColumns.Text.Trim());

                // Accessing the reference of the worksheet that is currently active
                GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                // Freeze desired rows and columns
                sheet.FreezePanes(row, column, noOfRows, noOfColumns);
                // ExEnd:FreezePanes
            }            
        }

        protected void btnUnfreeze_Click(object sender, EventArgs e)
        {
            // ExStart:UnfreezePanes
            // Accessing the reference of the worksheet that is currently active
            GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Unfreezing rows and columns
            sheet.UnFreezePanes();
            // ExEnd:UnfreezePanes
        }
    }
}

