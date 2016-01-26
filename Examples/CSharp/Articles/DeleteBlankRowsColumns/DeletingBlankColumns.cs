using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles.DeleteBlankRowsColumns
{
    public class DeletingBlankColumns
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create a new Workbook.
            //Open an existing excel file.
            Workbook wb = new Workbook(dataDir+ "SampleInput.xlsx");

            //Create a Worksheets object with reference to
            //the sheets of the Workbook.
            WorksheetCollection sheets = wb.Worksheets;

            //Get first Worksheet from WorksheetCollection
            Worksheet sheet = sheets[0];

            //Delete the Blank Rows from the worksheet
            sheet.Cells.DeleteBlankRows();

            //Save the excel file.
            wb.Save(dataDir+ "mybook.xlsx");
            
        }
    }
}