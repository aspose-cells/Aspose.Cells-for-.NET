using System;
using System.IO;
using System.Drawing;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class AddingLinkToURL2
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            Workbook workbook = new Workbook();
            
            Worksheet worksheet = workbook.Worksheets[0];

            // Putting a value to the "A1" cell
            worksheet.Cells["A1"].PutValue("Visit Aspose");

            // Setting the font color of the cell to Blue
            worksheet.Cells["A1"].GetStyle().Font.Color = Color.Blue;

            // Setting the font of the cell to Single Underline
            worksheet.Cells["A1"].GetStyle().Font.Underline = FontUnderlineType.Single;

            // Adding a hyperlink to a URL at "A1" cell
            worksheet.Hyperlinks.Add("A1", 1, 1, "https://www.aspose.com");

            // Saving the Excel file
            workbook.Save(outputDir + "outputAddingLinkToURL2.xlsx");

            Console.WriteLine("AddingLinkToURL2 executed successfully.");
        }
    }
}
