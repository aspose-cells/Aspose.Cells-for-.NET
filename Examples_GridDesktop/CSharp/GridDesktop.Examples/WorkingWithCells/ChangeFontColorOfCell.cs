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
    public partial class ChangeFontColorOfCell : Form
    {
        public ChangeFontColorOfCell()
        {
            InitializeComponent();
        }

        private void ChangeFontColorOfCell_Load(object sender, EventArgs e)
        {
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Setting sample values
            GridCell cell = sheet.Cells["a1"];
            cell.SetCellValue("1");
            cell = sheet.Cells["a2"];
            cell.SetCellValue("2");
            cell = sheet.Cells["a3"];
            cell.SetCellValue("3");
            cell = sheet.Cells["a4"];
            cell.SetCellValue("4");
            cell = sheet.Cells["a5"];
            cell.SetCellValue("5");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:1
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing a cell using its name
            GridCell cell = sheet.Cells["A1"];

            // Creating a customized Font object
            Font font = new Font("Arial", 10, FontStyle.Bold);

            // Setting the font of the cell to the customized Font object
            cell.SetFont(font);

            // Setting the font color of the cell to Blue
            cell.SetFontColor(Color.Blue);
            // ExEnd:1
            gridDesktop1.Refresh();
        }
    }
}
