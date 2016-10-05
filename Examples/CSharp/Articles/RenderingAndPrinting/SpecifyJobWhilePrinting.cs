using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class SpecifyJobWhilePrinting
    {
        public static void Run()
        {
            // ExStart:SpecifyJobNameWhilePrinting
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object from source Excel file
            Workbook workbook = new Workbook(dataDir + "SampleBook.xlsx");

            string printerName = "";

            while (string.IsNullOrEmpty(printerName) && string.IsNullOrWhiteSpace(printerName))
            {
                Console.WriteLine("Please Enter Your Printer Name:");
                printerName = Console.ReadLine();
            }

            string jobName = "Job Name while Printing with Aspose.Cells";

            // Print workbook using WorkbookRender
            WorkbookRender wr = new WorkbookRender(workbook, new ImageOrPrintOptions());
            try
            {
                wr.ToPrinter(printerName, jobName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Print worksheet using SheetRender
            SheetRender sr = new SheetRender(worksheet, new ImageOrPrintOptions());
            try
            {
                sr.ToPrinter(printerName, jobName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // ExEnd:SpecifyJobNameWhilePrinting
        }
    }
}
