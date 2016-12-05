using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class GetGridWebVersion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetGridWebVersion_Click(object sender, EventArgs e)
        {
            // ExStart:GetGridWebVersion
            // Find version of GridWeb and display in label.
            string version = Aspose.Cells.GridWeb.GridWeb.GetVersion();
            Label1.Text = "GridWeb Version: " + version;
            // ExEnd:GetGridWebVersion
        }

        protected void GridWeb1_SaveCommand(object sender, EventArgs e)
        {
            // ExStart:SaveExcelFile
            // Generates a temporary file name.
            string filename = Session.SessionID + "_out.xls";

            string path = (this.Master as Site).GetDataDir() + "\\GridWebBasics\\";

            // Saves to the file.
            this.GridWeb1.SaveToExcelFile(path + filename);

            // Sents the file to browser.
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=" + filename);
            Response.WriteFile(path + filename);
            Response.End();
            // ExEnd:SaveExcelFile
        }
    }
}