using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class ApplyHeaderBarStyle : System.Web.UI.Page
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

        protected void btnApplyHeaderStyle_Click(object sender, EventArgs e)
        {
            //ExStart:ApplyHeaderBarStyle
            //Setting the background color of the header bars
            GridWeb1.HeaderBarStyle.BackColor = System.Drawing.Color.Brown;

            //Setting the foreground color of the header bars
            GridWeb1.HeaderBarStyle.ForeColor = System.Drawing.Color.Yellow;

            //Setting the font of the header bars to bold
            GridWeb1.HeaderBarStyle.Font.Bold = true;

            //Setting the font name to "Century Gothic"
            GridWeb1.HeaderBarStyle.Font.Name = "Century Gothic";

            //Setting the border width to 2 points
            GridWeb1.HeaderBarStyle.BorderWidth = new Unit(2, UnitType.Point);
            //ExEnd:ApplyHeaderBarStyle
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
    }
}