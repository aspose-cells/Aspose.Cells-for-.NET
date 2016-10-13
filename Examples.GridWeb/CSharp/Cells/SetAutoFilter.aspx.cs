using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Cells
{
    public partial class SetAutoFilter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If first visit to the page, init GridWeb
            if (!Page.IsPostBack && !GridWeb1.IsPostBack)
            {
                InitGridWeb();
            }
        }

        private void InitGridWeb()
        {
            GridWeb1.WorkSheets.Clear();

            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

            string fileName = path + "\\Cells\\Products.xlsx";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
            GridWeb1.ActiveCell = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex].Cells["A1"];

            // ExStart:SetAutoFilter
            // Enable GridWeb's auto-filter.
            GridWeb1.WebWorksheets[GridWeb1.ActiveSheetIndex].RowFilter.EnableAutoFilter = true;

            // Set the header row.
            GridWeb1.WebWorksheets[GridWeb1.ActiveSheetIndex].RowFilter.HeaderRow = 0;


            // Set the starting column.
            GridWeb1.WebWorksheets[0].RowFilter.StartColumn = 0;

            // Set the ending column.
            GridWeb1.WebWorksheets[0].RowFilter.EndColumn = 9;
            // ExEnd:SetAutoFilter
        }
    }
}