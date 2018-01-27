using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkbookScopedNamedRanges
{
    public class WorksheetNamedRange
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create a new Workbook object
            Workbook workbook = new Workbook();

            // Get first worksheet of the workbook
            Worksheet sheet = workbook.Worksheets[0];

            // Get worksheet's cells collection
            Cells cells = sheet.Cells;
            // Create a range of Cells
            Range localRange = cells.CreateRange("A1", "C10");

            // Assign name to range with sheet raference
            localRange.Name = "Sheet1!local";

            // Save the workbook
            workbook.Save(outputDir + "outputWorksheetNamedRange.xlsx");

            Console.WriteLine("WorksheetNamedRange executed successfully.");
        }
    }
}
