using System.IO;
using System;
using Aspose.Cells;
using System.Collections;
using Aspose.Cells.Rendering.PdfSecurity;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ContentCopyForAccessibilityOption
    {
        public static void Main()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            string inputPath = sourceDir + "BookWithSomeData.xlsx";


            // Load excel file containing some data
            Workbook workbook = new Workbook(inputPath);

            // Create an instance of PdfSaveOptions and pass SaveFormat to the constructor
            Aspose.Cells.PdfSaveOptions pdfSaveOpt = new Aspose.Cells.PdfSaveOptions();

            // Create an instance of PdfSecurityOptions
            PdfSecurityOptions securityOptions = new PdfSecurityOptions();

            // Set AccessibilityExtractContent to true
            securityOptions.AccessibilityExtractContent = false;

            // Set the securityoption in the PdfSaveOptions
            pdfSaveOpt.SecurityOptions = securityOptions;

            // Save the workbook to PDF format while passing the object of PdfSaveOptions
            workbook.Save(outputDir + "outBookWithSomeData.pdf", pdfSaveOpt);

            Console.WriteLine("ContentCopyForAccessibilityOption executed successfully.\r\n");

        }
    }
}
