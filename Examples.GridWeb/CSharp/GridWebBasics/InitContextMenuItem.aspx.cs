using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class InitContextMenuItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // ExStart:HandleContextMenuItemCommand
        // Event Handler for custom command event of GridWeb
        protected void GridWeb1_CustomCommand(object sender, string command)
        {
            if (command.Equals("MyContextMenuItemCommand"))
            {
                // Accessing the active sheet
                GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                // Putting value to "A1" cell
                sheet.Cells["A1"].PutValue("My Custom Context Menu Item is Clicked.");

                // Set first column width to make the text visible
                sheet.Cells.SetColumnWidth(0, 40);
            }
        }
        // ExEnd:HandleContextMenuItemCommand
    }
}