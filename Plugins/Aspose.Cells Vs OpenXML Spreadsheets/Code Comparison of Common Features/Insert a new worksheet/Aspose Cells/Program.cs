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
            string docName = "Insert a new worksheet.xlsx";
            InsertWorksheet(docName);
        }

        private static void InsertWorksheet(string docName)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook(docName);

            //Adding a new worksheet to the Excel object
            int SheetIndex = workbook.Worksheets.Add();

            //Saving the Excel file
            workbook.Save(docName);
        }
    }
}
