using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets.Value
{
    public class CopyWorksheetsBetweenWorkbooks
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string InputPath = dataDir + "book1.xls";

            // Create a Workbook.
            // Open a file into the first book.
            Workbook excelWorkbook0 = new Workbook(InputPath);

            // Create another Workbook.
            Workbook excelWorkbook1 = new Workbook();

            // Copy the first sheet of the first book into second book.
            excelWorkbook1.Worksheets[0].Copy(excelWorkbook0.Worksheets[0]);

            // Save the file.
            excelWorkbook1.Save(dataDir + "CopyWorksheetsBetweenWorkbooks_out.xls");
            // ExEnd:1
        }
    }
}
