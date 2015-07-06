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
            string docName = "Delete text from a cell.xlsx";
            string sheetName = "Sheet4";
            string colName = "B";
            uint rowIndex = 2;
            DeleteTextFromCell(docName, sheetName, colName, rowIndex);
        }

        private static void DeleteTextFromCell(string docName, string sheetName, string colName, uint rowIndex)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook(docName);

            //Obtaining the reference of the worksheet by passing its Name
            Worksheet worksheet = workbook.Worksheets[sheetName];

            //Removing value from cell
            worksheet.Cells[colName + rowIndex].PutValue("");

            //Saving the Excel file
            workbook.Save(docName);
        }
    }
}
