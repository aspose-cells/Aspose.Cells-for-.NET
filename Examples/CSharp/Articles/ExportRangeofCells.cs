using System.IO;
using System;
using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace CSharp.Articles
{
    public class ExportRangeofCells
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string filePath = dataDir+ "aspose-sample.xlsx";

            // Create workbook from source file.
            Workbook workbook = new Workbook(filePath);

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Set the print area with your desired range
            worksheet.PageSetup.PrintArea = "E12:H16";

            // Set all margins as 0
            worksheet.PageSetup.LeftMargin = 0;
            worksheet.PageSetup.RightMargin = 0;
            worksheet.PageSetup.TopMargin = 0;
            worksheet.PageSetup.BottomMargin = 0;

            // Set OnePagePerSheet option as true
            ImageOrPrintOptions options = new ImageOrPrintOptions();
            options.OnePagePerSheet = true;
            options.ImageFormat = ImageFormat.Jpeg;

            // Take the image of your worksheet
            SheetRender sr = new SheetRender(worksheet, options);
            dataDir = dataDir+ "output.out.jpg";
            sr.ToImage(0, dataDir);
            // ExEnd:1
            Console.WriteLine("\nProcess completed successfully.\nFile saved at " + dataDir);
            
        }
    }
}
