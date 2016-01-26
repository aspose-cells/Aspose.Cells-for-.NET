using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.Charts
{
    public class Applying3DFormat
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiate a new Workbook
            Workbook book = new Workbook();

            //Add a Data Worksheet
            Worksheet dataSheet = book.Worksheets.Add("DataSheet");

            //Add Chart Worksheet
            Worksheet sheet = book.Worksheets.Add("MyChart");

            //Put some values into the cells in the data worksheet
            dataSheet.Cells["B1"].PutValue(1);
            dataSheet.Cells["B2"].PutValue(2);
            dataSheet.Cells["B3"].PutValue(3);
            dataSheet.Cells["A1"].PutValue("A");
            dataSheet.Cells["A2"].PutValue("B");
            dataSheet.Cells["A3"].PutValue("C");


            //Define the Chart Collection
            ChartCollection charts = sheet.Charts;
            //Add a Column chart to the Chart Worksheet
            int chartSheetIdx = charts.Add(ChartType.Column, 5, 0, 25, 15);

            //Get the newly added Chart
            Aspose.Cells.Charts.Chart chart = book.Worksheets[2].Charts[0];

            //Set the background/foreground color for PlotArea/ChartArea
            chart.PlotArea.Area.BackgroundColor = Color.White;
            chart.ChartArea.Area.BackgroundColor = Color.White;
            chart.PlotArea.Area.ForegroundColor = Color.White;
            chart.ChartArea.Area.ForegroundColor = Color.White;

            //Hide the Legend
            chart.ShowLegend = false;

            //Add Data Series for the Chart
            chart.NSeries.Add("DataSheet!B1:B3", true);
            //Specify the Category Data
            chart.NSeries.CategoryData = "DataSheet!A1:A3";

            //Get the Data Series
            Aspose.Cells.Charts.Series ser = chart.NSeries[0];

            //Apply the 3-D formatting
            ShapePropertyCollection spPr = ser.ShapeProperties;
            Format3D fmt3d = spPr.Format3D;

            //Specify Bevel with its height/width
            Bevel bevel = fmt3d.TopBevel;
            bevel.Type = BevelPresetType.Circle;
            bevel.Height = 2;
            bevel.Width = 5;

            //Specify Surface material type
            fmt3d.SurfaceMaterialType = PresetMaterialType.WarmMatte;

            //Specify surface lighting type
            fmt3d.SurfaceLightingType = LightRigType.ThreePoint;

            //Specify lighting angle
            fmt3d.LightingAngle = 20;

            //Specify Series background/foreground and line color
            ser.Area.BackgroundColor = Color.Maroon;
            ser.Area.ForegroundColor = Color.Maroon;
            ser.Border.Color = Color.Maroon;

            //Save the Excel file
            book.Save(dataDir + "3d_format.xlsx");

        }
    }
}