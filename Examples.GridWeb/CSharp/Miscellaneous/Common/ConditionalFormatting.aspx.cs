using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common
{
    public partial class ConditionalFormatting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Get Data directory path
            string path = (this.Master as Aspose.Cells.GridWeb.Examples.CSharp.Site).GetDataDir();
            string fileName = path + "\\Miscellaneous\\conditionalformating.xlsx";

            // Import excel file
            gwcf.ImportExcelFile(fileName);
        }

    }
}