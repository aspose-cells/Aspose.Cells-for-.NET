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

            // Load your source workbook containing MINIFS and MAXIFS functions
            Workbook wb = new Workbook(sourceDir + "sampleMINIFSAndMAXIFS.xlsx");

            // Perform Aspose.Cells formula calculation
            wb.CalculateFormula();

            // Save the calculations result in pdf format
            PdfSaveOptions opts = new PdfSaveOptions();
            opts.OnePagePerSheet = true;
            wb.Save(outputDir + "outputMINIFSAndMAXIFS.pdf", opts);

            Console.WriteLine("MINIFSAndMAXIFS executed successfully.");
        }
    }
}
