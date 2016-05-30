using System.IO;
using System;
using Aspose.Cells;

namespace CSharp.Articles
{
    public class FitAllWorksheetColumns
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Create and initialize an instance of Workbook
            Workbook book = new Workbook(dataDir + "TestBook.xlsx");
            // Create and initialize an instance of PdfSaveOptions
            PdfSaveOptions saveOptions = new PdfSaveOptions(SaveFormat.Pdf);
            // Set AllColumnsInOnePagePerSheet to true
            saveOptions.AllColumnsInOnePagePerSheet = true;
            // Save Workbook to PDF fromart by passing the object of PdfSaveOptions
            dataDir = dataDir+ "output.out.pdf";
            book.Save(dataDir, saveOptions);            
            // ExEnd:1
            Console.WriteLine("\nProcess completed successfully.\nFile saved at " + dataDir);
        }
    }
}
