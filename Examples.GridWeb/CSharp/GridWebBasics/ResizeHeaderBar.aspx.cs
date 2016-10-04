using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class ResizeHeaderBar : System.Web.UI.Page
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
            string fileName = path + "\\Data\\GridWebBasics\\SampleData.xls";

            // Imports from a excel file.
            GridWeb1.ImportExcelFile(fileName);
        }

        protected void btnResizeHeaderBar_Click(object sender, EventArgs e)
        {
            //ExStart:ResizeHeaderBar
            //Setting the height of header bar
            GridWeb1.HeaderBarHeight = new Unit(35, UnitType.Point);

            //Setting the width of header bar
            GridWeb1.HeaderBarWidth = new Unit(50, UnitType.Point);
            //ExStart:ResizeHeaderBar
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