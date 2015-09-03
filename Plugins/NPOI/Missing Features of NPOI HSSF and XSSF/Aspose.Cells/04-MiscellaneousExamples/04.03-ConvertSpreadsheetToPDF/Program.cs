using System;
using System.Collections.Generic;
using System.Text; using Aspose.Cells;

namespace _04._03_ConvertSpreadsheetToPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            Workbook workbook = new Workbook("../../data/test.xlsx");

            //Save the document in PDF format
            workbook.Save("AsposeConvert.pdf", SaveFormat.Pdf);
        }
    }
}
