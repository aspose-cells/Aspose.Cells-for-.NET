using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose_OpenTextFilesAsWorkbooks
{
    class Program
    {
        private static string fileName = @"E:\Aspose\Aspose Vs VSTO\Aspose.Cells Vs VSTO Cells v 1.1\Sample Files\OpenTextFilesAsWorkbooks.xlsx";
        private static string TextFile = @"E:\Aspose\Aspose Vs VSTO\Aspose.Cells Vs VSTO Cells v 1.1\Sample Files\OpenTextFilesAsWorkbooks.txt";
        static void Main(string[] args)
        {
            LoadOptions loadOptions = new LoadOptions(LoadFormat.CSV);
            Workbook newWorkbook = new Workbook(TextFile, loadOptions);

            newWorkbook.Save(fileName);
        }
    }
}
