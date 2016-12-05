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

namespace Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common
{
    public partial class ShowHeaderBarAndCommandButton : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If first visit this page clear GridWeb1 
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                LoadData();

                // Set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0;
            }
        }

        private void LoadData()
        {
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();
            string fileName = path + "\\Miscellaneous\\ShowHeaderBar.xls";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
        }

        protected void GridWeb1_SaveCommand(object sender, System.EventArgs e)
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

        protected void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            // Show/Hide Header Bar
            GridWeb1.ShowHeaderBar = CheckBox1.Checked;
        }

        protected void Checkbox2_CheckedChanged(object sender, System.EventArgs e)
        {
            // Show/Hide Submit Button
            GridWeb1.ShowSubmitButton = CheckBox2.Checked;
        }

        protected void Checkbox3_CheckedChanged(object sender, System.EventArgs e)
        {
            // Show/Hide Save Button
            GridWeb1.ShowSaveButton = CheckBox3.Checked;
        }

        protected void Checkbox4_CheckedChanged(object sender, System.EventArgs e)
        {
            // Show/Hide Undo Button
            GridWeb1.ShowUndoButton = CheckBox4.Checked;
        }

        protected void chkNoScrollBar_CheckedChanged(object sender, System.EventArgs e)
        {
            // Show/Hide ScrollBar
            GridWeb1.NoScroll = chkNoScrollBar.Checked;
        }

        protected void chkNoTabBar_CheckedChanged(object sender, EventArgs e)
        {
            // Show/Hide Navigation Tab
            GridWeb1.ShowTabNavigation = !CheckBox5.Checked;
        }

    }
}

