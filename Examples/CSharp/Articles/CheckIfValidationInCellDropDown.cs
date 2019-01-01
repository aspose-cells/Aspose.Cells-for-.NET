using System.IO;
using System;
using Aspose.Cells;
namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class CheckIfValidationInCellDropDown
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();
        public static void Main()
        {
            // ExStart:DataValidationRules
            Workbook book = new Workbook(sourceDir + "sampleValidation.xlsx");
            Worksheet sheet = book.Worksheets["Sheet1"];
            Cells cells = sheet.Cells;
            Cell a2 = cells["A2"];
            Validation va2 = a2.GetValidation();
            if (va2.InCellDropDown)
            {
                Console.WriteLine("A2 is a dropdown");
            }
            else
            {
                Console.WriteLine("A2 is NOT a dropdown");
            }
            Cell b2 = cells["B2"];
            Validation vb2 = b2.GetValidation();
            if (vb2.InCellDropDown)
            {
                Console.WriteLine("B2 is a dropdown");
            }
            else
            {
                Console.WriteLine("B2 is NOT a dropdown");
            }
            Cell c2 = cells["C2"];
            Validation vc2 = c2.GetValidation();
            if (vc2.InCellDropDown)
            {
                Console.WriteLine("C2 is a dropdown");
            }
            else
            {
                Console.WriteLine("C2 is NOT a dropdown");
            }

            Console.WriteLine("CheckIfValidationInCellDropDown executed successfully.\r\n");
        }
    }
}
