using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class RenderUnicodeInOutput
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load your source excel file containing Unicode Supplementary characters
            Workbook wb = new Workbook(sourceDir + "sampleRenderUnicodeInOutput_UnicodeSupplementaryCharacters.xlsx");

            // Save the workbook
            wb.Save(outputDir + "outputRenderUnicodeInOutput_UnicodeSupplementaryCharacters.pdf");

            Console.WriteLine("RenderUnicodeInOutput executed successfully.");
        }
    }
}