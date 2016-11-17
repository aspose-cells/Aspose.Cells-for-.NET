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
    public partial class ManagingControlsInColumns : Form
    {
        public ManagingControlsInColumns()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Adding checkbox to a specific column of the Worksheet
            sheet.Columns[2].AddCheckBox();
            gridDesktop1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:RemoveCheckbox
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Removing cell control from the column
            sheet.Columns[2].RemoveCellControl();
            // ExEnd:RemoveCheckbox
            gridDesktop1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:AccessCheckbox
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing cell control in the column and typecasting it to CheckBox
            Aspose.Cells.GridDesktop.CheckBox cb = (Aspose.Cells.GridDesktop.CheckBox)sheet.Columns[2].CellControl;

            if (cb != null)
            {
                // Modifying the Checked property of CheckBox
                cb.Checked = true;
            }
            else
            {
                MessageBox.Show("Please add control before accessing it.");
            }
            // ExEnd:AccessCheckbox
        }
    }
}
