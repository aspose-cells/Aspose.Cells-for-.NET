using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common
{
    public partial class RefreshCharts : System.Web.UI.Page
    {
        private void Page_Load(object Sender, EventArgs e)
        {
            if (!IsPostBack && !GridWebchart.IsPostBack)
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
            GridWebchart.ImportExcelFile(fileName);
        }
        protected void submitaction(object sender, EventArgs e)
        {
            // Refresh Charts
            GridWebchart.RefreshChartShape();
        }
    }

}
