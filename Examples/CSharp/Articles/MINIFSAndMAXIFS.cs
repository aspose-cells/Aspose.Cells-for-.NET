using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class MINIFSAndMAXIFS
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // ExStart:1
            // Load your source workbook containing MINIFS and MAXIFS functions
            Workbook workbook = new Workbook(sourceDir + "sampleMINIFSAndMAXIFS.xlsx");

            // Perform Aspose.Cells formula calculation
            workbook.CalculateFormula();

            // Save the calculations result in pdf format
            PdfSaveOptions options = new PdfSaveOptions();
            options.OnePagePerSheet = true;
            workbook.Save(outputDir + "outputMINIFSAndMAXIFS.pdf", options);
            // ExEnd:1

            Console.WriteLine("MINIFSAndMAXIFS executed successfully.");
        }
    }
}
