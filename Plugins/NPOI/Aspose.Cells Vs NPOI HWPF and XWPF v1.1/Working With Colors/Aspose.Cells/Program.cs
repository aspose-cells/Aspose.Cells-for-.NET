using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Aspose.Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            Workbook workbook = new Workbook(); // Creating a Workbook object
            workbook.Worksheets.Add();
            Worksheet worksheet = workbook.Worksheets[0];

            //Accessing cell from the worksheet
            Cell cell = worksheet.Cells["B2"];
            Style style = cell.GetStyle();            

            //Setting the foreground color to yellow            
            style.BackgroundColor = Color.Yellow;

            //Setting the background pattern to vertical stripe
            style.Pattern = BackgroundType.VerticalStripe;            

            //Saving the modified style to the "B2" cell.
            cell.SetStyle(style);

            // === Setting Foreground ===

            //Adding custom color to the palette at 55th index
            Color color = Color.FromArgb(212, 213, 0);
            workbook.ChangePalette(color, 55);

            //Accessing cell from the worksheet
            cell = worksheet.Cells["B3"];

            //Adding some value to the cell
            cell.PutValue("Hello Aspose!");

            workbook.Save("test.xlsx", SaveFormat.Xlsx); //Workbooks can be saved in many formats
        }
    }
}
