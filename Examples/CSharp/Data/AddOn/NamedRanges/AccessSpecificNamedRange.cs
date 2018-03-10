using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data.AddOn.NamedRanges
{
    public class AccessSpecificNamedRange
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Run()
        {
            // Opening the Excel file through the file stream
            Workbook workbook = new Workbook(sourceDir + "sampleAccessSpecificNamedRange.xlsx");

            // Getting the specified named range
            Range range = workbook.Worksheets.GetRangeByName("MyRangeTwo");

            if (range != null)
                Console.WriteLine("Named Range : " + range.RefersTo);

            Console.WriteLine("AccessSpecificNamedRange executed successfully.");
        }
    }
}
