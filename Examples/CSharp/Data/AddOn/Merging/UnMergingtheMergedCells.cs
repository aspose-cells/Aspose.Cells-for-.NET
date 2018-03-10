using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class UnMergingtheMergedCells
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Create a Workbook.
            Workbook wbk = new Aspose.Cells.Workbook(sourceDir + "sampleUnMergingtheMergedCells.xlsx");

            // Create a Worksheet and get the first sheet.
            Worksheet worksheet = wbk.Worksheets[0];

            // Create a Cells object ot fetch all the cells.
            Cells cells = worksheet.Cells;

            // Unmerge the cells.
            cells.UnMerge(5, 2, 2, 3);

            // Save the file.
            wbk.Save(outputDir + "outputUnMergingtheMergedCells.xlsx");

            Console.WriteLine("UnMergingtheMergedCells executed successfully.");
        }
    }
}
