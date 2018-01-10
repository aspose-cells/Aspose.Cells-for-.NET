using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class SecurePDFDocuments
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open an Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleSecurePDFDocuments.xlsx");

            // Instantiate PDFSaveOptions to manage security attributes
            PdfSaveOptions saveOption = new PdfSaveOptions();

            saveOption.SecurityOptions = new Aspose.Cells.Rendering.PdfSecurity.PdfSecurityOptions();
            
            // Set the user password
            saveOption.SecurityOptions.UserPassword = "user";

            // Set the owner password
            saveOption.SecurityOptions.OwnerPassword = "owner";

            // Disable extracting content permission
            saveOption.SecurityOptions.ExtractContentPermission = false;

            // Disable print permission
            saveOption.SecurityOptions.PrintPermission = false;

            // Save the PDF document with encrypted settings
            workbook.Save(outputDir + "outputSecurePDFDocuments.pdf", saveOption);

            Console.WriteLine("SecurePDFDocuments executed successfully.");
        }
    }
}