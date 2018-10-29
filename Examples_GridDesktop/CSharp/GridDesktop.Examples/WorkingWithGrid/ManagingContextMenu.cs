using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;

namespace GridDesktop.Examples.WorkingWithGrid
{
    public partial class ManagingContextMenu : Form
    {
        public ManagingContextMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:HideContextMenuItem
            // Get the ContextMenuManager
            ContextMenuManager cmm = this.grdDataEntry.ContextMenuManager;

            // Hide the Copy option in the context menu
            cmm.MenuItemAvailable_Copy = false;

            // Hide the InsertRow option in the context menu
            cmm.MenuItemAvailable_InsertRow = false;

            // Hide the Format Cell dialog box
            cmm.MenuItemAvailable_FormatCells = false;
            // ExEnd:HideContextMenuItem
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:AddContextMenuItem
            // Get the active worksheet
            Worksheet sheet = grdDataEntry.GetActiveWorksheet();

            // Set the total columns diaplyed in the grid
            sheet.ColumnsCount = 15;

            // Set the total rows displayed in the grid
            sheet.RowsCount = 15;

            // Define a new menu item and specify its event handler
            MenuItem mi = new MenuItem("newMenuItem", new System.EventHandler(miClicked));

            // Set the label
            mi.Text = "New Item";

            // Add the menu item to the GridDesktop's context menu
            grdDataEntry.ContextMenu.MenuItems.Add(mi);
            // ExEnd:AddContextMenuItem
        }

        // ExStart:EventHandler
        // Event Handler for the new menu item
        private void miClicked(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            MessageBox.Show("miCliked: " + mi.Text);
        }
        // ExEnd:EventHandler
    }
}
