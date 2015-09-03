using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose_CopyWorksheets
{
    class Program
    {
        private static string fileName = @"E:\Aspose\Aspose Vs VSTO\Aspose.Cells Vs VSTO Cells v 1.1\Sample Files\CopyWorksheets.xlsx";
        static void Main(string[] args)
        {
            Workbook newWorkbook = new Workbook();

            Worksheet worksheet = newWorkbook.Worksheets.Add("New Sheet");
            Cells cells = worksheet.Cells;
            cells[0, 0].PutValue("Some Text");

            Worksheet worksheet2 = newWorkbook.Worksheets.Add("MySheet");
            worksheet2.Copy(worksheet);

            newWorkbook.Save(fileName);
        }
    }
}
