using System;
using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class FormatRanges2
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            Worksheet worksheet = workbook.Worksheets[0];

            // Accessing the "G8" cell from the worksheet
            Cell cell = worksheet.Cells["G8"];

            // Adding some value to the "G8" cell
            cell.PutValue("Hello World From Aspose");

            // Creating a range of cells 
            Range range = worksheet.Cells.CreateRange(5, 5, 5, 5);

            // Adding a thick top border with blue line
            range.SetOutlineBorder(BorderType.TopBorder, CellBorderType.Thick, Color.Blue);

            // Adding a thick bottom border with blue line
            range.SetOutlineBorder(BorderType.BottomBorder, CellBorderType.Thick, Color.Blue);

            // Adding a thick left border with blue line
            range.SetOutlineBorder(BorderType.LeftBorder, CellBorderType.Thick, Color.Blue);

            // Adding a thick right border with blue line
            range.SetOutlineBorder(BorderType.RightBorder, CellBorderType.Thick, Color.Blue);

            // Saving the Excel file
            workbook.Save(outputDir + "outputFormatRanges2.xlsx");

            Console.WriteLine("FormatRanges2 executed successfully.");
        }
    }
}
