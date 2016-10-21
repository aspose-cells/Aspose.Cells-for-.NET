using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithCalculationEngine
{
    public class SettingFormulaCalculationModeWorkbook
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Create a workbook
            Workbook workbook = new Workbook();

            // Set the Formula Calculation Mode to Manual
            workbook.Settings.CalcMode = CalcModeType.Manual;

            // Save the workbook
            workbook.Save(dataDir + "output_out_.xlsx", SaveFormat.Xlsx);
            // ExEnd:1
        }
    }
}