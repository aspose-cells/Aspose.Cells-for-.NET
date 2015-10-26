using System;
using System.Collections.Generic;
using System.Text; using Aspose.Cells;

namespace _01._02_CalculateSubTotals
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook("../../data/test.xlsx");

            //Get the Cells collection in the first worksheet
            Cells cells = workbook.Worksheets[0].Cells;

            //Create a cellarea i.e.., B3:C19
            CellArea ca = new CellArea();
            ca.StartRow = 2;
            ca.StartColumn = 1;
            ca.EndRow = 18;
            ca.EndColumn = 2;

            //Apply subtotal, the consolidation function is Sum and it will applied to
            //Second column (C) in the list
            cells.Subtotal(ca, 0, ConsolidationFunction.Sum, new int[] { 1 });

            //Save the excel file
            workbook.Save("AsposeTotal.xls");            
        }
    }
}
