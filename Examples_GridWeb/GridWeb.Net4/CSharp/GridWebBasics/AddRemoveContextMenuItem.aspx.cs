using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics
{
    public partial class AddRemoveContextMenuItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddContextMenuItem_Click(object sender, EventArgs e)
        {
            // ExStart:AddContextMenuItem
            // Init context menu item command button
            CustomCommandButton cmd = new CustomCommandButton();
            cmd.CommandType = CustomCommandButtonType.ContextMenuItem;
            cmd.Text = "MyNewContextMenuItem";
            cmd.Command = "MyNewContextMenuItemCommand";

            // Add context menu item command button to GridWeb
            GridWeb1.CustomCommandButtons.Add(cmd);
            // ExEnd:AddContextMenuItem
        }

        protected void btnRemoveContextMenuItem_Click(object sender, EventArgs e)
        {
            // ExStart:RemoveContextMenuItem
            if (GridWeb1.CustomCommandButtons.Count > 1)
            {
                // Remove the 2nd custom command button or context menu item using remove at method
                GridWeb1.CustomCommandButtons.RemoveAt(1);
            }

            if (GridWeb1.CustomCommandButtons.Count >= 1)
            {
                // Access the 1st custom command button or context menu item and remove it
                CustomCommandButton custbtn = GridWeb1.CustomCommandButtons[0];
                GridWeb1.CustomCommandButtons.Remove(custbtn);
            }           
            // ExEnd:RemoveContextMenuItem
        }

        // Event Handler for custom command event of GridWeb
        protected void GridWeb1_CustomCommand(object sender, string command)
        {
            if (command.Equals("MyContextMenuItemCommand") | command.Equals("MyNewContextMenuItemCommand"))
            {
                // Accessing the active sheet
                GridWorksheet sheet = GridWeb1.WorkSheets[GridWeb1.ActiveSheetIndex];

                // Putting value to "A1" cell
                sheet.Cells["A1"].PutValue("My Custom Context Menu Item command " + command + " is Clicked.");

                // Set first column width to make the text visible
                sheet.Cells.SetColumnWidth(0, 40);
            }
        }
    }
}