using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class SettingFormulaCalculationModeWorkbook
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Create a workbook
            Workbook workbook = new Workbook();

            // Set the Formula Calculation Mode to Manual
            workbook.Settings.CalcMode = CalcModeType.Manual;

            // Save the workbook
            workbook.Save(dataDir+ "output.out.xlsx", SaveFormat.Xlsx);
            
        }
    }
}