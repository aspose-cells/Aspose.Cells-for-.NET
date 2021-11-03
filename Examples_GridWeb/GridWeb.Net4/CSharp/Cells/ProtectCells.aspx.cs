using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Cells
{
    public partial class ProtectCells : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
        }

        protected void chkAllCells_CheckedChanged(object sender, EventArgs e)
        {
            chkSelectedCells.Checked = false;

            if (chkAllCells.Checked)
            {
                // ExStart:MakeAllCellsEditable
                // Accessing the reference of the worksheet that is currently active
                GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                // Setting all cells of the worksheet to Editable
                sheet.SetAllCellsEditable();
                // ExEnd:MakeAllCellsEditable

                Label1.Text = "All cells are editable now.";
            }
            else
            {
                // ExStart:MakeAllCellsReadOnly
                // Accessing the reference of the worksheet that is currently active
                GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                // Setting all cells of the worksheet to Readonly
                sheet.SetAllCellsReadonly();
                // ExEnd:MakeAllCellsReadOnly

                Label1.Text = "All cells are readonly now.";
            }
        }

        protected void chkSelectedCells_CheckedChanged(object sender, EventArgs e)
        {
            chkAllCells.Checked = false;

            if (chkSelectedCells.Checked)
            {
                // ExStart:MakeSelectedCellsEditable
                // Accessing the reference of the worksheet that is currently active
                GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                // Setting all cells of the worksheet to Readonly first
                sheet.SetAllCellsReadonly();

                // Finally, Setting selected cells of the worksheet to Editable
                sheet.SetEditableRange(3, 2, 4, 1);
                // ExEnd:MakeSelectedCellsEditable

                Label1.Text = "4 rows and 1 column are editable starting from row 4 and column 3";
            }
            else
            {
                // ExStart:MakeSelectedCellsReadOnly
                // Accessing the reference of the worksheet that is currently active
                GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                // Setting all cells of the worksheet to Editable first
                sheet.SetAllCellsEditable();

                // Finally, Setting selected cells of the worksheet to Readonly
                sheet.SetReadonlyRange(3, 2, 4, 1);
                // ExEnd:MakeSelectedCellsReadOnly

                Label1.Text = "4 rows and 1 column are readonly starting from row 4 and column 3";
            }
        }
    }
}