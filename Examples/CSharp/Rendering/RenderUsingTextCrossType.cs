using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Cells.Rendering;
using System.IO;
using System.Drawing.Imaging;

namespace Aspose.Cells.Examples.CSharp.Rendering
{
    class RenderUsingTextCrossType
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();
        public static void Main()
        {
            // ExStart:1

            // Load template Excel file
            Workbook wb = new Workbook(sourceDir + "sampleCrossType.xlsx");

            // Create file streams for saving the PDF and PNG files
            using (FileStream outputStream = new FileStream(outputDir + "outputCrossType.pdf", FileMode.Create))
            using (FileStream outputStream2 = new FileStream(outputDir + "outputCrossType.png", FileMode.Create))
            {
                // Initialize PDF save options
                PdfSaveOptions saveOptions = new PdfSaveOptions();

                // Set text cross type
                saveOptions.TextCrossType = TextCrossType.StrictInCell;

                // Save PDF file
                wb.Save(outputStream, saveOptions);

                // Initialize image or print options
                ImageOrPrintOptions imageSaveOptions = new ImageOrPrintOptions();

                // Set text cross type
                imageSaveOptions.TextCrossType = TextCrossType.StrictInCell;

                // Initialize sheet renderer object
                SheetRender sheetRenderer = new SheetRender(wb.Worksheets[0], imageSaveOptions);

                // Create bitmap image from sheet renderer
                System.Drawing.Bitmap bitmap = sheetRenderer.ToImage(0);

                // Save PNG image
                bitmap.Save(outputStream2, ImageFormat.Png);
            }
            // ExEnd:1
            Console.WriteLine("RenderUsingTextCrossType executed successfully.\r\n");
        }
    }
}
