using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Aspose_Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate a new Workbook.
            Workbook objworkbook = new Workbook();
            // Get the First sheet.
            Worksheet objworksheet = objworkbook.Worksheets[0];
            // Get Cells.
            Cells objcells = objworksheet.Cells;// Get a particular Cell.
            Cell objcell = objcells["B2"];// Put some text value.
            objcell.PutValue("Aspose Heading");

            // Get associated style object of the cell.
            Style objstyle = objcell.GetStyle();

            // Specify the angle of rotation of the text.
            objstyle.RotationAngle = 45;

            // Set the custom fill color of the cells.
            objstyle.ForegroundColor = Color.FromArgb(0, 51, 105);

            // Set the background pattern for fillment color.
            objstyle.Pattern = BackgroundType.Solid;

            // Set the font color of cell text
            objstyle.Font.Color = Color.White;

            // Assign the updated style object back to the cell
            objcell.SetStyle(objstyle);

            // Save the work book
            objworkbook.Save("RotateText_test.xlsx");
        }
    }
}
