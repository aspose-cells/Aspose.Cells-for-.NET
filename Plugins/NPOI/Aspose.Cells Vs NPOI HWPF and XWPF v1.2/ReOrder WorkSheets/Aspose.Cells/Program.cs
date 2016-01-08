using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new Workbook.
            Workbook workbook = new Workbook();

            WorksheetCollection worksheets = workbook.Worksheets;
            Worksheet worksheet1 = worksheets[0];
            Worksheet worksheet2 = worksheets.Add("Sheet2");
            Worksheet worksheet3 = worksheets.Add("Sheet3");

            //Move Sheets with in Workbook.
            worksheet2.MoveTo(0);
            worksheet1.MoveTo(1);
            worksheet3.MoveTo(2);

            //Save the excel file.
            workbook.Save("../../data/AsposeMoveSheet.xls");
        }
    }
}
