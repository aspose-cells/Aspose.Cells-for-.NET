using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns
{
    public partial class RestrictContextMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRestrictContextMenu_Click(object sender, EventArgs e)
        {
            // ExStart:RestrictContextMenu
            // Restricting column related operations in context menu
            GridWeb1.EnableClientColumnOperations = false;

            // Restricting row related operations in context menu
            GridWeb1.EnableClientRowOperations = false;

            // Restricting freeze option of context menu
            GridWeb1.EnableClientFreeze = false;
            // ExEnd:RestrictContextMenu
        }
    }
}