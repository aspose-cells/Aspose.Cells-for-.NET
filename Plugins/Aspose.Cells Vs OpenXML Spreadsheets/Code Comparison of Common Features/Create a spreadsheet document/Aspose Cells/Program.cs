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
            CreateSpreadsheetWorkbook("Create a spreadsheet document.xlsx");
        }

        private static void CreateSpreadsheetWorkbook(string filepath)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Excel object
            Worksheet worksheet = workbook.Worksheets.Add("MySheet");

            //Saving the Excel file
            workbook.Save(filepath);
        }
    }
}
