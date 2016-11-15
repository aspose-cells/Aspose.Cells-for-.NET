using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GridDesktop.Examples.WorkingWithGrid
{
    public partial class OpeningExcelFile : Form
    {
        public OpeningExcelFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:OpeningExcelFile
            // The path to the documents directory.
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Specifying the path of Excel file using ImportExcelFile method of the control
            gridDesktop1.ImportExcelFile(dataDir + "Sample.xlsx");
            // ExEnd:OpeningExcelFile
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:OpeningCSVFile
            // The path to the documents directory.
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Specifying the path of Excel file using ImportExcelFile method of the control
            gridDesktop1.ImportExcelFile(dataDir + "SampleCSV1.csv");
            // ExEnd:OpeningCSVFile
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:OpeningFromStream
            // The path to the documents directory.
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Opening an Excel file as a stream
            FileStream fs = File.OpenRead(dataDir + "Sample.xlsx");

            // Loading the Excel file contents into the control from a stream
            gridDesktop1.ImportExcelFile(fs);

            // Closing stream
            fs.Close();
            // ExEnd:OpeningFromStream
        }
    }
}
