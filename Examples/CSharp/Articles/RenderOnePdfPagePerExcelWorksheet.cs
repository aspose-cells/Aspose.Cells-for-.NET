using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class RenderOnePdfPagePerExcelWorksheet
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open an Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleRenderOnePdfPagePerExcelWorksheet.xlsx");

            // Implement one page per worksheet option
            PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
            pdfSaveOptions.OnePagePerSheet = true;

            // Save the PDF file
            workbook.Save(outputDir + "outputRenderOnePdfPagePerExcelWorksheet.pdf", pdfSaveOptions);

            Console.WriteLine("RenderOnePdfPagePerExcelWorksheet executed successfully.");
        }
    }
}