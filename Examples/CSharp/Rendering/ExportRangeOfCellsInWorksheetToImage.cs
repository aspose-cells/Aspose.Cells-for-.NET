using System.IO;

using System.Drawing;
using System.Drawing.Imaging;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Rendering;
using System;

namespace Aspose.Cells.Examples.CSharp.Rendering
{
    public class ExportRangeOfCellsInWorksheetToImage
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook from source file.
            Workbook workbook = new Workbook(sourceDir + "sampleExportRangeOfCellsInWorksheetToImage.xlsx");

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Set the print area with your desired range
            worksheet.PageSetup.PrintArea = "D8:G16";

            // Set all margins as 0
            worksheet.PageSetup.LeftMargin = 0;
            worksheet.PageSetup.RightMargin = 0;
            worksheet.PageSetup.TopMargin = 0;
            worksheet.PageSetup.BottomMargin = 0;

            // Set OnePagePerSheet option as true
            ImageOrPrintOptions options = new ImageOrPrintOptions();
            options.OnePagePerSheet = true;
            options.ImageType = ImageType.Jpeg;
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;

            // Take the image of your worksheet
            SheetRender sr = new SheetRender(worksheet, options);
            sr.ToImage(0, outputDir + "outputExportRangeOfCellsInWorksheetToImage.jpg");

            Console.WriteLine("ExportRangeOfCellsInWorksheetToImage executed successfully.\r\n");
        }
    }

}
