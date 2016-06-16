using System.IO;

using Aspose.Cells;
using Aspose.Cells.Pivot;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class SettingPivotTableOption
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook wb = new Workbook(dataDir + "input.xlsx");

            // PivotTable pt = wb.Worksheets[0].PivotTables[0];

            // Indicating if or not display the empty cell value
            // Pt.DisplayNullString = true;

            // Indicating the null string
            // Pt.NullString = "null";

           // pt.CalculateData();

           // pt.RefreshDataOnOpeningFile = false;

           // wb.Save(dataDir+ "output.out.xlsx");
            
        }
    }
}