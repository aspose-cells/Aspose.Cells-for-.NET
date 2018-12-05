using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class ConvertExcelFileToSVG
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // ExStart:ConvertExcelFileToSVG

            // Instantiate a workbook
            var workBook = new Workbook();

            // Put sample text in the first cell of first worksheet in the newly created workbook
            workBook.Worksheets[0].Cells["A1"].Value = "DEMO TEXT ON SHEET1";

            // Add second worksheet in the workbook
            workBook.Worksheets.Add(SheetType.Worksheet);

            // Set text in first cell of the second sheet
            workBook.Worksheets[1].Cells["A1"].Value = "DEMO TEXT ON SHEET2";

            // Set currently active sheet incex to 1 i.e. Sheet2
            workBook.Worksheets.ActiveSheetIndex = 1;

            // Save workbook to SVG. It shall render the active sheet only to SVG
            workBook.Save(outputDir + @"Demo.svg");
            // ExEnd:ConvertExcelFileToSVG

            Console.WriteLine("\r\nConvertExcelFileToSVG executed successfully.");
        }
    }
}
