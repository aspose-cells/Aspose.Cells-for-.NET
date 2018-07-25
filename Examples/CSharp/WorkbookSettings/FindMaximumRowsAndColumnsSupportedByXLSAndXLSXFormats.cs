using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.WorkbookSettings
{
    class FindMaximumRowsAndColumnsSupportedByXLSAndXLSXFormats
    {
        public static void Main()
        {
            // Print message about XLS format.
            Console.WriteLine("Maximum Rows and Columns supported by XLS format.");

            // Create workbook in XLS format.
            Workbook wb = new Workbook(FileFormatType.Excel97To2003);

            // Print the maximum rows and columns supported by XLS format.
            int maxRows = wb.Settings.MaxRow + 1;
            int maxCols = wb.Settings.MaxColumn + 1;
            Console.WriteLine("Maximum Rows: " + maxRows);
            Console.WriteLine("Maximum Columns: " + maxCols);
            Console.WriteLine();

            // Print message about XLSX format.
            Console.WriteLine("Maximum Rows and Columns supported by XLSX format.");

            // Create workbook in XLSX format.
            wb = new Workbook(FileFormatType.Xlsx);

            // Print the maximum rows and columns supported by XLSX format.
            maxRows = wb.Settings.MaxRow + 1;
            maxCols = wb.Settings.MaxColumn + 1;
            Console.WriteLine("Maximum Rows: " + maxRows);
            Console.WriteLine("Maximum Columns: " + maxCols);

            Console.WriteLine("FindMaximumRowsAndColumnsSupportedByXLSAndXLSXFormats executed successfully.");
        }
    }
}
