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
    public partial class ApplyingStyleOnRowColumn : Form
    {
        public ApplyingStyleOnRowColumn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:AddingColumnStyle
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing the first column of the worksheet
            Aspose.Cells.GridDesktop.Data.GridColumn column = sheet.Columns[0];

            // Adding sample value to sheet cell
            GridCell cell = sheet.Cells["a1"];
            cell.SetCellValue("Aspose");

            // Getting the Style object for the column
            Style style = column.GetStyle();

            // Setting Style properties i.e. border, alignment color etc.
            style.SetBorderLine(BorderType.Right, BorderLineType.Thick);
            style.SetBorderColor(BorderType.Right, Color.Blue);
            style.HAlignment = HorizontalAlignmentType.Centred;

            // Setting the style of the column with the customized Style object
            column.SetStyle(style);
            // ExEnd:AddingColumnStyle
            gridDesktop1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:AddingRowStyle
            // Accessing the worksheet of the Grid that is currently active
            Worksheet sheet = gridDesktop1.GetActiveWorksheet();

            // Accessing the first row of the worksheet
            Aspose.Cells.GridDesktop.Data.GridRow row = sheet.Rows[0];

            // Getting the Style object for the row
            //Style style = row.GetStyle();

            // Setting Style properties i.e. border, color, alignment, background color etc.
            //style.SetBorderLine(BorderType.Right, BorderLineType.Thick);
            //style.SetBorderColor(BorderType.Right, Color.Blue);
            //style.HAlignment = HorizontalAlignmentType.Centred;
            //style.Color = Color.Yellow;

            // Setting the style of the row with the customized Style object
            //row.SetStyle(style);
            // ExEnd:AddingRowStyle
        }
    }
}
