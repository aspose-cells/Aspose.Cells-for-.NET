using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class GetWorksheetUniqueId
    {
        public static void Run()
        {
            // ExStart:1
            // Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Load source Excel file
            Workbook workbook = new Workbook(sourceDir + "Book1.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Print Unique Id
            Console.WriteLine("Unique Id: " + worksheet.UniqueId);
            // ExEnd:1

            Console.WriteLine("GetWorksheetUniqueId executed successfully.");
        }
    }
}
