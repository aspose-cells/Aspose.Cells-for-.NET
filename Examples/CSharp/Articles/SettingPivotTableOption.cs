using System.IO;

using Aspose.Cells;
using Aspose.Cells.Pivot;

namespace Aspose.Cells.Examples.Articles
{
    public class SettingPivotTableOption
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook wb = new Workbook(dataDir + "input.xlsx");

            PivotTable pt = wb.Worksheets[0].PivotTables[0];

            //Indicating if or not display the empty cell value
            pt.DisplayNullString = true;

            //Indicating the null string
            pt.NullString = "null";

            pt.CalculateData();

            pt.RefreshDataOnOpeningFile = false;

            wb.Save(dataDir+ "output.out.xlsx");
            
        }
    }
}