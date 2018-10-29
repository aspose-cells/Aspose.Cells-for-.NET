using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;

namespace GridDesktop.Examples.WorkingWithCells
{
    public partial class AddingCellFormulas : Form
    {
        public AddingCellFormulas()
        {
            InitializeComponent();
        }

        private void AddingCellFormulas_Load(object sender, EventArgs e)
        {
            // ExStart:1
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Adding numeric values to "B2" & "B3" cells
            sheet.Cells["B2"].SetCellValue(3);
            sheet.Cells["B3"].SetCellValue(4);

            // Adding a formula to "B4" cell multiplying the values of "B2" & "B3" cells
            sheet.Cells["B4"].SetCellValue("=B2 * B3");

            // Running all formulas in the Grid
            gridDesktop1.RunAllFormulas();
            // ExEnd:1
        }
    }
}
