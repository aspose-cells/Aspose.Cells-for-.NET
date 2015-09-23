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
            string docName = "Get a column heading.xlsx";
            string worksheetName = "Sheet1";
            string cellName = "B2";
            string s1 = GetColumnHeading(docName, worksheetName, cellName);
        }

        private static string GetColumnHeading(string docName, string worksheetName, string cellName)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook(docName);

            //Obtaining the reference of the worksheet by passing its Name
            Worksheet worksheet = workbook.Worksheets[worksheetName];

            //Removing value from cell
            Cell Cell = worksheet.Cells[cellName];

            //Get First row of the column
            string ColumnHeadingName = CellsHelper.CellIndexToName(0, Cell.Column);

            //return value of heading cell
            return worksheet.Cells[ColumnHeadingName].Value.ToString();
        }
    }
}
