using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GridDesktop.Examples.WorkingWithCells
{
    public partial class UsingNamedRanges : Form
    {
        public UsingNamedRanges()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:1
            // Clear the Worsheets first
            _grid.Clear();

            // The path to the documents directory.
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Specifying the path of Excel file using ImportExcelFile method of the control
            _grid.ImportExcelFile(dataDir + "book1.xlsx");

            // Apply a formula to a cell that refers to a named range "Rang1"
            _grid.Worksheets[0].Cells["G6"].SetCellValue("=SUM(Range1)");

            // Add a new named range "MyRange" with based area A2:B5
            int index = _grid.Names.Add("MyRange", "Sheet1!A2:B5");

            // Apply a formula to G7 cell
            _grid.Worksheets[0].Cells["G7"].SetCellValue("=SUM(MyRange)");

            // Calculate the results of the formulas
            _grid.RunAllFormulas();

            // Save the Excel file
            _grid.ExportExcelFile(dataDir + @"ouputBook1_out.xlsx");
            // ExEnd:1
            MessageBox.Show("Sheet has been exported to output directory.");
        }
    }
}
