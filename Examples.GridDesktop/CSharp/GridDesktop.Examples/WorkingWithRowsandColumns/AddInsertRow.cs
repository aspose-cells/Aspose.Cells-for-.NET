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
    public partial class AddInsertRow : Form
    {
        public AddInsertRow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:AddRow
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Adding row to the worksheet
            sheet.AddRow();
            // ExEnd:AddRow
            MessageBox.Show("Row added.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:InsertRow
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Inserting row to the worksheet to the first position.
            gridDesktop1.Worksheets[0].InsertRow(0);
            // ExEnd:InsertRow
            MessageBox.Show("Row Inserted.");
        }
    }
}
