using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.CreatePivotTablesPivotCharts
{
    public class CreatePivotChart
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiating an Workbook object
            // Opening the excel file
            Workbook workbook = new Workbook(sourceDir + "sampleCreatePivotChart.xlsx");
            
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
            workbook.Save(outputDir + "outputCreatePivotChart.xlsx");

            Console.WriteLine("CreatePivotChart executed successfully.");
        }
    }
}
