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
    public partial class AddInsertWorksheet : Form
    {
        public AddInsertWorksheet()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:AddingWorksheet
            // Adding a worksheet to the Grid
            int i = gridDesktop1.Worksheets.Add();
            Worksheet sheet = gridDesktop1.Worksheets[i];
            // ExEnd:AddingWorksheet
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ExStart:AddingWorksheetWithName
            // Adding a worksheet to the Grid with a specific name
            Worksheet sheet1 = gridDesktop1.Worksheets.Add("AddWorksheetWithName");
            // ExEnd:AddingWorksheetWithName
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:InsertingWorksheet
            // Inserting a worksheet to Grid at first position of the worksheets collection
            gridDesktop1.Worksheets.Insert(0);
            // ExEnd:InsertingWorksheet
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:InsertingWorksheetWithName
            // Inserting a worksheet to Grid at first position with a specific sheet name
            Worksheet sheet1 = gridDesktop1.Worksheets.Insert(0, "InsertWorksheetWithName");
            // ExEnd:InsertingWorksheetWithName
        }
    }
}
