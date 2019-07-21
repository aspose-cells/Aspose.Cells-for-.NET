using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class FindDataOrFormulas
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Run()
        {
            // ExStart:1
            // Instantiate the workbook object
            Workbook workbook = new Workbook(sourceDir + "sampleFindDataOrFormulas.xlsx");

            workbook.CalculateFormula();

            // Get Cells collection
            Cells cells = workbook.Worksheets[0].Cells;

            // Instantiate FindOptions Object
            FindOptions findOptions = new FindOptions();

            // Create a Cells Area
            CellArea ca = new CellArea();
            ca.StartRow = 8;
            ca.StartColumn = 2;
            ca.EndRow = 17;
            ca.EndColumn = 13;

            // Set cells area for find options
            findOptions.SetRange(ca);

            // Set searching properties
            findOptions.SearchBackward = false;
            findOptions.SeachOrderByRows = true;

            // Set the lookintype, you may specify, values, formulas, comments etc.
            findOptions.LookInType = LookInType.Values;

            // Set the lookattype, you may specify Match entire content, endswith, starwith etc.
            findOptions.LookAtType = LookAtType.EntireContent;

            // Find the cell with value
            Cell cell = cells.Find(276, null, findOptions);

            if (cell != null)
            {
                Console.WriteLine("Name of the cell containing the value: " + cell.Name);
            }
            else
            {
                Console.WriteLine("Record not found ");
            }
            // ExEnd:1

            Console.WriteLine("FindDataOrFormulas executed successfully.");
        }
    }
}
