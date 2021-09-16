using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;
using Aspose.Cells.GridDesktop.Data;

namespace GridDesktop.Examples.WorkingWithCells
{
    public partial class FormattingCellRange : Form
    {
        public FormattingCellRange()
        {
            InitializeComponent();
        }

        private void FormattingCellRange_Load(object sender, EventArgs e)
        {
            // ExStart:1
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Setting sample values
            GridCell cell = sheet.Cells["b7"];
            cell.SetCellValue("1");
            cell = sheet.Cells["c7"];
            cell.SetCellValue("2");
            cell = sheet.Cells["d7"];
            cell.SetCellValue("3");
            cell = sheet.Cells["e7"];
            cell.SetCellValue("4");

            // Creating a CellRange object starting from "B7" to "E7"
            CellRange range = new CellRange(6, 1, 6, 4);

            // Accessing and setting Style attributes
            Style style = new Style(this.gridDesktop1);
            style.Color = Color.Yellow;

            // Applying Style object on the range of cells
            sheet.SetStyle(range, style);

            // Creating a customized Font object
            Font font = new Font("Courier New", 12f);

            // Setting the font of range of cells to the customized Font object
            sheet.SetFont(range, font);

            // Setting the font color of range of cells to Red
            sheet.SetFontColor(range, Color.Red);
            // ExEnd:1
            gridDesktop1.Refresh();
        }
    }
}
