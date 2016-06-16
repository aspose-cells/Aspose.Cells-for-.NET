using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ResamplingAddedImages
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Initialize a new Workbook
            // Open an Excel file
            Workbook workbook = new Workbook(dataDir+ "input.xlsx");

            // Instantiate the PdfSaveOptions
            PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
            // Set Image Resample properties
            pdfSaveOptions.SetImageResample(300, 70);

            // Save the PDF file
            workbook.Save(dataDir+ "OutputFile.out.pdf", pdfSaveOptions);
            
        }
    }
}