using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets.Value
{
    public class CopyWithinWorkbook
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string InputPath = dataDir + "book1.xls";

            // Create a new Workbook.
            // Open an existing Excel file.
            Workbook wb = new Workbook(InputPath);

            // Create a Worksheets object with reference to
            // the sheets of the Workbook.
            WorksheetCollection sheets = wb.Worksheets;

            // Copy data to a new sheet from an existing
            // sheet within the Workbook.
            sheets.AddCopy("Sheet1");

            // Save the Excel file.
            wb.Save(dataDir + "CopyWithinWorkbook_out.xls");
            // ExEnd:1
        }
    }
}
