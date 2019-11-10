using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class SetBackgroundPicture
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            // Get the first worksheet.
            Worksheet sheet = workbook.Worksheets[0];

            // Set the background image for the sheet.
            sheet.BackgroundImage = File.ReadAllBytes(sourceDir + "background.jpg");

            // Save the Excel file
            workbook.Save(outputDir + "outputBackImageSheet.xlsx");

            // Save the HTML file
            workbook.Save(outputDir + "outputBackImageSheet.html", SaveFormat.Html);
            // ExEnd:1

            Console.WriteLine("SetBackgroundPicture executed successfully.");
        }
    }
}