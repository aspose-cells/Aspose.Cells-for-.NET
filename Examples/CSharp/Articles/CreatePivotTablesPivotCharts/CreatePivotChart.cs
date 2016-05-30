using System.IO;

using Aspose.Cells;

namespace CSharp.Articles.CreatePivotTablesPivotCharts
{
    public class CreatePivotChart
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating an Workbook object
            // Opening the excel file
            Workbook workbook = new Workbook(dataDir+ "pivotTable_test.xlsx");
            // Adding a new sheet
            Worksheet sheet3 = workbook.Worksheets[workbook.Worksheets.Add(SheetType.Chart)];
            // Naming the sheet
            sheet3.Name = "PivotChart";
            // Adding a column chart
            int index = sheet3.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 5, 28, 16);
            // Setting the pivot chart data source
            sheet3.Charts[index].PivotSource = "PivotTable!PivotTable1";
            sheet3.Charts[index].HidePivotFieldButtons = false;
            // Saving the Excel file
            workbook.Save(dataDir+ "pivotChart_test.out.xlsx");
            // ExEnd:1
            
            
        }
    }
}
