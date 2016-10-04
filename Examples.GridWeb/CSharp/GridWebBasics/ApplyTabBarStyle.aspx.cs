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

            //if first visit this page clear GridWeb1 
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                LoadData();

                //set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0;

            }
        }

        private void LoadData()
        {
            // Gets the web application's path.
            string path = Server.MapPath("~");
            path = path.Substring(0, path.LastIndexOf("\\"));
            string fileName = path + "\\Data\\GridWebBasics\\Skins.xls";

            // Imports from a excel file.
            GridWeb1.ImportExcelFile(fileName);
        }

        protected void GridWeb1_SaveCommand(object sender, EventArgs e)
        {
            // Generates a temporary file name.
            string filename = System.IO.Path.GetTempPath() + Session.SessionID + ".xls";

            // Saves to the file.
            this.GridWeb1.SaveToExcelFile(filename);

            // Sents the file to browser.
            Response.ContentType = "application/vnd.ms-excel";

            //Adds header.
            Response.AddHeader("content-disposition", "attachment; filename=book1.xls");

            // Writes file content to the response stream.
            Response.WriteFile(filename);

            // OK.
            Response.End();
        }

        protected void btnApplyTabBarStyle_Click(object sender, EventArgs e)
        {
            //ExStart:ApplyTabBarStyle
            //Setting the background color of tabs to Yellow
            GridWeb1.TabStyle.BackColor = System.Drawing.Color.Yellow;

            //Setting the foreground color of tabs to Blue
            GridWeb1.TabStyle.ForeColor = System.Drawing.Color.Blue;

            //Setting the background color of active tab to Blue
            GridWeb1.ActiveTabStyle.BackColor = System.Drawing.Color.Blue;

            //Setting the foreground color of active tab to Yellow
            GridWeb1.ActiveTabStyle.ForeColor = System.Drawing.Color.Yellow;
            //ExEnd:ApplyTabBarStyle
        }

    }
}