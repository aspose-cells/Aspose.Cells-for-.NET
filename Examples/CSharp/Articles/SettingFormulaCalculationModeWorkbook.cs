using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class SettingFormulaCalculationModeWorkbook
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Create a workbook
            Workbook workbook = new Workbook();

            //Set the Formula Calculation Mode to Manual
            workbook.Settings.CalcMode = CalcModeType.Manual;

            //Save the workbook
            workbook.Save(dataDir+ "output.out.xlsx", SaveFormat.Xlsx);
            
        }
    }
}