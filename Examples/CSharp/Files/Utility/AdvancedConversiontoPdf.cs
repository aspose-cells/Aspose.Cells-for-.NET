using System.IO;

using Aspose.Cells;
using Aspose.Cells.Rendering;

namespace CSharp.Files.Utility
{
    public class AdvancedConversiontoPdf
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate new workbook
            Workbook workbook = new Workbook();

            // Insert a value into the A1 cell in the first worksheet
            workbook.Worksheets[0].Cells[0, 0].PutValue("Testing PDF/A");

            // Define PdfSaveOptions
            PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();

            // Set the compliance type
            pdfSaveOptions.Compliance = PdfCompliance.PdfA1b;

            // Save the file
            workbook.Save(dataDir + "output.pdf", pdfSaveOptions);
            // ExEnd:1
        }
    }
}
