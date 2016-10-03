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
            //ExStart:1

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiate a workbook.
            //Open an Excel file.
            Workbook workbook = new Workbook(dataDir + "SampleBook.xlsx");

            //Apply different Image / Print options.
            Aspose.Cells.Rendering.ImageOrPrintOptions options = new Aspose.Cells.Rendering.ImageOrPrintOptions();
            options.ImageFormat = System.Drawing.Imaging.ImageFormat.Tiff;
            options.PrintingPage = PrintingPageType.Default;

            //To print a whole workbook, iterate through the sheets and print them, or use the WorkbookRender class.
            WorkbookRender wr = new WorkbookRender(workbook, options);

            Console.WriteLine("Printing SampleBook.xlsx");
            //Print the workbook.
            wr.ToPrinter("{Replace_With_Printer_Name}");
            Console.WriteLine("Pinting finished.");
            //ExEnd:1
        }
    }
}
