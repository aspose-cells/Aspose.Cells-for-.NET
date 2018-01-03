using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class GetIconSetsDataBars
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open a template Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleGetIconSetsDataBars.xlsx");

            // Get the first worksheet in the workbook
            Worksheet sheet = workbook.Worksheets[0];

            // Get the A1 cell
            Cell cell = sheet.Cells["A1"];

            // Get the conditional formatting result object
            ConditionalFormattingResult cfr = cell.GetConditionalFormattingResult();

            // Get the icon set
            ConditionalFormattingIcon icon = cfr.ConditionalFormattingIcon;

            // Create the image file based on the icon's image data
            File.WriteAllBytes(outputDir + "outputGetIconSetsDataBars.jpg", icon.ImageData);

            Console.WriteLine("GetIconSetsDataBars executed successfully.\r\n");
        }
    }
}
