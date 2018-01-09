using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ResamplingAddedImages
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open an Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleResamplingAddedImages.xlsx");

            // Instantiate the PdfSaveOptions
            PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
            
            // Set Image Resample properties
            pdfSaveOptions.SetImageResample(300, 70);

            // Save the PDF file
            workbook.Save(outputDir + "outputResamplingAddedImages.pdf", pdfSaveOptions);

            Console.WriteLine("ResamplingAddedImages executed successfully.");

        }
    }
}