// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Worksheet
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyDir = @"Files\";
            //Create a new Workbook.
            //Open an existing Excel file.
            Workbook wb = new Workbook(MyDir + "ResultedBook.xls");

            //Create a Worksheets object with reference to
            //the sheets of the Workbook.
            WorksheetCollection sheets = wb.Worksheets;

            //Copy data to a new sheet from an existing
            //sheet within the Workbook.
            sheets.AddCopy("MySheet");

            //Save the Excel file.
            wb.Save(MyDir + "Copy Worksheet.xls");
        }
    }
}
