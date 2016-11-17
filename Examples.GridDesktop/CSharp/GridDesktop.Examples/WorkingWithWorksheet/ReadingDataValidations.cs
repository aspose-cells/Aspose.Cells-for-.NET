using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GridDesktop.Examples.WorkingWithWorksheet
{
    public partial class ReadingDataValidations : Form
    {
        public ReadingDataValidations()
        {
            InitializeComponent();
        }

        private void ReadingDataValidations_Load(object sender, EventArgs e)
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Import sample excel file in GridDesktop
            gridDesktop1.ImportExcelFile(dataDir + "ValidationTesting.xlsx");
            // ExEnd:1
        }
    }
}
