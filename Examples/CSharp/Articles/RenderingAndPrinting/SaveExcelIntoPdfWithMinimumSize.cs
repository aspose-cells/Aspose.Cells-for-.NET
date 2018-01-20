using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class SaveExcelIntoPdfWithMinimumSize
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load excel file into workbook object
            Workbook workbook = new Workbook(sourceDir + "sampleSaveExcelIntoPdfWithMinimumSize.xlsx");

            // Save into Pdf with Minimum size
            PdfSaveOptions opts = new PdfSaveOptions();
            opts.OptimizationType = Aspose.Cells.Rendering.PdfOptimizationType.MinimumSize;

            workbook.Save(outputDir + "outputSaveExcelIntoPdfWithMinimumSize.pdf", opts);

            Console.WriteLine("SaveExcelIntoPdfWithMinimumSize executed successfully.");
        }
    }
}
