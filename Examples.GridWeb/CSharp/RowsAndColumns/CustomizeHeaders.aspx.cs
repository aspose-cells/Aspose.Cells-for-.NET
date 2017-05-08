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

namespace Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns
{
    public partial class CustomizeHeaders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                GridWeb1.WorkSheets.Clear();
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

            string fileName = path + "\\RowsAndColumns\\Headers.xlsx";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
            GridWeb1.ActiveCell = GridWeb1.WorkSheets[0].Cells["A1"];
        }               

        protected void btnCreateCaption_Click(object sender, EventArgs e)
        {        
            CreateRowCaptions();
            CreateColumnCaptions();

            // Accessing the worksheet that is currently active
            GridWorksheet workSheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Adjusts column width.
            GridCells cells = workSheet.Cells;
            cells.SetColumnWidth(0, 20);
            cells.SetColumnWidth(1, 20);
            cells.SetColumnWidth(2, 20);
        }

        private void CreateColumnCaptions()
        {
            // ExStart:CustomizeColumnHeader
            // Accessing the worksheet that is currently active
            GridWorksheet workSheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Creates custom column header caption.
            workSheet.SetColumnCaption(0, "Product");
            workSheet.SetColumnCaption(1, "Category");
            workSheet.SetColumnCaption(2, "Price");
            // ExEnd:CustomizeColumnHeader
        }

        private void CreateRowCaptions()
        {
            // ExStart:CustomizeRowHeader
            // Accessing the worksheet that is currently active
            GridWorksheet workSheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

            // Create custom row header caption.
            workSheet.SetRowCaption(1, "Row1");
            workSheet.SetRowCaption(2, "Row2");
            // ExEnd:CustomizeRowHeader
        }
    }
}

