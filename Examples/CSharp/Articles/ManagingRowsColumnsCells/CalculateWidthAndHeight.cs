using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingRowsColumnsCells
{
    public class CalculateWidthAndHeight
    {
        public static void Run()
        {
            // ExStart:CalculateWidthAndHeightOfCellValueInUnitOfPixel
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object
            Workbook workbook = new Workbook();

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access cell B2 and add some value inside it
            Cell cell = worksheet.Cells["B2"];
            cell.PutValue("Welcome to Aspose!");

            // Enlarge its font to size 16
            Style style = cell.GetStyle();
            style.Font.Size = 16;
            cell.SetStyle(style);

            // Calculate the width and height of the cell value in unit of pixels
            int widthOfValue = cell.GetWidthOfValue();
            int heightOfValue = cell.GetHeightOfValue();

            // Print both values
            Console.WriteLine("Width of Cell Value: " + widthOfValue);
            Console.WriteLine("Height of Cell Value: " + heightOfValue);

            // Set the row height and column width to adjust/fit the cell value inside cell
            worksheet.Cells.SetColumnWidthPixel(1, widthOfValue);
            worksheet.Cells.SetRowHeightPixel(1, heightOfValue);

            // Save the output excel file
            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:CalculateWidthAndHeightOfCellValueInUnitOfPixel
        }
    }
}
