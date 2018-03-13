using System.IO;

using Aspose.Cells;
using System;
using System.Diagnostics;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class AccessingMaximumDisplayRangeofWorksheet
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Run()
        {
            // Instantiating a Workbook object
            Workbook wb = new Workbook(sourceDir + "sampleAccessingMaximumDisplayRangeofWorksheet.xlsx");

            // Access the first workbook
            Worksheet worksheet = wb.Worksheets[0];

            // Access the Maximum Display Range
            Range range = worksheet.Cells.MaxDisplayRange;

            // Print the Maximum Display Range RefersTo property
            Console.WriteLine("Maximum Display Range: " + range.RefersTo);

            Console.WriteLine("AccessingMaximumDisplayRangeofWorksheet executed successfully.");
        }
    }
}