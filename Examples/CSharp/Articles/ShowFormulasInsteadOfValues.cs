using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ShowFormulasInsteadOfValues
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load the source workbook
            Workbook workbook = new Workbook(sourceDir + "sampleShowFormulasInsteadOfValues.xlsx");

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Show formulas of the worksheet
            worksheet.ShowFormulas = true;

            // Save the workbook
            workbook.Save(outputDir + "outputShowFormulasInsteadOfValues.xlsx");

            Console.WriteLine("ShowFormulasInsteadOfValues executed successfully.");
        }
    }
}