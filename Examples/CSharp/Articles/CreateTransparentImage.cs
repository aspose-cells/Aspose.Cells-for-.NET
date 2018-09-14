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
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook object from source file
            Workbook wb = new Workbook(sourceDir + "sampleCreateTransparentImage.xlsx");

            // Apply different image or print options
            var imgOption = new ImageOrPrintOptions();
            imgOption.ImageType = Drawing.ImageType.Png;
            imgOption.HorizontalResolution = 200;
            imgOption.VerticalResolution = 200;
            imgOption.OnePagePerSheet = true;

            // Apply transparency to the output image
            imgOption.Transparent = true;

            // Create image after apply image or print options
            var sr = new SheetRender(wb.Worksheets[0], imgOption);
            sr.ToImage(0, outputDir + "outputCreateTransparentImage.png");

            Console.WriteLine("CreateTransparentImage executed successfully.");
        }
    }
}
