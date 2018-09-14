using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class WorksheetToImageUsingTiffCompression
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate a new Workbook object with template
            Workbook book = new Workbook(sourceDir + "sampleWorksheetToImageUsingTiffCompression.xlsx");

            // Get the first worksheet
            Worksheet sheet = book.Worksheets[0];

            // Apply different Image and Print options
            Aspose.Cells.Rendering.ImageOrPrintOptions options = new Aspose.Cells.Rendering.ImageOrPrintOptions();

            // Set Horizontal Resolution
            options.HorizontalResolution = 300;

            // Set Vertical Resolution
            options.VerticalResolution = 300;

            // Set TiffCompression
            options.TiffCompression = Aspose.Cells.Rendering.TiffCompression.CompressionLZW;

            // Set Autofit options
            options.IsCellAutoFit = false;

            // Set Image Format
            options.ImageType = Drawing.ImageType.Tiff;

            // Set printing page type
            options.PrintingPage = PrintingPageType.Default;

            // Render the sheet with respect to specified image/print options
            SheetRender sr = new SheetRender(sheet, options);

            // Render/save the image for the sheet
            int pageIndex = 3;
            sr.ToImage(pageIndex, outputDir + @"outputWorksheetToImageUsingTiffCompression_Page4.tiff");

            Console.WriteLine("WorksheetToImageUsingTiffCompression executed successfully.");
        }
    }
}
