using System;
using System.Collections.Generic;
using System.Text; using Aspose.Cells;

namespace _01._03_FormulaCalculationEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiating a Workbook object
            Workbook book = new Workbook();

            //Obtaining the reference of the newly added worksheet
            int sheetIndex = book.Worksheets.Add();
            Worksheet worksheet = book.Worksheets[sheetIndex];
            Cells cells = worksheet.Cells;
            Cell cell = null;

            //Adding a value to "A1" cell
            cell = cells["A1"];
            cell.Value = 1;

            //Adding a value to "A2" cell
            cell = cells["A2"];
            cell.Value = 2;

            //Adding a value to "A3" cell
            cell = cells["A3"];
            cell.Value = 3;

            //Adding a SUM formula to "A4" cell
            cell = cells["A4"];
            cell.Formula = "=SUM(A1:A3)";

            //Calculating the results of formulas
            book.CalculateFormula();

            //Saving the Excel file
            book.Save("AsposeFormulaEngine.xls");
        }
    }
}
