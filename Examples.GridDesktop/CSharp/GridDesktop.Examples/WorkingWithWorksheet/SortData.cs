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
    public partial class SortData : Form
    {
        public SortData()
        {
            InitializeComponent();
        }

        // ExStart:CheckingCellRange
        // Creating global variable of CellRange
        CellRange range;

        private void gridDesktop1_SelectedCellRangeChanged(object sender, Aspose.Cells.GridDesktop.CellRangeEventArgs e)
        {
            // Checking if the range of cells is not empty
            if ((e.CellRange.EndColumn - e.CellRange.StartColumn > 0) ||
                                  (e.CellRange.EndRow - e.CellRange.StartRow > 0))
            {
                // Assigning the updated CellRange to global variable
                range = e.CellRange;
            }
        }
        // ExEnd:CheckingCellRange

        // Module to sort data in Ascending order
        void Ascending_Sort()
        {
            // ExStart:AscendingSort
            // Accessing a worksheet that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Creating SortRange object
            SortRange sr = new SortRange(sheet, range.StartRow,
                         range.StartColumn, range.EndRow - range.StartRow + 1,
                         range.EndColumn - range.StartColumn + 1,
                         SortOrientation.SortTopToBottom, true);

            // Sorting data in the specified column in ascending order
            sr.Sort(range.StartColumn, Aspose.Cells.GridDesktop.SortOrder.Ascending);

            // Redrawing cells of the Grid
            gridDesktop1.Invalidate();
            // ExEnd:AscendingSort
        }

        // Module to sort data in Descending order
        void Descending_Sort()
        {
            // ExStart:DescendingSort
            // Accessing a worksheet that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Creating SortRange object
            SortRange sr = new SortRange(sheet, range.StartRow, range.StartColumn,
                         range.EndRow - range.StartRow + 1,
                         range.EndColumn - range.StartColumn + 1,
                         SortOrientation.SortTopToBottom, true);

            // Sorting data in the specified column in descending order
            sr.Sort(range.StartColumn, Aspose.Cells.GridDesktop.SortOrder.Descending);

            // Redrawing cells of the Grid
            gridDesktop1.Invalidate();
            // ExEnd:DescendingSort
        }
        // ExEnd:1

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(range == null))
                Ascending_Sort();
            else
                MessageBox.Show("No Range is selected. Please select range of cells.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(range == null))
                Descending_Sort();
            else
                MessageBox.Show("No Range is selected. Please select range of cells.");
        }
    }
}
