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
    public partial class MergingAndUnMergingCells : Form
    {
        public MergingAndUnMergingCells()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:MergeCells
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Creating a CellRange object starting from "B4" to "C6"
            CellRange range = new CellRange("B4", "C6");

            // Merging a range of cells
            sheet.Merge(range);
            // ExEnd:MergeCells
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:UnMergeCells
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing the merged cell that is currently in focus
            GridCell cell = sheet.GetFocusedCell();

            // Unmerging a cell using its location
            sheet.Unmerge(cell.Location);
            // ExEnd:UnMergeCells
        }
    }
}
