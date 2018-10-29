using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;
using System.IO;

namespace GridDesktop.Examples.WorkingWithGrid
{
    public partial class SavingExcelFile : Form
    {
        public SavingExcelFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:SavingAFile
            // The path to the documents directory.
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Saving Grid contents to an Excel file
            gridDesktop1.ExportExcelFile(dataDir + "book1_out.xls");

            // Saving Grid contents to MS Excel 2007 Xlsx file format
            gridDesktop1.ExportExcelFile(Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType) + "book1_out.xlsx", FileFormatType.Excel2007Xlsx);
            // ExEnd:SavingAFile
            MessageBox.Show("Files have been created successfully.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:SavingUsingStream
            // The path to the documents directory.
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Opening an Excel file as a stream
            FileStream fs = File.Open(dataDir + "book1_out.xls", FileMode.Open, FileAccess.ReadWrite);

            // Saving Grid contents of the control to a stream
            gridDesktop1.ExportExcelFile(fs);

            // Closing stream
            fs.Close();
            // ExEnd:SavingUsingStream
            MessageBox.Show("File has been created successfully.");
        }
    }
}
