using System.IO;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using System;
namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class AddImageHyperlinks
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate a new workbook
            Workbook workbook = new Workbook();

            // Get the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Insert a string value to a cell
            worksheet.Cells["C2"].PutValue("Image Hyperlink");

            // Set the 4th row height
            worksheet.Cells.SetRowHeight(3, 100);

            // Set the C column width
            worksheet.Cells.SetColumnWidth(2, 21);

            // Add a picture to the C4 cell
            int index = worksheet.Pictures.Add(3, 2, 4, 3, sourceDir + "sampleAddImageHyperlinks.jpg");

            // Get the picture object
            Aspose.Cells.Drawing.Picture pic = worksheet.Pictures[index];

            // Set the placement type
            pic.Placement = PlacementType.FreeFloating;

            // Add an image hyperlink
            Aspose.Cells.Hyperlink hlink = pic.AddHyperlink("https://www.aspose.com");

            // Specify the screen tip
            hlink.ScreenTip = "Click to go to Aspose site";
            
            // Save the Excel file
            workbook.Save(outputDir + "outputAddImageHyperlinks.xlsx");

            Console.WriteLine("AddImageHyperlinks executed successfully.\r\n");
        }
    }
}
