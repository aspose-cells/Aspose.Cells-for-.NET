using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class SettingSubscriptEffect
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[0];

            // Accessing the "A1" cell from the worksheet
            Cell cell = worksheet.Cells["A1"];

            // Adding some value to the "A1" cell
            cell.PutValue("Hello");

            // Setting the font Subscript
            Style style = cell.GetStyle();
            style.Font.IsSubscript = true;
            cell.SetStyle(style);

            // Saving the Excel file
            workbook.Save(outputDir + "outputSettingSubscriptEffect.xlsx");

            Console.WriteLine("SettingSubscriptEffect executed successfully.\r\n");
        }
    }
}
