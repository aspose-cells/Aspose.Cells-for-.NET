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
            string docName = "Merge two adjacent cells.xlsx";
            string sheetName = "Sheet2";
            string cell1Name = "A2";
            string cell2Name = "B2";
            MergeTwoCells(docName, sheetName, cell1Name, cell2Name);
        }

        private static void MergeTwoCells(string docName, string sheetName, string cell1Name, string cell2Name)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook(docName);

            //Obtaining the reference of the worksheet by passing its Name
            Worksheet worksheet = workbook.Worksheets[sheetName];

            //Get the range of cells i.e.., A1:C1.
            Range range = worksheet.Cells.CreateRange(cell1Name,cell2Name);

            //Merge the cells.
            range.Merge();

            //Saving the Excel file
            workbook.Save(docName);
        }
    }
}
