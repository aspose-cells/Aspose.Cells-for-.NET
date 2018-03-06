using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    public class HowToCreatePieChart
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Create a new Workbook.
            Workbook workbook = new Workbook();

            // Get the first worksheet.
            Worksheet sheet = workbook.Worksheets[0];

            // Set the name of worksheet
            sheet.Name = "Data";

            // Get the cells collection in the sheet.
            Cells cells = workbook.Worksheets[0].Cells;

            // Put some values into a cells of the Data sheet.
            cells["A1"].PutValue("Region");
            cells["A2"].PutValue("France");
            cells["A3"].PutValue("Germany");
            cells["A4"].PutValue("England");
            cells["A5"].PutValue("Sweden");
            cells["A6"].PutValue("Italy");
            cells["A7"].PutValue("Spain");
            cells["A8"].PutValue("Portugal");
            cells["B1"].PutValue("Sale");
            cells["B2"].PutValue(70000);
            cells["B3"].PutValue(55000);
            cells["B4"].PutValue(30000);
            cells["B5"].PutValue(40000);
            cells["B6"].PutValue(35000);
            cells["B7"].PutValue(32000);
            cells["B8"].PutValue(10000);

            // Add a chart sheet.
            int sheetIndex = workbook.Worksheets.Add(SheetType.Chart);
            sheet = workbook.Worksheets[sheetIndex];

            // Set the name of worksheet
            sheet.Name = "Chart";

            // Create chart
            int chartIndex = 0;
            chartIndex = sheet.Charts.Add(Aspose.Cells.Charts.ChartType.Pie, 5, 0, 25, 10);
            Aspose.Cells.Charts.Chart chart = sheet.Charts[chartIndex];

            // Set some properties of chart plot area.
            // To set the fill color and make the border invisible.
            chart.PlotArea.Area.ForegroundColor = Color.Coral;
            chart.PlotArea.Area.FillFormat.SetTwoColorGradient(Color.Yellow, Color.White, Aspose.Cells.Drawing.GradientStyleType.Vertical, 2);
            chart.PlotArea.Border.IsVisible = false;

            // Set properties of chart title
            chart.Title.Text = "Sales By Region";
            chart.Title.Font.Color = Color.Blue;
            chart.Title.Font.IsBold = true;
            chart.Title.Font.Size = 12;

            // Set properties of nseries
            chart.NSeries.Add("Data!B2:B8", true);
            chart.NSeries.CategoryData = "Data!A2:A8";
            chart.NSeries.IsColorVaried = true;

            // Set the DataLabels in the chart
            Aspose.Cells.Charts.DataLabels datalabels;
            for (int i = 0; i < chart.NSeries.Count; i++)
            {
                datalabels = chart.NSeries[i].DataLabels;
                datalabels.Position = Aspose.Cells.Charts.LabelPositionType.InsideBase;
                datalabels.ShowCategoryName = true;
                datalabels.ShowValue = true;
                datalabels.ShowPercentage = false;
                datalabels.ShowLegendKey = false;

            }

            // Set the ChartArea.
            Aspose.Cells.Charts.ChartArea chartarea = chart.ChartArea;
            chartarea.Area.Formatting = Aspose.Cells.Charts.FormattingType.Custom;
            chartarea.Area.FillFormat.Texture = Aspose.Cells.Drawing.TextureType.BlueTissuePaper;

            // Set the Legend.
            Aspose.Cells.Charts.Legend legend = chart.Legend;
            legend.Position = Aspose.Cells.Charts.LegendPositionType.Left;
            legend.Height = 100;
            legend.Width = 130;
            legend.Y = 1500;
            legend.Font.IsBold = true;
            legend.Border.Color = Color.Blue;
            legend.Area.Formatting = Aspose.Cells.Charts.FormattingType.Custom;

            // Set FillFormat.
            Aspose.Cells.Drawing.FillFormat fillformat = legend.Area.FillFormat;
            fillformat.Texture = Aspose.Cells.Drawing.TextureType.Bouquet;

            // Save the excel file
            workbook.Save(outputDir + "outputHowToCreatePieChart.xlsx");

            Console.WriteLine("HowToCreatePieChart executed successfully.");
        }
    }
}
