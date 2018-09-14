using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.UsingImageOrPrintOptions
{
    public class SpecificPagesToImage
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open a template excel file
            Workbook book = new Workbook(sourceDir + "sampleSpecificPagesToImages.xlsx");

            // Get the first worksheet.
            Worksheet sheet = book.Worksheets[0];

            // Define ImageOrPrintOptions
            ImageOrPrintOptions imgOptions = new ImageOrPrintOptions();

            // Specify the image format
            imgOptions.ImageType = Drawing.ImageType.Jpeg;

            // Render the sheet with respect to specified image/print options
            SheetRender sr = new SheetRender(sheet, imgOptions);

            //Specify page index to be rendered
            int idxPage = 3;

            // Render the third image for the sheet
            Bitmap bitmap = sr.ToImage(idxPage);

            // Save the image file
            bitmap.Save(outputDir + "outputSpecificPagesToImage_"+ (idxPage+1)+".jpg");

            Console.WriteLine("SpecificPagesToImage executed successfully.");
        }
    }
}
