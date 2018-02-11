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

            // Imports from a excel file.
            GridWeb1.ImportExcelFile(fileName);
        }

        protected void btnApplyHeaderStyle_Click(object sender, EventArgs e)
        {
            // ExStart:ApplyHeaderBarStyle
            // Setting header bar properties, BackColor, ForeColor, Font & BorderWidth
            GridWeb1.HeaderBarStyle.BackColor = System.Drawing.Color.Brown;            
            GridWeb1.HeaderBarStyle.ForeColor = System.Drawing.Color.Yellow;
            GridWeb1.HeaderBarStyle.Font.Bold = true;
            GridWeb1.HeaderBarStyle.Font.Name = "Century Gothic";            
            GridWeb1.HeaderBarStyle.BorderWidth = new Unit(2, UnitType.Point);
            // ExEnd:ApplyHeaderBarStyle
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