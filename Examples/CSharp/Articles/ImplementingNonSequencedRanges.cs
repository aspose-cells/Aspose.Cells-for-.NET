using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ImplementingNonSequencedRanges
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Adding a Name for non sequenced range
            int index = workbook.Worksheets.Names.Add("NonSequencedRange");

            Name name = workbook.Worksheets.Names[index];

            // Creating a non sequence range of cells
            name.RefersTo = "=Sheet1!$A$1:$B$3,Sheet1!$D$5:$E$6";

            // Save the workbook
            workbook.Save(outputDir + "outputImplementingNonSequencedRanges.xlsx");

            Console.WriteLine("ImplementingNonSequencedRanges executed successfully.");
        }
    }
}
