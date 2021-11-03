using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class DisplayCellEditBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                // ExStart:DisplayCellEditBox
                // Making the Edit Box (toolbar) visible for the GridWeb control
                GridWeb1.ShowCellEditBox = true;
                // ExEnd:DisplayCellEditBox
            }
            else
            {
                // Hide the Edit Box (toolbar) for the GridWeb control
                GridWeb1.ShowCellEditBox = false;
            }      
        }

        protected void GridWeb1_SaveCommand(object sender, EventArgs e)
        {          
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
        }
    }
}