using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class AddingLinkToOtherSheetCell
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Adding a new worksheet to the Workbook object
            workbook.Worksheets.Add();

            // Obtaining the reference of the first (default) worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Adding an internal hyperlink to the "B9" cell of the other worksheet "Sheet2" in
            // The same Excel file
            worksheet.Hyperlinks.Add("B3", 1, 1, "Sheet2!B9");
            worksheet.Hyperlinks[0].TextToDisplay = "Link To Other Sheet Cell";

            // Saving the Excel file
            workbook.Save(outputDir + "outputAddingLinkToOtherSheetCell.xlsx");

            Console.WriteLine("AddingLinkToOtherSheetCell executed successfully.");
        }
    }
}
