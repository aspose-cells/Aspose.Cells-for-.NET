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
            // ExStart:1

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiate a workbook.
            //Open an Excel file.
            Workbook workbook = new Workbook(dataDir + "SampleBook.xlsx");

            //Define a worksheet.
            Worksheet worksheet;

            //Get the second sheet.
            worksheet = workbook.Worksheets[1];

            //Apply different Image / Print options.
            Aspose.Cells.Rendering.ImageOrPrintOptions options = new Aspose.Cells.Rendering.ImageOrPrintOptions();
            options.PrintingPage = PrintingPageType.Default;
            SheetRender sr = new SheetRender(worksheet, options);

            Console.WriteLine("Printing SampleBook.xlsx");
            //Print the sheet.
            sr.ToPrinter("{Replace_With_Printer_Name}");
            Console.WriteLine("Pinting finished.");
            // ExEnd:1
        }
    }
}
