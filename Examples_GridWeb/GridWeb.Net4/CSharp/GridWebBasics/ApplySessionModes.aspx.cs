using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class ApplySessionModes : System.Web.UI.Page
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

                LoadData();
            }
        }

        private void LoadData()
        {
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

            string fileName = path + "\\GridWebBasics\\SampleData.xls";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
     
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                // ExStart:ApplySesionMode
                // Enabling the Session Mode of GridWeb
                GridWeb1.SessionMode = SessionMode.Session;
                // ExEnd:ApplySesionMode
            }
            else
            {
                // ExStart:ApplySesionlessMode
                // Enabling the Sessionless Mode of GridWeb
                GridWeb1.SessionMode = SessionMode.ViewState;
                // ExEnd:ApplySesionlessMode
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