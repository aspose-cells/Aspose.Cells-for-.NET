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
            InsertText("Insert text into a cell.xlsx", "Inserted Text");
        }

        private static void InsertText(string docName, string text)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook(docName);

            //Obtaining the reference of the Active worksheet
            Worksheet worksheet = workbook.Worksheets[workbook.Worksheets.ActiveSheetIndex];

            //insert value from cell
            worksheet.Cells["A1"].PutValue(text);

            //Saving the Excel file
            workbook.Save(docName);
        }
    }
}
