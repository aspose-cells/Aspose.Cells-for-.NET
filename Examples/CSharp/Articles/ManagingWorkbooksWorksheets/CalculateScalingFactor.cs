using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class CalculateScalingFactor
    {
        public static void Run()
        {
            // ExStart:CalculatePageSetupScalingFactor
            // Create workbook object
            Workbook workbook = new Workbook();

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Put some data in these cells
            worksheet.Cells["A4"].PutValue("Test");
            worksheet.Cells["S4"].PutValue("Test");

            // Set paper size
            worksheet.PageSetup.PaperSize = PaperSizeType.PaperA4;

            // Set fit to pages wide as 1
            worksheet.PageSetup.FitToPagesWide = 1;

            // Calculate page scale via sheet render
            SheetRender sr = new SheetRender(worksheet, new ImageOrPrintOptions());

            // Convert page scale double value to percentage
            string strPageScale = sr.PageScale.ToString("0%");

            // Write the page scale value
            Console.WriteLine(strPageScale);
            // ExEnd:CalculatePageSetupScalingFactor
        }
    }
}
