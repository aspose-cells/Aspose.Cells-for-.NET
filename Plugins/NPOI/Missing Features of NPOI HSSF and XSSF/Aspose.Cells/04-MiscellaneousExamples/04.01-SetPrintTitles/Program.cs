using System;
using System.Collections.Generic;
using System.Text; using Aspose.Cells;

namespace _04._01_SetPrintTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook("../../data/test.xlsx");

            //Obtaining the reference of the PageSetup of the worksheet
            PageSetup pageSetup = workbook.Worksheets[0].PageSetup;

            //Defining column numbers A & B as title columns
            pageSetup.PrintTitleColumns = "$A:$B";

            //Defining row numbers 1 & 2 as title rows
            pageSetup.PrintTitleRows= "$1:$2";
        }
    }
}
