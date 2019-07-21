using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class FindCellsContainingFormula
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Run()
        {
            // ExStart:1
            // Opening the Excel file through the file stream
            Workbook workbook = new Workbook(sourceDir + "sampleFindCellsContainingFormula.xlsx");

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            // Instantiate FindOptions Object
            FindOptions findOptions = new FindOptions();
            findOptions.LookInType = LookInType.Formulas;

            // Finding the cell containing the specified formula
            Cell cell = worksheet.Cells.Find("=SUM(A1:A20)", null, findOptions);

            // Printing the name of the cell found after searching worksheet
            Console.WriteLine("Name of the cell containing formula: " + cell.Name);

            // ExEnd:1
            Console.WriteLine("FindCellsContainingFormula executed successfully.");
        }
    }
}
