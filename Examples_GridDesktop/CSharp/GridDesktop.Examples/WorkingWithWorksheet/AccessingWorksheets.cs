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
    public partial class AccessingWorksheets : Form
    {
        public AccessingWorksheets()
        {
            InitializeComponent();
        }

        private void AccessingWorksheets_Load(object sender, EventArgs e)
        {
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            gridDesktop1.ImportExcelFile(dataDir + "book1.xlsx");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:AccessingWithIndex
            // Accesing a worksheet using its index
            Worksheet sheet = gridDesktop1.Worksheets[0];
            // ExEnd:AccessingWithIndex
            MessageBox.Show("You accessed " + sheet.Name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:AccessingWithName
            // Accesing a worksheet using its name
            Worksheet sheet = gridDesktop1.Worksheets["Sheet2"];
            // ExEnd:AccessingWithName
            MessageBox.Show("You accessed " + sheet.Name);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:AccessingWithActiveWorksheet
            // Accesing an active worksheet using its index
            Worksheet sheet = gridDesktop1.Worksheets[gridDesktop1.ActiveSheetIndex];
            // ExEnd:AccessingWithActiveWorksheet
            MessageBox.Show("You accessed " + sheet.Name);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ExStart:AccessingWithGetActiveWorksheet
            // Accesing an active worksheet directly
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();
            // ExEnd:AccessingWithGetActiveWorksheet
            MessageBox.Show("You accessed " + sheet.Name);
        }
    }
}
