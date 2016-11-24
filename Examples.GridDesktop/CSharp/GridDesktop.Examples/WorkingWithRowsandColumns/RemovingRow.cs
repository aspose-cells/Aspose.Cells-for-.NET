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
    public partial class RemovingRow : Form
    {
        public RemovingRow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:1
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Removing the first row of the worksheet
            sheet.RemoveRow(0);
            // ExEnd:1
            MessageBox.Show("Row has been removed.");
        }
    }
}
