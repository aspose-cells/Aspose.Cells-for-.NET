using System.IO;
using System.Web;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class ExportCustomPropertiesToPDF
    {
        public static void Main()
        {
            // ExStart:1
            //Input directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load excel file containing custom properties
            Workbook workbook = new Workbook(sourceDir + "sampleWithCustProps.xlsx");

            // Create an instance of PdfSaveOptions and pass SaveFormat to the constructor
            Aspose.Cells.PdfSaveOptions pdfSaveOpt = new Aspose.Cells.PdfSaveOptions();

            // Set CustomPropertiesExport property to PdfCustomPropertiesExport.Standard
            pdfSaveOpt.CustomPropertiesExport = Aspose.Cells.Rendering.PdfCustomPropertiesExport.Standard;

            // Save the workbook to PDF format while passing the object of PdfSaveOptions
            workbook.Save(outputDir + "outSampleWithCustProps.pdf", pdfSaveOpt);

            Console.WriteLine("ExportCustomPropertiesToPDF executed successfully.");
            // ExEnd:1
        }
    }
}
