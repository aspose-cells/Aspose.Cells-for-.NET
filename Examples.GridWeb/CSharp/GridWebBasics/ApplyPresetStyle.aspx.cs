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
                    //Applying Colorful1 style on the GridWeb control
                    GridWeb1.PresetStyle =PresetStyle.Colorful1;
                    // ExEnd:ApplyPresetStyle
                    break;
                case "Colorful2":
                    //Applying Colorful2 style on the GridWeb control
                    GridWeb1.PresetStyle= PresetStyle.Colorful2;
                    break;
                case "Professional1":
                    //Applying Professional1 style on the GridWeb control
                    GridWeb1.PresetStyle = PresetStyle.Professional1;
                    break;
                case "Professional2":
                    //Applying Professional2 style on the GridWeb control
                    GridWeb1.PresetStyle = PresetStyle.Professional2;
                    break;
                case "Traditional1":
                    //Applying Traditional1 style on the GridWeb control
                    GridWeb1.PresetStyle = PresetStyle.Traditional1;
                    break;
                case "Traditional2":
                    //Applying Traditional2 style on the GridWeb control
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

