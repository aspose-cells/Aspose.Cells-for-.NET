using System.IO;
using System;
using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class CreateTransparentImage
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object from source file
            Workbook wb = new Workbook(dataDir+ "aspose-sample.xlsx");

            // Apply different image or print options
            var imgOption = new ImageOrPrintOptions();
            imgOption.ImageFormat = ImageFormat.Png;
            imgOption.HorizontalResolution = 200;
            imgOption.VerticalResolution = 200;
            imgOption.OnePagePerSheet = true;

            // Apply transparency to the output image
            imgOption.Transparent = true;

            // Create image after apply image or print options
            var sr = new SheetRender(wb.Worksheets[0], imgOption);

            dataDir = dataDir+ "output.png";
            sr.ToImage(0, dataDir);
            // ExEnd:1
            Console.WriteLine("\nProcess completed successfully.\nFile saved at " + dataDir);
        }
    }
}
