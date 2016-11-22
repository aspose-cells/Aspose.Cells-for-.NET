using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets.Value
{
    public class MoveWorksheet
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string InputPath = dataDir + "book1.xls";

            // Open an existing excel file.
            Workbook wb = new Workbook(InputPath);

            // Create a Worksheets object with reference to
            // the sheets of the Workbook.
            WorksheetCollection sheets = wb.Worksheets;

            // Get the first worksheet.
            Worksheet worksheet = sheets[0];

            // Move the first sheet to the third position in the workbook.
            worksheet.MoveTo(2);

            // Save the excel file.
            wb.Save(dataDir + "MoveWorksheet_out.xls");
            // ExEnd:1
        }
    }
}
