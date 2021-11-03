using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common
{
    public partial class DisplayCharts : System.Web.UI.Page
    {

        private void Page_Load(object Sender, EventArgs e)
        {
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                LoadData();


            }
        }
        private void LoadData()
        {
            // Gets the web application's path.
            string path = (this.Master as Aspose.Cells.GridWeb.Examples.CSharp.Site).GetDataDir();
            string fileName = path + "\\Miscellaneous\\Charts.xls";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
        }

    }
}
   
 