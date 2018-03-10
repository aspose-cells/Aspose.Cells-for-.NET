using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class AddingLinkToURL
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Obtaining the reference of the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Adding a hyperlink to a URL at "B4" cell
            worksheet.Hyperlinks.Add("B4", 1, 1, "https://www.aspose.com");
            worksheet.Hyperlinks[0].TextToDisplay = "Aspose - File Format APIs";

            // Saving the Excel file
            workbook.Save(outputDir + "outputAddingLinkToURL.xlsx");

            Console.WriteLine("AddingLinkToURL executed successfully.");
        }
    }
}
