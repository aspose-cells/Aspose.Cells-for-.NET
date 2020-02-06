using Aspose.Cells.Charts;
using System;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    public class InsertCheckboxInChartSheet
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // ExStart:1
            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Adding a chart to the worksheet
            int index = workbook.Worksheets.Add(SheetType.Chart);

            Worksheet sheet = workbook.Worksheets[index];
            sheet.Charts.AddFloatingChart(ChartType.Column, 0, 0, 1024, 960);
            sheet.Charts[0].NSeries.Add("{1,2,3}", false);

            // Add checkbox to the chart.
            sheet.Charts[0].Shapes.AddShapeInChart(MsoDrawingType.CheckBox, PlacementType.Move, 400, 400, 1000, 600);
            sheet.Charts[0].Shapes[0].Text = "CheckBox 1";

            // Save the excel file.
            workbook.Save(outputDir + "InsertCheckboxInChartSheet_out.xlsx");
            // ExEnd:1

            Console.WriteLine("InsertCheckboxInChartSheet executed successfully.");
        }
    }
}
