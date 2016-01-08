// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Move_Worksheet
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyDir = @"Files\";
            //Create a new Workbook.
            //Open an existing excel file.
            Workbook wb = new Workbook(MyDir + "WorkBook Operations.xls");

            //Create a Worksheets object with reference to
            //the sheets of the Workbook.
            WorksheetCollection sheets = wb.Worksheets;

            //Get the first worksheet.
            Worksheet worksheet = sheets[0];
            string test = worksheet.Name;
            //Move the first sheet to the third position in the workbook.
            worksheet.MoveTo(2);

            //Save the excel file.
            wb.Save(MyDir + "Move worksheets within workbook.xls");

        }
    }
}
