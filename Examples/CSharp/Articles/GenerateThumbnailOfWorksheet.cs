using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class GenerateThumbnailOfWorksheet
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate and open an Excel file
            Workbook book = new Workbook(sourceDir + "sampleGenerateThumbnailOfWorksheet.xlsx");

            // Define ImageOrPrintOptions
            ImageOrPrintOptions imgOptions = new ImageOrPrintOptions();

            // Specify the image format
            imgOptions.ImageType = Drawing.ImageType.Jpeg;
            
            // Set the vertical and horizontal resolution
            imgOptions.VerticalResolution = 200;
            imgOptions.HorizontalResolution = 200;
            
            // One page per sheet is enabled
            imgOptions.OnePagePerSheet = true;

            // Get the first worksheet
            Worksheet sheet = book.Worksheets[0];
            
            // Render the sheet with respect to specified image/print options
            SheetRender sr = new SheetRender(sheet, imgOptions);
            
            // Render the image for the sheet
            Bitmap bmp = sr.ToImage(0);
            
            // Create a bitmap
            Bitmap thumb = new Bitmap(600, 600);
            
            // Get the graphics for the bitmap
            System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(thumb);

            if (bmp != null)
            {
                // Draw the image
                gr.DrawImage(bmp, 0, 0, 600, 600);
            }
            
            // Save the thumbnail
            thumb.Save(outputDir + "outputGenerateThumbnailOfWorksheet.bmp");

            Console.WriteLine("GenerateThumbnailOfWorksheet executed successfully.\r\n");
        }
    }
}
