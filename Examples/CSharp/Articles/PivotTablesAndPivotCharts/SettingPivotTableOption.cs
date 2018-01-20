using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Pivot;

namespace Aspose.Cells.Examples.CSharp.Articles.PivotTablesAndPivotCharts
{
    public class SettingPivotTableOption
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook wb = new Workbook(sourceDir + "sampleSettingPivotTableOption.xlsx");

            PivotTable pt = wb.Worksheets[0].PivotTables[0];

            // Indicating if or not display the empty cell value
            pt.DisplayNullString = true;

            // Indicating the null string
            pt.NullString = "null";
            pt.CalculateData();

            pt.RefreshDataOnOpeningFile = false;

            wb.Save(outputDir + "outputSettingPivotTableOption.xlsx");

            Console.WriteLine("SettingPivotTableOption executed successfully.");
        }
    }
}