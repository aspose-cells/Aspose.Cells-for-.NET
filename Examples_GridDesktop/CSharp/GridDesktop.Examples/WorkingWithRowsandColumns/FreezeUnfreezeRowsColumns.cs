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

namespace GridDesktop.Examples.WorkingWithRowsandColumns
{
    public partial class FreezeUnfreezeRowsColumns : Form
    {
        public FreezeUnfreezeRowsColumns()
        {
            InitializeComponent();
        }

        private void FreezeUnfreezeRowsColumns_Load(object sender, EventArgs e)
        {
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Adding sample values to worksheet cells
            GridCell cell = sheet.Cells["a1"];
            cell.SetCellValue("1"); 
            cell = sheet.Cells["a2"];
            cell.SetCellValue("2");
            cell = sheet.Cells["a3"];
            cell.SetCellValue("3");
            cell = sheet.Cells["a4"];
            cell.SetCellValue("4");
            cell = sheet.Cells["a5"];
            cell.SetCellValue("5");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:FreezeColumns
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Setting the number of frozen columns to 2
            sheet.FrozenCols = 2;
            // ExEnd:FreezeColumns
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:UnFreezeColumns
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Setting the number of frozen columns to 0 for unfreezing columns
            sheet.FrozenCols = 0;
            // ExEnd:UnFreezeColumns
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:FreezeRows
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Setting the number of frozen rows to 2
            sheet.FrozenRows = 2;
            // ExEnd:FreezeRows
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ExStart:UnFreezeRows
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Setting the number of frozen rows to 0 for unfreezing rows
            sheet.FrozenRows = 0;
            // ExEnd:UnFreezeRows
        }
    }
}
