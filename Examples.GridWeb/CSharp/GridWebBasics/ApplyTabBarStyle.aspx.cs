using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class ApplyTabBarStyle : System.Web.UI.Page
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

            string fileName = path + "\\GridWebBasics\\Skins.xls";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
        }

        protected void GridWeb1_SaveCommand(object sender, EventArgs e)
        {
            // Generates a temporary file name.
            string filename = Session.SessionID + "_out_.xls";

            string path = (this.Master as Site).GetDataDir() + "\\GridWebBasics\\";

            // Saves to the file.
            this.GridWeb1.SaveToExcelFile(path + filename);

            // Sents the file to browser.
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=" + filename);
            Response.WriteFile(path + filename);
            Response.End();      
        }

        protected void btnApplyTabBarStyle_Click(object sender, EventArgs e)
        {
            // ExStart:ApplyTabBarStyle
            // Setting the background color of tabs to Yellow
            GridWeb1.TabStyle.BackColor = System.Drawing.Color.Yellow;

            // Setting the foreground color of tabs to Blue
            GridWeb1.TabStyle.ForeColor = System.Drawing.Color.Blue;

            // Setting the background color of active tab to Blue
            GridWeb1.ActiveTabStyle.BackColor = System.Drawing.Color.Blue;

            // Setting the foreground color of active tab to Yellow
            GridWeb1.ActiveTabStyle.ForeColor = System.Drawing.Color.Yellow;
            // ExEnd:ApplyTabBarStyle
        }

    }
}