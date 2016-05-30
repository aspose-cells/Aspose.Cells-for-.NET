using System.IO;

using Aspose.Cells;

namespace CSharp.Articles.CopyRowsColumns
{
    public class CopyingRows
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate a new workbook
            // Open an existing excel file
            Workbook workbook = new Workbook(dataDir+ "aspose-sample.xlsx");

            // Get the first worksheet cells
            Cells cells = workbook.Worksheets[0].Cells;
            // Apply formulas to the cells
            for (int i = 0; i < 5; i++)
            {
                cells[0, i].Formula = "=Input!" + cells[0, i].Name;
            }
            // Copy the first row to next 10 rows
            cells.CopyRows(cells, 0, 1, 10);
            // Save the excel file
            workbook.Save(dataDir + "outaspose-sample.out.xlsx");
            // ExEnd:1
 
        }
    }
}
