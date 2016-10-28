using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.CopyRowsColumns
{
    public class CopyingSingleRow
    {
        public static void Run()
        {
            // ExStart:CopyingSingleRow
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate a new workbook
            // Open an existing excel file
            Workbook workbook = new Workbook(dataDir+ "aspose-sample.xlsx");

            // Get the first worksheet cells
            Cells cells = workbook.Worksheets[0].Cells;

            //Copy the first row to next 10 rows
            for (int i = 1; i <= 10; i++)
            {
                cells.CopyRow(cells, 0, i);
            }

            // Save the excel file
            workbook.Save(dataDir + "outaspose-sample.out.xlsx");
            // ExEnd:CopyingSingleRow
        }
    }
}
