using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
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

            // Adding some value to cell
            Cell cell = worksheet.Cells["A1"];
            cell.PutValue("This is Aspose test of fonts!");

            // Setting the font name to "Times New Roman"
            Style style = cell.GetStyle();
            Font font = style.Font;

            font.Name = "Courier New";
            font.Size = 24;
            font.IsBold = true;
            font.Underline = FontUnderlineType.Single;
            font.Color = Color.Blue;
            font.IsStrikeout = true;

            cell.SetStyle(style);

            workbook.Save("test.xlsx", SaveFormat.Xlsx); //Workbooks can be saved in many formats
        }
    }
}
