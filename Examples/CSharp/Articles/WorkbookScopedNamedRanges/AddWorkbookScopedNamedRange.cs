using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkbookScopedNamedRanges
{
    public class AddWorkbookScopedNamedRange
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create a new Workbook object
            Workbook workbook = new Workbook(sourceDir + "sampleAddWorkbookScopedNamedRange.xlsx");

            // Get first worksheet of the workbook
            Worksheet sheet = workbook.Worksheets[0];

            // Get worksheet's cells collection
            Cells cells = sheet.Cells;

            // Create a range of Cells from Cell A1 to C10
            Range workbookScope = cells.CreateRange("A1", "C10");

            // Assign the nsame to workbook scope named range
            workbookScope.Name = "workbookScope";

            // Save the workbook
            workbook.Save(outputDir + "outputAddWorkbookScopedNamedRange.xlsx");

            Console.WriteLine("AddWorkbookScopedNamedRange executed successfully.");
        }
    }
}
