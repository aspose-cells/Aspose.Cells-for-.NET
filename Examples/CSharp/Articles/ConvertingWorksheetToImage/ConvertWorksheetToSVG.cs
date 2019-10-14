using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.Articles.ConvertingWorksheetToImage
{
    public class ConvertWorksheetToSVG
    {
        public static void Run()
        {
            // ExStart:1
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate a workbook
            var workbook = new Workbook();

            // Put sample text in the first cell of first worksheet in the newly created workbook
            workbook.Worksheets[0].Cells["A1"].Value = "DEMO TEXT ON SHEET1";

            // Add second worksheet in the workbook
            workbook.Worksheets.Add(SheetType.Worksheet);

            // Set text in first cell of the second sheet
            workbook.Worksheets[1].Cells["A1"].Value = "DEMO TEXT ON SHEET2";

            // Set currently active sheet incex to 1 i.e. Sheet2
            workbook.Worksheets.ActiveSheetIndex = 1;

            // Save workbook to SVG. It shall render the active sheet only to SVG
            workbook.Save(outputDir + "ConvertWorksheetToSVG_out.svg");
            // ExEnd:1

            Console.WriteLine("ConvertWorksheetToSVG executed successfully.");
        }
    }
}
