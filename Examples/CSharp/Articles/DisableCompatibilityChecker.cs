using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class DisableCompatibilityChecker
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open a template file
            Workbook workbook = new Workbook(sourceDir + "sampleDisableCompatibilityChecker.xlsx");

            // Disable the compatibility checker
            workbook.Settings.CheckCompatibility = false;

            // Saving the Excel file
            workbook.Save(outputDir + "outputDisableCompatibilityChecker.xlsx");

            Console.WriteLine("DisableCompatibilityChecker executed successfully.\r\n");
        }
    }
}
