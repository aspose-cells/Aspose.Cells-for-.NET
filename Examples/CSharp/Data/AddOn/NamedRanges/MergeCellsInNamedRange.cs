using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class MergeCellsInNamedRange
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Instantiate a new Workbook.
            Workbook wb1 = new Workbook();

            // Get the first worksheet in the workbook.
            Worksheet worksheet1 = wb1.Worksheets[0];

            // Create a range.
            Range mrange = worksheet1.Cells.CreateRange("D6", "I12");

            // Name the range.
            mrange.Name = "TestRange";

            // Merge the cells of the range.
            mrange.Merge();

            // Get the range.
            Range range1 = wb1.Worksheets.GetRangeByName("TestRange");      

            // Define a style object.
            Style style = wb1.CreateStyle();

            // Set the alignment.
            style.HorizontalAlignment = TextAlignmentType.Center;
            style.VerticalAlignment = TextAlignmentType.Center;
            style.Pattern = BackgroundType.Solid;
            style.ForegroundColor = System.Drawing.Color.Aqua;

            // Create a StyleFlag object.
            StyleFlag flag = new StyleFlag();
            // Make the relative style attribute ON.
            flag.HorizontalAlignment = true;
            flag.VerticalAlignment = true;
            flag.CellShading = true;

            // Apply the style to the range.
            range1.ApplyStyle(style, flag);

            // Input data into range.
            range1[0, 0].PutValue("Welcome to Aspose APIs.");

            // Save the excel file.
            wb1.Save(outputDir + "outputMergeCellsInNamedRange.xlsx");

            Console.WriteLine("MergeCellsInNamedRange executed successfully.");
        }
    }
}
