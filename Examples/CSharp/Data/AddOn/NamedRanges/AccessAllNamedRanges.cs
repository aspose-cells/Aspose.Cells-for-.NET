using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class AccessAllNamedRanges
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Run()
        {
            // Opening the Excel file through the file stream
            Workbook workbook = new Workbook(sourceDir + "sampleAccessAllNamedRanges.xlsx");

            // Getting all named ranges
            Range[] range = workbook.Worksheets.GetNamedRanges();

            Console.WriteLine("Total Number of Named Ranges: " + range.Length);

            Console.WriteLine("AccessAllNamedRanges executed successfully.");
        }
    }
}
