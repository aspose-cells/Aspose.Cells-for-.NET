using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Worksheets
{
    public partial class AddRemoveHyperlinkFromClientSide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If first visit this page clear GridWeb1 and load data 
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                GridWeb1.ShowAddButton = true;
                GridWeb1.WorkSheets.Clear();
                GridWeb1.WorkSheets.Add();
                //LoadData();
            }
        }

        private void LoadData()
        {
            // Gets the web application's path.
            string path = (this.Master as Site).GetDataDir();

            string fileName = path + "\\GridWebBasics\\SampleData.xls";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
        }
    }
}