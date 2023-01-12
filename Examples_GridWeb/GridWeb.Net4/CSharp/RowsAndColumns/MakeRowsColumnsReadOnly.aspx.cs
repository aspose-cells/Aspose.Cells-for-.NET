using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns
{
    public partial class MakeRowsColumnsReadOnly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMakeCellReadOnly_Click(object sender, EventArgs e)
        {
            // ExStart:MakeCellReadOnly
            // Accessing the first worksheet that is currently active
            GridWorksheet sheet = GridWeb1.ActiveSheet;

            // Set the 1st cell (A1) read only
            sheet.SetIsReadonly(0,0, true);
            // ExEnd:MakeCellReadOnly
        }
    }
}