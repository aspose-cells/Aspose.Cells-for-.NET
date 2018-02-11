using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class CallClientsideScriptforGridWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If first visit this page clear GridWeb1 
            if (!IsPostBack && !gridweb.IsPostBack)
            {
                LoadData();
                //GridWeb1.WorkSheets.Clear();
                //GridWeb1.WorkSheets.Add();
            }
        }
        private void LoadData()
        {
            // License li = new  License();
            // li.SetLicense(@"D:\grid_project\ZZZZZZ_release_version\Aspose.Total.20141214.lic");

            // ExStart:LoadExcelFile
            // Gets the web application's path.
            //string path = (this.Master as Site).GetDataDir();

            //string fileName = path + "\\GridWebBasics\\SampleData.xls";

            // Imports from an excel file.
            //gridweb.ImportExcelFile(@"c:\ad\MultipageExcel.xlsx");
            // ExEnd:LoadExcelFile
        }
    }
}