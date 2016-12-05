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
            // If first visit this page clear GridWeb1 
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                GridWeb1.WorkSheets.Clear();
                GridWeb1.WorkSheets.Add();
            }
        }
         
        private void LoadData()
        {
            // License li = new  License();
            // li.SetLicense(@"D:\grid_project\ZZZZZZ_release_version\Aspose.Total.20141214.lic");

            // ExStart:LoadExcelFile
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

            string fileName = path + "\\GridWebBasics\\SampleData.xls";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
            // ExEnd:LoadExcelFile
        }

        // Handles the load file button click event and load an excel file from disk
        protected void btnLoadExcelFile_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void GridWeb1_SaveCommand(object sender, EventArgs e)
        {
            // ExStart:SaveExcelFile
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
            // ExEnd:SaveExcelFile
        }     
    }
}

