using System.IO;
using System;
using Aspose.Cells;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ExtractImagesFromWorksheets
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open a template Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleExtractImagesFromWorksheets.xlsx");

            // Get the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Get the first Picture in the first worksheet
            Aspose.Cells.Drawing.Picture pic = worksheet.Pictures[0];

            // Set the output image file path
            string picformat = pic.ImageType.ToString();
            
            // Note: you may evaluate the image format before specifying the image path
            // Define ImageOrPrintOptions
            ImageOrPrintOptions printoption = new ImageOrPrintOptions();

            // Specify the image format
            printoption.ImageType = Drawing.ImageType.Jpeg;
            
            // Save the image
            pic.ToImage(outputDir + "outputExtractImagesFromWorksheets.jpg", printoption);

            Console.WriteLine("ExtractImagesFromWorksheets executed successfully.\r\n");
        }
    }
}
