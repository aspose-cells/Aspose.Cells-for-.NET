using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Cells
{
    public partial class SetCustomFilter : System.Web.UI.Page
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
        }     

        protected void btnApplyCustomFilter_Click(object sender, EventArgs e)
        {
            // ExStart:SetCustomFilter
            // Access active worksheet
            var sheet = GridWeb1.WorkSheets[this.GridWeb1.ActiveSheetIndex];

            // Enable GridWeb's custom-filter.
            sheet.AddCustomFilter(1, "CELL0=\"1\"");
            sheet.RefreshFilter();           
            // ExEnd:SetCustomFilter
        }
    }
}