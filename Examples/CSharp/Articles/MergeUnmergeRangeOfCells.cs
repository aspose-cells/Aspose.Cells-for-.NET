using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class MergeUnmergeRangeOfCells
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create a workbook
            Workbook workbook = new Workbook();

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Create a range
            Range range = worksheet.Cells.CreateRange("A1:D4");

            // Merge range into a single cell
            range.Merge();

            // Save the workbook
            workbook.Save(outputDir + "outputMergeUnmergeRangeOfCells.xlsx");

            Console.WriteLine("MergeUnmergeRangeOfCells executed successfully.");
        }
    }
}