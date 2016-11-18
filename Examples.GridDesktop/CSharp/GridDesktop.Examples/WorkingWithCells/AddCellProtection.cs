using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;

namespace GridDesktop.Examples.WorkingWithCells
{
    public partial class AddCellProtection : Form
    {
        public AddCellProtection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:1
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Make sure sheet has been protected
            sheet.Protected = true;

            // Choose a cell range
            CellRange range = sheet.CreateRange("A1", "B1");

            // Set protected range area on Worksheet
            sheet.SetProtected(range, true);
            // ExEnd:1
            MessageBox.Show("Cells has been protected now.");
        }
    }
}
