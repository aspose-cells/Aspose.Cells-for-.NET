using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns
{
    public partial class HandleColumnFilterEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If first visit, load GridWeb data
            if (!Page.IsPostBack && !GridWeb1.IsPostBack)
            {
                LoadData();
            }
            else
            {
                Label1.Text = "";
            }            
        }

        private void LoadData()
        {
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

            string fileName = path + "\\RowsAndColumns\\Products.xlsx";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
            GridWeb1.ActiveCell = GridWeb1.WorkSheets[0].Cells["A1"];

            // Access active worksheet
            var sheet = GridWeb1.WorkSheets[this.GridWeb1.ActiveSheetIndex];

            // Enable GridWeb's auto-filter.
            sheet.AddAutoFilter(0, 0, sheet.Cells.MaxDataColumn);
            sheet.RefreshFilter();
        }

        // ExStart:BeforeColumnFilter
        protected void GridWeb1_BeforeColumnFilter(object sender, RowColumnEventArgs e)
        {
            // Display the column index and filter applied
            string msg = "[Column Index]: " + (e.Num) + ", [Filter Value]: " + e.Argument;
            Label1.Text = msg;
        }
        // ExEnd:BeforeColumnFilter

        // ExStart:AfterColumnFilter
        protected void GridWeb1_AfterColumnFilter(object sender, RowColumnEventArgs e)
        {
            string hidden = "";
            int headrow = 0;
            int maxrow = GridWeb1.WorkSheets[0].Cells.MaxRow;
            int count = 0;

            // Iterate all worksheet rows to find out filtered rows
            for (int i = headrow + 1; i <= maxrow; i++)
            {
                if (GridWeb1.WorkSheets[0].Cells.Rows[i].Hidden)
                {
                    hidden += "-" + (i + 1);
                }
                else
                {
                    count++;
                }
            }

            // Display hidden rows and visible rows count 
            string msg = "[Hidden Rows]: " + hidden + " [Visible Rows]: " + count;
            Label1.Text = msg;
        }
        // ExEnd:AfterColumnFilter
    }
}