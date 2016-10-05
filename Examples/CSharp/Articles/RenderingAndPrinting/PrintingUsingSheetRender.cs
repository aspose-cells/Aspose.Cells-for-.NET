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
            // ExStart:PrintingExcelWorkbookUsingSheetRender
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate a workbook with Excel file.
            Workbook workbook = new Workbook(dataDir + "SampleBook.xlsx");

            string printerName = "";

            while (string.IsNullOrEmpty(printerName) && string.IsNullOrWhiteSpace(printerName))
            {
                Console.WriteLine("Please Enter Your Printer Name:");
                printerName = Console.ReadLine();
            }

            // Define a worksheet.
            Worksheet worksheet;

            // Get the second sheet.
            worksheet = workbook.Worksheets[1];

            // Apply different Image/Print options.
            Aspose.Cells.Rendering.ImageOrPrintOptions options = new Aspose.Cells.Rendering.ImageOrPrintOptions();
            options.PrintingPage = PrintingPageType.Default;
            SheetRender sr = new SheetRender(worksheet, options);

            Console.WriteLine("Printing SampleBook.xlsx");
            // Print the sheet.
            try
            {
                sr.ToPrinter(printerName);
                Console.WriteLine("Pinting finished.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // ExEnd:PrintingExcelWorkbookUsingSheetRender
        }
    }
}
