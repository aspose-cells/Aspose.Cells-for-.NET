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
using Aspose.Cells.GridWeb;
using Aspose.Cells.GridWeb.Data;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class ImportExportFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if first visit this page clear GridWeb1 
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                GridWeb1.WorkSheets.Clear();
                GridWeb1.WorkSheets.Add();
            }
        }
              

        private void LoadData()
        {
            //   License li = new  License();
            //  li.SetLicense(@"D:\grid_project\ZZZZZZ_release_version\Aspose.Total.20141214.lic");

            //ExStart:LoadExcelFile
            // Gets the web application's path.
            string path = Server.MapPath("~");

            // Upper level.
            path = path.Substring(0, path.LastIndexOf("\\"));
            string fileName = path + "\\Data\\GridWebBasics\\SampleData.xls";

            // Imports from a excel file.
            GridWeb1.ImportExcelFile(fileName);
            //ExEnd:LoadExcelFile

        }

        // Handles the load file button click event and load an excel file from disk
        protected void btnLoadExcelFile_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void GridWeb1_SaveCommand(object sender, EventArgs e)
        {
            //ExStart:SaveExcelFile
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
            //ExEnd:SaveExcelFile
        }

      
    }
}

