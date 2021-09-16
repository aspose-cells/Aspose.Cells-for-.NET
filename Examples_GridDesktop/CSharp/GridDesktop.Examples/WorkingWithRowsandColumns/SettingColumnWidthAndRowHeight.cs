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

namespace GridDesktop.Examples.WorkingWithRowsandColumns
{
    public partial class SettingColumnWidthAndRowHeight : Form
    {
        public SettingColumnWidthAndRowHeight()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:SetColumnWidth
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Adding sample value to sheet cell
            GridCell cell = sheet.Cells["a1"];
            cell.SetCellValue("Welcome to Aspose!");

            // Accessing the first column of the worksheet
            Aspose.Cells.GridDesktop.Data.GridColumn column = sheet.Columns[0];

            // Setting the width of the column
            column.Width = 150;
            // ExEnd:SetColumnWidth
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:SetRowHeight
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Adding sample value to sheet cells
            GridCell cell = sheet.Cells["b2"];
            cell.SetCellValue("1");
            cell = sheet.Cells["c2"];
            cell.SetCellValue("2");
            cell = sheet.Cells["d2"];
            cell.SetCellValue("3");
            cell = sheet.Cells["e2"];
            cell.SetCellValue("4");

            // Accessing the first row of the worksheet
            Aspose.Cells.GridDesktop.Data.GridRow row = sheet.Rows[1];

            // Setting the height of the row
            row.Height = 100;
            // ExEnd:SetRowHeight
        }
    }
}
