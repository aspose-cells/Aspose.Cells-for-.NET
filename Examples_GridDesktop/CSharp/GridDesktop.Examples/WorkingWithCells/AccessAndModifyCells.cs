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
    public partial class AccessAndModifyCells : Form
    {
        public AccessAndModifyCells()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:UsingValue
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing the cell using its name
            GridCell cell = sheet.Cells["A1"];

            // Accessing & modifying the value of "A1" cell
            cell.Value = DateTime.Now;
            // ExEnd:UsingValue
            gridDesktop1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:UsingSetCellValue
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing the cell using its name
            GridCell cell = sheet.Cells["A1"];

            // Setting the value of "A1" cell
            cell.SetCellValue(DateTime.Now);
            // ExEnd:UsingSetCellValue
            gridDesktop1.Refresh();
        }
    }
}
