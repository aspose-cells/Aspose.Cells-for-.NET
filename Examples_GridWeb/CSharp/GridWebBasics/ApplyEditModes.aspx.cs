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

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class ApplyEditModes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If first visit this page clear GridWeb1 
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                GridWeb1.WorkSheets.Clear();
                GridWeb1.WorkSheets.Add();

                // Set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0;

                GridWeb1.ForceValidation = false;
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                // ExStart:ApplyEditMode
                // Enabling the Edit Mode of GridWeb
                GridWeb1.EditMode = true;
                // ExEnd:ApplyEditMode
            }
            else
            {
                // ExStart:ApplyViewMode
                // Enabling the View Mode of GridWeb
                GridWeb1.EditMode = false;
                // ExEnd:ApplyViewMode
            }
            
            Panel2.Visible = GridWeb1.EditMode;
            Panel3.Visible = GridWeb1.EditMode;
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

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            int row = int.Parse(this.TextBox1.Text);
            GridWeb1.WorkSheets[0].SetRowReadonly(row, CheckBox2.Checked);

        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            int col = int.Parse(this.TextBox2.Text);
            GridWeb1.WorkSheets[0].SetColumnReadonly(col, CheckBox3.Checked);
        }
               
    }
}
