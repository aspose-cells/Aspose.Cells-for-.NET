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
    public partial class AddInsertColumn : Form
    {
        public AddInsertColumn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:AddColumn
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Adding column to the worksheet
            sheet.AddColumn();
            // ExEnd:AddColumn
            MessageBox.Show("Column added.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:InsertColumn
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Inserting column to the worksheet to the first position.
            gridDesktop1.Worksheets[0].InsertColumn(0);
            // ExEnd:InsertColumn
            MessageBox.Show("Column Inserted.");
        }
    }
}
