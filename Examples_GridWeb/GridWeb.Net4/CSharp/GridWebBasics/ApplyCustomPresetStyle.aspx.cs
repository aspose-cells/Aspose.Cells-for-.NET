using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class ApplyCustomPresetStyle : System.Web.UI.Page
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

        protected void btnSaveCustomStyle_Click(object sender, EventArgs e)
        {
            // ExStart:SaveCustomStyle
            // Setting header bar properties, BackColor, ForeColor, Font & BorderWidth
            GridWeb1.HeaderBarStyle.BackColor = System.Drawing.Color.Brown;
            GridWeb1.HeaderBarStyle.ForeColor = System.Drawing.Color.Yellow;
            GridWeb1.HeaderBarStyle.Font.Bold = true;
            GridWeb1.HeaderBarStyle.Font.Name = "Century Gothic";
            GridWeb1.HeaderBarStyle.BorderWidth = new Unit(2, UnitType.Point);

            // Setting Tab properties, BackColor, ForeColor
            GridWeb1.TabStyle.BackColor = System.Drawing.Color.Yellow;
            GridWeb1.TabStyle.ForeColor = System.Drawing.Color.Blue;

            // Setting Active Tab properties, BackColor, ForeColor
            GridWeb1.ActiveTabStyle.BackColor = System.Drawing.Color.Blue;
            GridWeb1.ActiveTabStyle.ForeColor = System.Drawing.Color.Yellow;

            // Saving style information to an XML file
            GridWeb1.SaveCustomStyleFile((this.Master as Site).GetDataDir() + "\\GridWebBasics\\CustomPresetStyle_out.xml");
            // ExEnd:SaveCustomStyle

            lblMessage.Text = "Custom style xml file saved successfully at Data/GridWebBasics/CustomPresetStyle_out.xml";
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

        protected void btnApplyCustomStyle_Click(object sender, EventArgs e)
        {
            // ExStart:LoadCustomStyle
            // Setting the PresetStyle of the control to Custom
            GridWeb1.PresetStyle = PresetStyle.Custom;

            // Setting the path of style file to load style information from this file to the control
            GridWeb1.CustomStyleFileName = (this.Master as Site).GetDataDir() + "\\GridWebBasics\\CustomStyle1.xml";
            // ExEnd:LoadCustomStyle
        }
    }
}