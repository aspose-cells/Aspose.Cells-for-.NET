using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class MergeUnmergeRangeOfCells
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Create a workbook
            Workbook workbook = new Workbook();

            //Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Create a range
            Range range = worksheet.Cells.CreateRange("A1:D4");

            //Merge range into a single cell
            range.Merge();

            //Save the workbook
            workbook.Save(dataDir+ "output.xlsx");
            
            
        }
    }
}