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

namespace Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Formula
{
    public partial class ApplyMathematicalFormulas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                ReLoadData();

                // Set sheets selectedIndex to 0
                GridWeb1.ActiveSheetIndex = 0;
            }
        }

        private void ReLoadData()
        {
            // Create path to xls file
            string path = (this.Master as Site).GetDataDir();

            // Set filename
            string fileName = path + "\\Miscellaneous\\Math.xls";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            ReLoadData();
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

        protected void lnkFile_Click(object sender, EventArgs e)
        {
            // Create path to xls file
            string path = (this.Master as Site).GetDataDir() + "\\Miscellaneous\\";

            // Set filename
            string fileName = "Math.xls";

            // Sents the file to browser.
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            Response.WriteFile(path + fileName);
            Response.End();  
        }
    }
}

