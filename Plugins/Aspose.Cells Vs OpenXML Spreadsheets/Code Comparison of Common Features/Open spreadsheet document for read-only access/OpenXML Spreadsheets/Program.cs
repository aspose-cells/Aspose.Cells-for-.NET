using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXML_Spreadsheets
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
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filepath, false))
            {
                // Attempt to add a new WorksheetPart.
                // The call to AddNewPart generates an exception because the file is read-only.
                WorksheetPart newWorksheetPart = spreadsheetDocument.WorkbookPart.AddNewPart<WorksheetPart>();

                // The rest of the code will not be called.
            }
        }
    }
}
