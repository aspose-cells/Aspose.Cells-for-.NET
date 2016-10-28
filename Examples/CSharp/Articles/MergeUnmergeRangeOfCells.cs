using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class MergeUnmergeRangeOfCells
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Create a workbook
            Workbook workbook = new Workbook();

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Create a range
            Range range = worksheet.Cells.CreateRange("A1:D4");

            // Merge range into a single cell
            range.Merge();

            // Save the workbook
            workbook.Save(dataDir+ "output.out.xlsx");
            // ExEnd:1
        }
    }
}