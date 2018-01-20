using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class PrintingUsingSheetRender
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Instantiate a workbook with Excel file.
            Workbook workbook = new Workbook(sourceDir + "samplePrintingUsingSheetRender.xlsx");

            string printerName = "doPDF 8";

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Apply different Image/Print options.
            Aspose.Cells.Rendering.ImageOrPrintOptions options = new Aspose.Cells.Rendering.ImageOrPrintOptions();
            options.PrintingPage = PrintingPageType.Default;
            SheetRender sr = new SheetRender(worksheet, options);

            // Print the sheet.
            try
            {
                sr.ToPrinter(printerName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("PrintingUsingSheetRender executed successfully.");
        }
    }
}
