using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.ConvertingWorksheetToImage
{
    public class ConvertWorksheettoImageFile
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open a template excel file
            Workbook book = new Workbook(sourceDir + "sampleConvertWorksheettoImageFile.xlsx");

            // Get the first worksheet.
            Worksheet sheet = book.Worksheets[0];

            // Define ImageOrPrintOptions
            ImageOrPrintOptions imgOptions = new ImageOrPrintOptions();
            imgOptions.OnePagePerSheet = true;

            // Specify the image format
            imgOptions.ImageType = Drawing.ImageType.Jpeg;
            
            // Render the sheet with respect to specified image/print options
            SheetRender sr = new SheetRender(sheet, imgOptions);
            
            // Render the image for the sheet
            Bitmap bitmap = sr.ToImage(0);

            // Save the image file
            bitmap.Save(outputDir + "outputConvertWorksheettoImageFile.jpg");

            Console.WriteLine("ConvertWorksheettoImageFile executed successfully.");
        }
    }
}
