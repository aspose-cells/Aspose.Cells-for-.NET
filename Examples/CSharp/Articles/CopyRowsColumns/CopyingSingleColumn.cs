using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.CopyRowsColumns
{
    public class CopyingSingleColumn
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate a new Workbook
            // Open an existing excel file
            Workbook workbook = new Workbook(dataDir+ "aspose-sample.xlsx");

            // Get the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];
            // Get the Cells collection
            Cells cells = worksheet.Cells;

            //Copy the first column to next 10 columns
            for (int i = 1; i <= 10; i++)
            {
                cells.CopyColumn(cells, 0, i);
            }

            // Save the excel file
            workbook.Save(dataDir+ "outaspose-sample.out.xlsx");
            // ExEnd:1
        }
    }
}
