using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.RowsColumns.Grouping
{
    public class SummaryRowRight
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Workbook workbook = new Workbook(dataDir + "sample.xlsx");
            Worksheet worksheet = workbook.Worksheets[0];

            // Grouping first six rows and first three columns
            worksheet.Cells.GroupRows(0, 5, true);
            worksheet.Cells.GroupColumns(0, 2, true);

            worksheet.Outline.SummaryColumnRight = true;

            // Saving the modified Excel file
            workbook.Save(dataDir + "output.xls");
            // ExEnd:1
        }
    }
}
