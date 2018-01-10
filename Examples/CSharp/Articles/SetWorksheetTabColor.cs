using System;
using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class SetWorksheetTabColor
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open an Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleSetWorksheetTabColor.xlsx");

            // Get the first worksheet in the book
            Worksheet worksheet = workbook.Worksheets[0];

            // Set the tab color
            worksheet.TabColor = Color.Red;

            // Save the Excel file
            workbook.Save(outputDir + "outputSetWorksheetTabColor.xlsx");

            Console.WriteLine("SetWorksheetTabColor executed successfully.");
        }
    }
}