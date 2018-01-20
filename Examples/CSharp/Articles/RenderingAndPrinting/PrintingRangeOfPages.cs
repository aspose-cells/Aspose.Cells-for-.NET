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
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Create workbook from source Excel file
            Workbook workbook = new Workbook(sourceDir + "samplePrintingRangeOfPages.xlsx");

            string printerName = "doPDF 8";

            Console.Write("PrintingRangeOfPages example with WorkbookRender: ");

            // Print the worbook specifying the range of pages. Here we are printing pages 2-3
            WorkbookRender wr = new WorkbookRender(workbook, new ImageOrPrintOptions());

            try
            {
                wr.ToPrinter(printerName, 3, 4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.Write("Press Enter to continue - PrintingRangeOfPages example with SheetRender: ");
            Console.ReadLine();

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

            Console.WriteLine("PrintingRangeOfPages executed successfully.");
        }
    }
}
