using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class LimitNumberOfPagesGenerated
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open an Excel file
            Workbook wb = new Workbook(sourceDir + "sampleLimitNumberOfPagesGenerated.xlsx");
            
            // Instantiate the PdfSaveOption
            PdfSaveOptions options = new PdfSaveOptions();

            // Print pages 3, 4, 5, 6
            options.PageIndex = 3;
            options.PageCount = 4;

            // Save the PDF file
            wb.Save(outputDir + "outputLimitNumberOfPagesGenerated.pdf", options);

            Console.WriteLine("LimitNumberOfPagesGenerated executed successfully.");
        }
    }
}
