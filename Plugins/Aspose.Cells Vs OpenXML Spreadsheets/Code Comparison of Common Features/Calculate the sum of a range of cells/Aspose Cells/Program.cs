// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Aspose_Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            string docName = "Calculate the sum of a range of cells.xlsx";
            string worksheetName = "Sheet1";
            string firstCellName = "A1";
            string lastCellName = "A3";
            string resultCell = "A4";
            CalculateSumOfCellRange(docName, worksheetName, firstCellName, lastCellName, resultCell);
        }

        private static void CalculateSumOfCellRange(string docName, string worksheetName, string firstCellName, string lastCellName, string resultCell)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook(docName);

            //Obtaining the reference of the worksheet by passing its Name
            Worksheet worksheet = workbook.Worksheets[worksheetName];

            //Adding a SUM formula to "A4" cell
            worksheet.Cells[resultCell].Formula = "=SUM(" + firstCellName + ":" + lastCellName + ")"; // =SUM(A1:A3)

            //Calculating the results of formulas
            workbook.CalculateFormula();

            //Get the calculated value of the cell
            string value = worksheet.Cells["A4"].Value.ToString();

            //Saving the Excel file
            workbook.Save(docName);
        }
    }
}
