using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.Articles.ConvertingWorksheetToImage
{
    public class ConvertWorksheetToImageByPage
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook book = new Workbook(sourceDir + "sampleConvertWorksheetToImageByPage.xlsx");

            Worksheet sheet = book.Worksheets[0];

            Aspose.Cells.Rendering.ImageOrPrintOptions options = new Aspose.Cells.Rendering.ImageOrPrintOptions();
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;
            options.ImageType = Drawing.ImageType.Tiff;

            // Sheet2Image By Page conversion
            SheetRender sr = new SheetRender(sheet, options);
            for (int j = 0; j < sr.PageCount; j++)
            {
                sr.ToImage(j, outputDir + "outputConvertWorksheetToImageByPage_" + (j + 1) + ".tif");
            }

            Console.WriteLine("ConvertWorksheetToImageByPage executed successfully.");

        }
    }
}
