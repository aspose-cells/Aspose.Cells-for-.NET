using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class PrintingRangeOfPages
    {
        public static void Run()
        {
            // ExStart:PrintingSpecificRangeOfPages
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook from source Excel file
            Workbook workbook = new Workbook(dataDir + "SampleBook.xlsx");

            string printerName = "";

            while (string.IsNullOrEmpty(printerName) && string.IsNullOrWhiteSpace(printerName))
            {
                Console.WriteLine("Please Enter Your Printer Name:");
                printerName = Console.ReadLine();
            }

            // Print the worbook specifying the range of pages. Here we are printing pages 2-3
            WorkbookRender wr = new WorkbookRender(workbook, new ImageOrPrintOptions());
            try
            {
                wr.ToPrinter(printerName, 1, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Print the worksheet specifying the range of pages. Here we are printing pages 2-3
            SheetRender sr = new SheetRender(worksheet, new ImageOrPrintOptions());
            try
            {
                sr.ToPrinter(printerName, 1, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // ExEnd:PrintingSpecificRangeOfPages
        }
    }
}
