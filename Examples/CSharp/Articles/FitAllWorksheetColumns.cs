using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class FitAllWorksheetColumns
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create and initialize an instance of Workbook
            Workbook book = new Workbook(sourceDir + "sampleFitAllWorksheetColumns.xlsx");
            
            // Create and initialize an instance of PdfSaveOptions
            PdfSaveOptions saveOptions = new PdfSaveOptions(SaveFormat.Pdf);
            
            // Set AllColumnsInOnePagePerSheet to true
            saveOptions.AllColumnsInOnePagePerSheet = true;

            // Save Workbook to PDF fromart by passing the object of PdfSaveOptions
            book.Save(outputDir + "outputFitAllWorksheetColumns.pdf", saveOptions);            

            Console.WriteLine("FitAllWorksheetColumns executed successfully.\r\n");
        }
    }
}
