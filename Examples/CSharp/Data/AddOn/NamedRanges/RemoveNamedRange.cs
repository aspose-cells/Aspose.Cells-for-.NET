using System;
using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class RemoveNamedRange
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            // Get all the worksheets in the book.
            WorksheetCollection worksheets = workbook.Worksheets;

            // Get the first worksheet in the worksheets collection.
            Worksheet worksheet = workbook.Worksheets[0];

            // Create a range of cells.
            Range range1 = worksheet.Cells.CreateRange("E12", "I12");

            // Name the range.
            range1.Name = "FirstRange";

            // Set the outline border to the range.
            range1.SetOutlineBorder(BorderType.TopBorder, CellBorderType.Medium, Color.FromArgb(0, 0, 128));
            range1.SetOutlineBorder(BorderType.BottomBorder, CellBorderType.Medium, Color.FromArgb(0, 0, 128));
            range1.SetOutlineBorder(BorderType.LeftBorder, CellBorderType.Medium, Color.FromArgb(0, 0, 128));
            range1.SetOutlineBorder(BorderType.RightBorder, CellBorderType.Medium, Color.FromArgb(0, 0, 128));

            // Input some data with some formattings into
            // A few cells in the range.
            range1[0, 0].PutValue("Test");            
            range1[0, 4].PutValue(123);
           
            // Create another range of cells.
            Range range2 = worksheet.Cells.CreateRange("B3", "F3");

            // Name the range.
            range2.Name = "SecondRange";

            // Copy the first range into second range.
            range2.Copy(range1);

            // Remove the previous named range (range1) with its contents.
            worksheet.Cells.ClearRange(range1.FirstRow, range1.FirstColumn, range1.FirstRow + range1.RowCount-1, range1.FirstColumn + range1.ColumnCount-1);
            worksheets.Names.RemoveAt(0);

            // Save the excel file.
            workbook.Save(outputDir + "outputRemoveNamedRange.xlsx");

            Console.WriteLine("RemoveNamedRange executed successfully.");
        }
    }
}
