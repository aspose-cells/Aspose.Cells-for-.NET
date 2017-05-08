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
using Aspose.Cells.GridWeb;
using Aspose.Cells.GridWeb.DemosCS;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class HandleDoubleClickEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !GridWeb1.IsPostBack)
            {
                // Sets sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0;
            }
        }

        // ExStart:CellDoubleClickEvent
        // Event Handler for CellDoubleClick event
        protected void GridWeb1_CellDoubleClick(object sender, Aspose.Cells.GridWeb.CellEventArgs e)
        {
            // Displaying the name of the cell (that is double clicked) in GridWeb's Message Box
            string msg = "You just clicked <";
            msg += "Row: " + (e.Cell.Row + 1) + " Column: " + (e.Cell.Column + 1) + " Cell Name: " + e.Cell.Name + ">";
            GridWeb1.Message = msg;
        }
        // ExEnd:CellDoubleClickEvent

        // ExStart:ColumnDoubleClickEvent
        // Event Handler for ColumnDoubleClick event
        protected void GridWeb1_ColumnDoubleClick(object sender, Aspose.Cells.GridWeb.RowColumnEventArgs e)
        {
            // Displaying the number of the column (whose header is double clicked) in GridWeb's Message Box
            string msg = "You just clicked <";
            msg += "Column header: " + (e.Num + 1) + ">";
            GridWeb1.Message = msg;
        }
        // ExEnd:ColumnDoubleClickEvent

        // ExStart:RowDoubleClickEvent
        // Event Handler for RowDoubleClick event
        protected void GridWeb1_RowDoubleClick(object sender, Aspose.Cells.GridWeb.RowColumnEventArgs e)
        {
            // Displaying the number of the row (whose header is double clicked) in GridWeb's Message Box
            string msg = "You just clicked <";
            msg += "Row header: " + (e.Num + 1) + ">";
            GridWeb1.Message = msg;
        }
        // ExEnd:RowDoubleClickEvent

        protected void GridWeb1_SaveCommand(object sender, System.EventArgs e)
        {
            GridWeb1.Message = "You just clicked \"Save\" icon!";
        }

        protected void GridWeb1_SheetTabClick(object sender, System.EventArgs e)
        {
            GridWeb1.Message = "You just clicked \"Change worksheet\" icon!";
        }

        protected void GridWeb1_SubmitCommand(object sender, System.EventArgs e)
        {
            GridWeb1.Message = "You just clicked \"Submit\" icon!";
        }

        protected void GridWeb1_UndoCommand(object sender, System.EventArgs e)
        {
            GridWeb1.Message = "You just clicked \"Cancel\" icon!";
        }

        protected void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                // ExStart:EnableDoubleClickEvents
                // Enabling Double Click events
                GridWeb1.EnableDoubleClickEvent = true;
                // ExEnd:EnableDoubleClickEvents
            }
            else
            {
                GridWeb1.EnableDoubleClickEvent = false;
            }
            
        }

    }
}

