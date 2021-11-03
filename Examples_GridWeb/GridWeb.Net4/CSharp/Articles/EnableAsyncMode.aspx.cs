using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Articles
{
    public partial class EnableAsyncMode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (! IsPostBack && !GridWeb1.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

            // Clear the sheets
            GridWeb1.WorkSheets.Clear();

            // Load the file
            GridWeb1.ImportExcelFile(path + "\\Articles\\Data.xlsx");
        }

        protected void btnEnableAsync_Click(object sender, EventArgs e)
        {
            // ExStart:EnableAsync
            GridWeb1.EnableAsync = true;
            // ExEnd:EnableAsync
        }
    }
}