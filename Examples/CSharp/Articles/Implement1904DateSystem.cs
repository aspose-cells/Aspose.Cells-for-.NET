using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class Implement1904DateSystem
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open an excel file
            Workbook workbook = new Workbook(sourceDir + "sampleImplement1904DateSystem.xlsx");

            // Implement 1904 date system
            workbook.Settings.Date1904 = true;

            // Save the excel file
            workbook.Save(outputDir + "outputImplement1904DateSystem.xlsx");

            Console.WriteLine("Implement1904DateSystem executed successfully.");
        }
    }
}
