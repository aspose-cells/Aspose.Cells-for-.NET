using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.PageSetupAndPrintingOptions
{
    public class SettingPageSetup
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open the template workbook
            Workbook workbook = new Workbook(sourceDir + "sampleSettingPageSetup.xlsx");

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            // Setting the orientation to Portrait
            worksheet.PageSetup.Orientation = PageOrientationType.Portrait;

            // Setting the scaling factor to 100
            // worksheet.PageSetup.Zoom = 100;

            // OR Alternately you can use Fit to Page Options as under

            // Setting the number of pages to which the length of the worksheet will be spanned
            worksheet.PageSetup.FitToPagesTall = 1;

            // Setting the number of pages to which the width of the worksheet will be spanned
            worksheet.PageSetup.FitToPagesWide = 1;

            // Setting the paper size to A4
            worksheet.PageSetup.PaperSize = PaperSizeType.PaperA4;

            // Setting the print quality of the worksheet to 1200 dpi
            worksheet.PageSetup.PrintQuality = 1200;

            //Setting the first page number of the worksheet pages
            worksheet.PageSetup.FirstPageNumber = 2;

            // Save the workbook
            workbook.Save(outputDir + "outputSettingPageSetup.xlsx");

            Console.WriteLine("SettingPageSetup executed successfully.");
        }
    }
}
