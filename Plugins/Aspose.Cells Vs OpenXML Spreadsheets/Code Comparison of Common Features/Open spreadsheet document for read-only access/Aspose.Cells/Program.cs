using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileName = @"E:\Aspose\Aspose Vs OpenXML\Aspose.Cells Vs OpenXML Spreadsheet v 1.1\SampleFiles\Open a spreadsheet document for read-only access.xlsx";
            OpenSpreadsheetDocumentReadonly(FileName);
        }
        public static void OpenSpreadsheetDocumentReadonly(string filepath)
        {
            // Open a SpreadsheetDocument based on a filepath.
            Workbook workbook = new Workbook(filepath);
        }
    }
}
