// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_btw_Workboks
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyDir = @"Files\";
            //Create a Workbook.
            //Open a file into the first book.
            Workbook excelWorkbook0 = new Workbook(MyDir + "WorkBook Operations.xls");

            //Create another Workbook.
            Workbook excelWorkbook1 = new Workbook();

            //Copy the first sheet of the first book into second book.
            excelWorkbook1.Worksheets[0].Copy(excelWorkbook0.Worksheets[0]);

            //Save the file.
            excelWorkbook1.Save(MyDir + "ResultedBook.xls");
        }
    }
}
