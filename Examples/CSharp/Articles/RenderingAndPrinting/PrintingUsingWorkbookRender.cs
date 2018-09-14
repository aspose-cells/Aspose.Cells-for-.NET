using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class PrintingUsingWorkbookRender
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Instantiate a workbook with an Excel file.
            Workbook workbook = new Workbook(sourceDir + "samplePrintingUsingWorkbookRender.xlsx");

            string printerName = "doPDF 8";

            // Apply different Image/Print options.
            Aspose.Cells.Rendering.ImageOrPrintOptions options = new Aspose.Cells.Rendering.ImageOrPrintOptions();
            options.ImageType = Drawing.ImageType.Tiff;
            options.PrintingPage = PrintingPageType.Default;

            // To print a whole workbook, iterate through the sheets and print them, or use the WorkbookRender class.
            WorkbookRender wr = new WorkbookRender(workbook, options);
            
            try
            {
                // Print the workbook.
                wr.ToPrinter(printerName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("PrintingUsingWorkbookRender executed successfully.");
        }
    }
}
