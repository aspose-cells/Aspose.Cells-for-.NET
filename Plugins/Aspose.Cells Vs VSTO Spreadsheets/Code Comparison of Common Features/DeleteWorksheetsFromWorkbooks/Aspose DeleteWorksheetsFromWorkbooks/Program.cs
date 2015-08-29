using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose_DeleteWorksheetsFromWorkbooks
{
    class Program
    {
        private static string fileName = @"E:\Aspose\Aspose Vs VSTO\Aspose.Cells Vs VSTO Cells v 1.1\Sample Files\DeleteWorksheetsFromWorkbooks.xlsx";
        static void Main(string[] args)
        {
            Workbook myWorkbook = new Workbook(fileName);
            myWorkbook.Worksheets.RemoveAt(1);

            myWorkbook.Save(fileName);
        }
    }
}
