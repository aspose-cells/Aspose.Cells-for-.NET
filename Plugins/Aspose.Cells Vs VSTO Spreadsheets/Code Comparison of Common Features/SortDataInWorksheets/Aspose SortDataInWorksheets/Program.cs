using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose_SortDataInWorksheets
{
    class Program
    {
        private static string fileName = @"E:\Aspose\Aspose Vs VSTO\Aspose.Cells Vs VSTO Cells v 1.1\Sample Files\Aspose_SortDataInWorksheet.xlsx";
        static void Main(string[] args)
        {
            Workbook myWorkbook = new Workbook(fileName);
            Worksheet mySheet = myWorkbook.Worksheets[myWorkbook.Worksheets.ActiveSheetIndex];

            DataSorter sorter = myWorkbook.DataSorter;
            sorter.Order1 = Aspose.Cells.SortOrder.Ascending;
            sorter.Key1 = 0;

            sorter.Sort(mySheet.Cells, 0, 0, 10, 0);

            myWorkbook.Save(fileName);

        }
    }
}
