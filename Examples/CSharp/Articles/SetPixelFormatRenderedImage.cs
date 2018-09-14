using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class SetPixelFormatRenderedImage
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load an Excel file
            Workbook wb = new Workbook(sourceDir + "sampleSetPixelFormatRenderedImage.xlsx");

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            // Set the ImageOrPrintOptions with desired pixel format (24 bits per pixel) and image format type
            ImageOrPrintOptions opts = new ImageOrPrintOptions();
            opts.PixelFormat = PixelFormat.Format24bppRgb;
            opts.ImageType = Drawing.ImageType.Tiff;

            // Instantiate SheetRender object based on the first worksheet
            SheetRender sr = new SheetRender(ws, opts);

            // Save the image (first page of the sheet) with the specified options
            sr.ToImage(0, outputDir + "outputSetPixelFormatRenderedImage.tiff");

            Console.WriteLine("SetPixelFormatRenderedImage executed successfully.");
        }
    }
}