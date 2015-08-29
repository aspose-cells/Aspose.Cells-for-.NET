using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose_DisplayStringInCell
{
    class Program
    {
        private static string fileName = @"E:\Aspose\Aspose Vs VSTO\Aspose.Cells Vs VSTO Cells v 1.1\Sample Files\DisplayStringInCell.xlsx";
        static void Main(string[] args)
        {
            Workbook myWorkbook = new Workbook(fileName);
            Worksheet mySheet = myWorkbook.Worksheets[myWorkbook.Worksheets.ActiveSheetIndex];

            Cells cells = mySheet.Cells;
            cells[0, 0].PutValue("Some Text");

            myWorkbook.Save(fileName);
        }
    }
}
