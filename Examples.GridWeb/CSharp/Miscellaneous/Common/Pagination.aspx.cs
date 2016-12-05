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

namespace Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common
{
    public partial class Pagination : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If first visit this page init GridWeb1 
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();
            string fileName = path + "\\Miscellaneous\\EmployeeSales.xls";

            // Clears datasheets first.
            GridWeb1.WorkSheets.Clear();

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);

            // Freeze sheet2
            GridWeb1.WorkSheets[1].FreezePanes(2, 0, 2, 0);

            // Set sheets selectedIndex to 0
            GridWeb1.WorkSheets.ActiveSheetIndex = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void GridWeb1_SaveCommand(object sender, EventArgs e)
        {
            // Generates a temporary file name.
            string filename = Session.SessionID + "_out.xls";

            string path = (this.Master as Site).GetDataDir() + "\\";

            // Saves to the file.
            this.GridWeb1.SaveToExcelFile(path + filename);

            // Sents the file to browser.
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=" + filename);
            Response.WriteFile(path + filename);
            Response.End();      
        }
    }
}

