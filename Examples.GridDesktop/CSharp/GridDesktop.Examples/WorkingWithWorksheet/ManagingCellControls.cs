using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;

namespace GridDesktop.Examples.WorkingWithWorksheet
{
    public partial class ManagingCellControls : Form
    {
        public ManagingCellControls()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing the location of the cell that is currently in focus
            CellLocation cl = sheet.GetFocusedCellLocation();

            // Adding checkbox to the Controls collection of the Worksheet
            sheet.Controls.AddCheckBox(cl.Row, cl.Column, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:RemoveCheckbox
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Getting the location of the cell that is currently in focus
            CellLocation cl = sheet.GetFocusedCellLocation();

            // Removing the cell control by specifying the location of cell containing it
            sheet.Controls.Remove(cl.Row, cl.Column);
            // ExEnd:RemoveCheckbox
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:AccessCheckbox
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Getting the location of the cell that is currently in focus
            CellLocation cl = sheet.GetFocusedCellLocation();

            // Accessing cell control and typecasting it to CheckBox
            Aspose.Cells.GridDesktop.CheckBox cb = (Aspose.Cells.GridDesktop.CheckBox)sheet.Controls[cl.Row, cl.Column];

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
