using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.RowsColumns.Copying
{
    public class CopyingColumns
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                       

            // Create another Workbook.
            Workbook excelWorkbook1 = new Workbook(dataDir + "book1.xls");

            // Get the first worksheet in the book.
            Worksheet ws1 = excelWorkbook1.Worksheets[0];

            // Copy the first column from the first worksheet of the first workbook into
            // The first worksheet of the second workbook.
            ws1.Cells.CopyColumn(ws1.Cells, ws1.Cells.Columns[0].Index, ws1.Cells.Columns[2].Index);

            // Autofit the column.
            ws1.AutoFitColumn(2);

            // Save the excel file.
            excelWorkbook1.Save(dataDir + "output.xls");
            // ExEnd:1

        }
    }
}
