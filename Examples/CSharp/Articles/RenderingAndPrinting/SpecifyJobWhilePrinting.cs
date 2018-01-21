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
            Console.WriteLine("SpecifyJobWhilePrinting Started Now.");

            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Create workbook object from source Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleSpecifyJobWhilePrinting.xlsx");

            string printerName = "doPDF 8";

            string jobName = "My Job Name";

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

            Console.Write("Press Enter to continue...");
            Console.ReadLine();

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[1];

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

            Console.WriteLine("SpecifyJobWhilePrinting executed successfully.");
        }
    }
}
