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
            // ExStart:PrintingExcelWorkbookUsingWorkbookRender
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate a workbook with an Excel file.
            Workbook workbook = new Workbook(dataDir + "SampleBook.xlsx");

            string printerName = "";

            while (string.IsNullOrEmpty(printerName) && string.IsNullOrWhiteSpace(printerName))
            {
                Console.WriteLine("Please Enter Your Printer Name:");
                printerName = Console.ReadLine();
            }

            // Apply different Image/Print options.
            Aspose.Cells.Rendering.ImageOrPrintOptions options = new Aspose.Cells.Rendering.ImageOrPrintOptions();
            options.ImageFormat = System.Drawing.Imaging.ImageFormat.Tiff;
            options.PrintingPage = PrintingPageType.Default;

            // To print a whole workbook, iterate through the sheets and print them, or use the WorkbookRender class.
            WorkbookRender wr = new WorkbookRender(workbook, options);

            Console.WriteLine("Printing SampleBook.xlsx");
            // Print the workbook.
            try
            {
                wr.ToPrinter(printerName);
                Console.WriteLine("Pinting finished.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // ExEnd:PrintingExcelWorkbookUsingWorkbookRender
        }
    }
}
