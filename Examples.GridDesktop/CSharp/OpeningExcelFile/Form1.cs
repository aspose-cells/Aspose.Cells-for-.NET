using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OpeningExcelFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:OpeningExcelFile
            // Specifying the path of Excel file using ImportExcelFile method of the control
            gridDesktop1.ImportExcelFile(Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType) + "Sample.xlsx");
            // ExEnd:OpeningExcelFile
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:OpeningCSVFile
            // Specifying the path of Excel file using ImportExcelFile method of the control
            gridDesktop1.ImportExcelFile(Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType) + "SampleCSV1.csv");
            // ExEnd:OpeningCSVFile
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:OpeningFromStream
            // Opening an Excel file as a stream
            FileStream fs = File.OpenRead(Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType) + "Sample.xlsx");

            // Loading the Excel file contents into the control from a stream
            gridDesktop1.ImportExcelFile(fs);

            // Closing stream
            fs.Close();
            // ExEnd:OpeningFromStream
        }
    }
}
