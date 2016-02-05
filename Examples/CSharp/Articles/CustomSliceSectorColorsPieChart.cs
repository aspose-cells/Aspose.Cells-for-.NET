using System.IO;

using Aspose.Cells;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.Articles
{
    public class CustomSliceSectorColorsPieChart
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create a workbook object from the template file
            Workbook workbook = new Workbook();

            //Access the first worksheet.
            Worksheet worksheet = workbook.Worksheets[0];

            //Put the sample values used in a pie chart
            worksheet.Cells["C3"].PutValue("India");
            worksheet.Cells["C4"].PutValue("China");
            worksheet.Cells["C5"].PutValue("United States");
            worksheet.Cells["C6"].PutValue("Russia");
            worksheet.Cells["C7"].PutValue("United Kingdom");
            worksheet.Cells["C8"].PutValue("Others");

            //Put the sample values used in a pie chart
            worksheet.Cells["D2"].PutValue("% of world population");
            worksheet.Cells["D3"].PutValue(25);
            worksheet.Cells["D4"].PutValue(30);
            worksheet.Cells["D5"].PutValue(10);
            worksheet.Cells["D6"].PutValue(13);
            worksheet.Cells["D7"].PutValue(9);
            worksheet.Cells["D8"].PutValue(13);

            //Create a pie chart with desired length and width
            int pieIdx = worksheet.Charts.Add(ChartType.Pie, 1, 6, 15, 14);

            //Access the pie chart
            Chart pie = worksheet.Charts[pieIdx];

            //Set the pie chart series
            pie.NSeries.Add("D3:D8", true);

            //Set the category data
            pie.NSeries.CategoryData = "=Sheet1!$C$3:$C$8";

            //Set the chart title that is linked to cell D2
            pie.Title.LinkedSource = "D2";

            //Set the legend position at the bottom.
            pie.Legend.Position = LegendPositionType.Bottom;

            //Set the chart title's font name and color
            pie.Title.Font.Name = "Calibri";
            pie.Title.Font.Size = 18;

            //Access the chart series
            Series srs = pie.NSeries[0];

            //Color the indvidual points with custom colors
            srs.Points[0].Area.ForegroundColor = System.Drawing.Color.FromArgb(0, 246, 22, 219);
            srs.Points[1].Area.ForegroundColor = System.Drawing.Color.FromArgb(0, 51, 34, 84);
            srs.Points[2].Area.ForegroundColor = System.Drawing.Color.FromArgb(0, 46, 74, 44);
            srs.Points[3].Area.ForegroundColor = System.Drawing.Color.FromArgb(0, 19, 99, 44);
            srs.Points[4].Area.ForegroundColor = System.Drawing.Color.FromArgb(0, 208, 223, 7);
            srs.Points[5].Area.ForegroundColor = System.Drawing.Color.FromArgb(0, 222, 69, 8);

            //Autofit all columns
            worksheet.AutoFitColumns();

            //Save the workbook
            workbook.Save(dataDir+ "output.out.xlsx", SaveFormat.Xlsx);

            
            
        }
    }
}