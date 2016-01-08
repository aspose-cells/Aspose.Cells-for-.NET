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

            // Style the cell with borders all around.
            Style style = workbook.CreateStyle();
            style.SetBorder(BorderType.BottomBorder, CellBorderType.Thin, Color.Black);
            style.SetBorder(BorderType.LeftBorder, CellBorderType.Thin, Color.Green);
            style.SetBorder(BorderType.RightBorder, CellBorderType.Thin, Color.Blue);
            style.SetBorder(BorderType.TopBorder, CellBorderType.MediumDashed, Color.Black);

            Cell cell = worksheet.Cells["A1"];
            cell.SetStyle(style);            

            workbook.Save("test.xlsx", SaveFormat.Xlsx); //Workbooks can be saved in many formats
        }
    }
}
