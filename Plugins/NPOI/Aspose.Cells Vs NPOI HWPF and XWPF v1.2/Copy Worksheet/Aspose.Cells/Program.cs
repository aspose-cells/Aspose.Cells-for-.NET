using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aspose.Cells
{
    class Program
    {
        static void Main(string[] args)
        {            
            //Create a new Workbook by excel file path
            Workbook wb = new Workbook("../../data/workbook.xlsx");

            //Create a Worksheets object with reference to the sheets of the Workbook.
            WorksheetCollection sheets = wb.Worksheets;

            //Copy data to a new sheet from an existing sheet within the Workbook.
            sheets.AddCopy("Sheet1");
            wb.Save("../../data/workbook.xlsx");
        }
    }
}
