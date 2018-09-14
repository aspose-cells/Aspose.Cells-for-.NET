using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class RemoveWhitespaceAroundData
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open the template file
            Workbook book = new Workbook(sourceDir + "sampleRemoveWhitespaceAroundData.xlsx");

            // Get the first worksheet
            Worksheet sheet = book.Worksheets[0];

            // Specify your print area if you want
            // Sheet.PageSetup.PrintArea = "A1:H8";

            // To remove the white border around the image.
            sheet.PageSetup.LeftMargin = 0;
            sheet.PageSetup.RightMargin = 0;
            sheet.PageSetup.BottomMargin = 0;
            sheet.PageSetup.TopMargin = 0;

            // Define ImageOrPrintOptions
            ImageOrPrintOptions imgOptions = new ImageOrPrintOptions();
            imgOptions.ImageType = Drawing.ImageType.Emf;

            // Set only one page would be rendered for the image
            imgOptions.OnePagePerSheet = true;
            imgOptions.PrintingPage = PrintingPageType.IgnoreBlank;

            // Create the SheetRender object based on the sheet with its
            // ImageOrPrintOptions attributes
            SheetRender sr = new SheetRender(sheet, imgOptions);
            
            // Convert the image
            sr.ToImage(0, outputDir + "outputRemoveWhitespaceAroundData.emf");

            Console.WriteLine("RemoveWhitespaceAroundData executed successfully.");
        }
    }
}