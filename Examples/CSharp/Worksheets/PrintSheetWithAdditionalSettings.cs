using Aspose.Cells.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class PrintSheetWithAdditionalSettings
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Load source Excel file
            Workbook workbook = new Workbook(sourceDir + "SheetRenderSample.xlsx");

            ImageOrPrintOptions imgOpt = new ImageOrPrintOptions();

            //Access first worksheet
            Worksheet worksheet = workbook.Worksheets[1];

            SheetRender sheetRender = new SheetRender(worksheet, imgOpt);

            PrinterSettings printerSettings = new PrinterSettings();
            printerSettings.PrinterName = "<PRINTER NAME>";
            printerSettings.Copies = 2;

            sheetRender.ToPrinter(printerSettings);
            // ExEnd:1
        }
    }
}
