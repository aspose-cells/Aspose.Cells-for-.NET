using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithCalculationEngine
{
    public class UsingFormulaTextFunction
    {
        public static void Run()
        {
            // ExStart:UsingFormulaTextFunction
            // Create a workbook object
            Workbook workbook = new Workbook();

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Put some formula in cell A1
            Cell cellA1 = worksheet.Cells["A1"];
            cellA1.Formula = "=Sum(B1:B10)";

            // Get the text of the formula in cell A2 using FORMULATEXT function
            Cell cellA2 = worksheet.Cells["A2"];
            cellA2.Formula = "=FormulaText(A1)";

            // Calculate the workbook
            workbook.CalculateFormula();

            // Print the results of A2, It will now print the text of the formula inside cell A1
            Console.WriteLine(cellA2.StringValue);
            // ExEnd:UsingFormulaTextFunction
        }
    }
}
