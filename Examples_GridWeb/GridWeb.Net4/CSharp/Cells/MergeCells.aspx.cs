using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Cells
{
    public partial class MergeCells : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void chkMergeCells_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMergeCells.Checked)
            {
                // ExStart:MergeCells
                // Accessing the reference of the worksheet that is currently active
                GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                // Merging cells starting from the cell with 3rd row and 3rd column. 
                // 2 rows and 2 columns will be merged from the starting cell
                sheet.Cells.Merge(2, 2, 2, 2);
                // ExEnd:MergeCells

                Label1.Text = "2 rows and 2 columns are merged starting from row 3 and column 3";
            }
            else
            {
                // ExStart:UnmergeCells
                // Accessing the reference of the worksheet that is currently active
                GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                // Unmerging cells starting from the cell with 3rd row and 3rd column. 
                // 2 rows and 2 columns will be unmerged from the starting cell
                sheet.Cells.UnMerge(2, 2, 2, 2);
                // ExEnd:UnmergeCells

                Label1.Text = "2 rows and 2 columns are unmerged starting from row 3 and column 3";
            }
        }
    }
}