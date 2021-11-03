using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class ImportExportFileFromStream : System.Web.UI.Page
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

            // ExStart:LoadExcelFileFromStream
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

            string fileName = path + "\\GridWebBasics\\SampleData.xls";

            // Opening an Excel file as a stream
            FileStream fs = File.OpenRead(fileName);

            // Loading the Excel file contents into the control from a stream
            GridWeb1.ImportExcelFile(fs);

            // Closing stream
            fs.Close();
            // ExEnd:LoadExcelFileFromStream
        }

        // Handles the load file button click event and load an excel file from disk
        protected void btnLoadExcelFile_Click(object sender, EventArgs e)
        {
            LoadData();
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

        protected void btnSaveUsingStream_Click(object sender, EventArgs e)
        {
            // ExStart:SaveExcelFileUsingStream
            // Generates a temporary file name.
            string filename = Session.SessionID + "_out.xls";

            string path = (this.Master as Site).GetDataDir() + "\\GridWebBasics\\";
            
            FileStream fs = File.Create(path + filename);

            // Saving Grid content of the control to a stream
            GridWeb1.SaveToExcelFile(fs);

            // Closing stream
            fs.Close();

            // Sents the file to browser.
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=" + filename);
            Response.WriteFile(path + filename);
            Response.End();
            // ExEnd:SaveExcelFileUsingStream
        }

      
    }
}