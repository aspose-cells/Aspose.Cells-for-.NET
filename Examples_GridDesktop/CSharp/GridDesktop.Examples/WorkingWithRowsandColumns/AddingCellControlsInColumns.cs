using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;

namespace GridDesktop.Examples.WorkingWithRowsandColumns
{
    public partial class AddingCellControlsInColumns : Form
    {
        public AddingCellControlsInColumns()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:AddingButton
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Adding button to a specific column of the Worksheet
            sheet.Columns[2].AddButton(80, 20, "Hello");
            // ExEnd:AddingButton
            gridDesktop1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:AddingCheckbox
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Adding checkbox to a specific column of the Worksheet
            sheet.Columns[2].AddCheckBox();
            // ExEnd:AddingCheckbox
            gridDesktop1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:AddingCombobox
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Creating an array of items or values that will be added to combobox
            string[] items = new string[3];
            items[0] = "Aspose";
            items[1] = "Aspose.Grid";
            items[2] = "Aspose.Grid.Desktop";

            // Adding combobox (containing items) to a specific column of the Worksheet
            sheet.Columns[2].AddComboBox(items);
            // ExEnd:AddingCombobox
            gridDesktop1.Refresh();
        }
    }
}
