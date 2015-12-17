// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet_btw_Workbok
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyDir = @"Files\";
            //Create a new Workbook.
            Workbook excelWorkbook0 = new Workbook();

            //Get the first worksheet in the book.
            Worksheet ws0 = excelWorkbook0.Worksheets[0];

            //Put some data into header rows (A1:A4)
            for (int i = 0; i < 5; i++)
            {
                ws0.Cells[i, 0].PutValue(string.Format("Header Row {0}", i));
            }

            //Put some detail data (A5:A999)
            for (int i = 5; i < 1000; i++)
            {
                ws0.Cells[i, 0].PutValue(string.Format("Detail Row {0}", i));
            }

            //Define a pagesetup object based on the first worksheet.
            PageSetup pagesetup = ws0.PageSetup;

            //The first five rows are repeated in each page...
            //It can be seen in print preview.
            pagesetup.PrintTitleRows = "$1:$5";

            //Create another Workbook.
            Workbook excelWorkbook1 = new Workbook();

            //Get the first worksheet in the book.
            Worksheet ws1 = excelWorkbook1.Worksheets[0];

            //Name the worksheet.
            ws1.Name = "MySheet";

            //Copy data from the first worksheet of the first workbook into the
            //first worksheet of the second workbook.
            ws1.Copy(ws0);

            //Save the excel file.
            excelWorkbook1.Save(MyDir + "copyworksheet.xls");

        }
    }
}
