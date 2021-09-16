using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;
using Aspose.Cells.GridDesktop.Data;

namespace GridDesktop.Examples.WorkingWithCells
{
    public partial class AccessingCells : Form
    {
        public AccessingCells()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:AccessByName
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing a cell using its name
            GridCell cell = sheet.Cells["A1"];
            // ExEnd:AccessByName
            MessageBox.Show(cell.Name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:AccessByIndices
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing a cell using its row and column indices
            GridCell cell = sheet.Cells[1, 1];
            // ExEnd:AccessByIndices
            MessageBox.Show(cell.Name);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:AccessFocusedCell
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing a cell that is currently in focus
            GridCell cell = sheet.GetFocusedCell();
            // ExEnd:AccessFocusedCell
            MessageBox.Show(cell.Name);
        }
    }
}
