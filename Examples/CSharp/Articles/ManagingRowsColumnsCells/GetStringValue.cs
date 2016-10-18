using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingRowsColumnsCells
{
    public class GetStringValue
    {
        public static void Run()
        {
            // ExStart:GetStringValueWithOrWithoutFormatting
            // Create workbook
            Workbook workbook = new Workbook();

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access cell A1
            Cell cell = worksheet.Cells["A1"];

            // Put value inside the cell
            cell.PutValue(0.012345);

            // Format the cell that it should display 0.01 instead of 0.012345
            Style style = cell.GetStyle();
            style.Number = 2;
            cell.SetStyle(style);

            // Get string value as Cell Style
            string value = cell.GetStringValue(CellValueFormatStrategy.CellStyle);
            Console.WriteLine(value);

            // Get string value without any formatting
            value = cell.GetStringValue(CellValueFormatStrategy.None);
            Console.WriteLine(value);
            // ExEnd:GetStringValueWithOrWithoutFormatting
        }
    }
}
