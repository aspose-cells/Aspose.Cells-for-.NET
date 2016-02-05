using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.Articles
{
    public class SetPictureBackGroundFillChart
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create a new Workbook.
            Workbook workbook = new Workbook();

            //Get the first worksheet.
            Worksheet sheet = workbook.Worksheets[0];

            //Set the name of worksheet
            sheet.Name = "Data";

            //Get the cells collection in the sheet.
            Cells cells = workbook.Worksheets[0].Cells;

            //Put some values into a cells of the Data sheet.
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

            //Add a chart sheet.
            int sheetIndex = workbook.Worksheets.Add(SheetType.Chart);
            sheet = workbook.Worksheets[sheetIndex];

            //Set the name of worksheet
            sheet.Name = "Chart";

            //Create chart
            int chartIndex = 0;
            chartIndex = sheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 1, 1, 25, 10);
            Aspose.Cells.Charts.Chart chart = sheet.Charts[chartIndex];

            //Set some properties of chart plot area.
            //to set a picture as fill format and make the border invisible.
            FileStream fs = File.OpenRead(dataDir+ "aspose-logo.jpg");
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            chart.PlotArea.Area.FillFormat.ImageData = data;
            chart.PlotArea.Border.IsVisible = false;

            //Set properties of chart title
            chart.Title.Text = "Sales By Region";
            chart.Title.Font.Color = Color.Blue;
            chart.Title.Font.IsBold = true;
            chart.Title.Font.Size = 12;

            //Set properties of nseries
            chart.NSeries.Add("Data!B2:B8", true);
            chart.NSeries.CategoryData = "Data!A2:A8";
            chart.NSeries.IsColorVaried = true;

            //Set the Legend.
            Aspose.Cells.Charts.Legend legend = chart.Legend;
            legend.Position = Aspose.Cells.Charts.LegendPositionType.Top;

            //Save the excel file
            workbook.Save(dataDir+ "column_chart.out.xls");
        }
    }
}