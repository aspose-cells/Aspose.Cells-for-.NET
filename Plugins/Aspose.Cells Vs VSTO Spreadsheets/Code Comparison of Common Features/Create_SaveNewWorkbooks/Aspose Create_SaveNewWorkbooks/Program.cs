using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose_Create_SaveNewWorkbooks
{
    class Program
    {
        private static string fileName = @"E:\Aspose\Aspose Vs VSTO\Aspose.Cells Vs VSTO Cells v 1.1\Sample Files\Aspose_Create_SaveNewWorkbooks.xlsx";
        static void Main(string[] args)
        {
            Workbook newWorkbook = new Workbook();

            Worksheet worksheet = newWorkbook.Worksheets.Add("New Sheet");
            Cells cells = worksheet.Cells;
            cells[0,0].PutValue("Some Text");

            newWorkbook.Save(fileName);
        }
    }
}
