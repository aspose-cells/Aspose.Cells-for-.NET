using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Articles
{
    public partial class ReadCellsClientSide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load data on fist visit
            if (!Page.IsPostBack && !GridWeb1.IsPostBack)
            {               
                InitData();
            }
        }

        private void InitData()
        {
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

            string fileName = path +  "\\Articles\\Data.xlsx";

            // Clears datasheets first.
            GridWeb1.WorkSheets.Clear();

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
        }
    }
}