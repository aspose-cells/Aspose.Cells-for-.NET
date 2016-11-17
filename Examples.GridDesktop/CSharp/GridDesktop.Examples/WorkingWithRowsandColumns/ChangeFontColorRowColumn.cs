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
    public partial class ChangeFontColorRowColumn : Form
    {
        public ChangeFontColorRowColumn()
        {
            InitializeComponent();
        }

        private void ChangeFontColorRowColumn_Load(object sender, EventArgs e)
        {
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Adding sample values to worksheet cells
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
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing the first column of the worksheet
            GridColumn column = sheet.Columns[0];

            // Creating a customized Font object
            Font font = new Font("Arial", 10, FontStyle.Bold);

            // Setting the font of the column to the customized Font object
            //column.SetFont(font);

            // Setting the font color of the column to Blue
            //column.SetFontColor(Color.Blue);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing the first row of the worksheet
            GridRow row = sheet.Rows[0];

            // Creating a customized Font object
            Font font = new Font("Arial", 10, FontStyle.Underline);

            // Setting the font of the column to the customized Font object
            //row.SetFont(font);

            // Setting the font color of the column to Green
            //row.SetFontColor(Color.Green);
        }
    }
}
