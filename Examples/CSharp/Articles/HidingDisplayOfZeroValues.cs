using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class HidingDisplayOfZeroValues
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create a new Workbook object
            Workbook workbook = new Workbook(sourceDir + "sampleHidingDisplayOfZeroValues.xlsx");

            // Get First worksheet of the workbook
            Worksheet sheet = workbook.Worksheets[0];

            // Hide the zero values in the sheet
            sheet.DisplayZeros = false;

            // Save the workbook
            workbook.Save(outputDir + "outputHidingDisplayOfZeroValues.xlsx");

            Console.WriteLine("HidingDisplayOfZeroValues executed successfully.\r\n");
        }
    }
}
