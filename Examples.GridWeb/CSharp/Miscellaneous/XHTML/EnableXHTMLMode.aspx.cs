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

namespace Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.XHTML
{
    public partial class EnableXHTMLMode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            // Create path to xls file
            string path = (this.Master as Site).GetDataDir();

            // Set filename
            string fileName = path + "\\Miscellaneous\\EmployeeSales.xls";

            // Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName);
        }

    }

}
