using System.IO;

using Aspose.Cells;

namespace CSharp.Articles
{
    public class InsertDeleteRows
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Instantiate a Workbook object.
            // Load a template file.
            Workbook workbook = new Workbook(dataDir+ "book1.xlsx");

            // Get the first worksheet in the book.
            Worksheet sheet = workbook.Worksheets[0];

            // Insert 10 rows at row index 2 (insertion starts at 3rd row)
            sheet.Cells.InsertRows(2, 10);

            // Delete 5 rows now. (8th row - 12th row)
            sheet.Cells.DeleteRows(7, 5);

            // Save the excel file.
            workbook.Save(dataDir+ "out_book1.out.xlsx");
            // ExEnd:1
 
            
            
        }
    }
}
