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
using Aspose.Cells.GridWeb;
using System.ComponentModel;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class ApplyPresetStyle : System.Web.UI.Page
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

        // Handles the preset style dropdown list changing event
        protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
         
            // Changes the preset style using built in style thats The Aspose.Cells.GridWeb provides.
            switch (DropDownList1.SelectedValue) {
                case "Standard" :
                    //Applying Standard style on the GridWeb control
                    GridWeb1.PresetStyle = PresetStyle.Standard;
                    break;
                case "Colorful1":
                    // ExStart:ApplyPresetStyle
                    // Applying Colorful1 style on the GridWeb control
                    GridWeb1.PresetStyle =PresetStyle.Colorful1;
                    // ExEnd:ApplyPresetStyle
                    break;
                case "Colorful2":
                    // Applying Colorful2 style on the GridWeb control
                    GridWeb1.PresetStyle= PresetStyle.Colorful2;
                    break;
                case "Professional1":
                    // Applying Professional1 style on the GridWeb control
                    GridWeb1.PresetStyle = PresetStyle.Professional1;
                    break;
                case "Professional2":
                    // Applying Professional2 style on the GridWeb control
                    GridWeb1.PresetStyle = PresetStyle.Professional2;
                    break;
                case "Traditional1":
                    // Applying Traditional1 style on the GridWeb control
                    GridWeb1.PresetStyle = PresetStyle.Traditional1;
                    break;
                case "Traditional2":
                    // Applying Traditional2 style on the GridWeb control
                    GridWeb1.PresetStyle = PresetStyle.Traditional2;
                    break;
                default:
                    GridWeb1.PresetStyle = PresetStyle.Standard;
                    break;           
                
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

