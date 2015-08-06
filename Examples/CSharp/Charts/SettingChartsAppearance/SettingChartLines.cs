//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.Charts.SettingChartsAppearance
{
    public class SettingChartLines
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Workbook object
            int sheetIndex = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[sheetIndex];

            //Adding a sample value to "A1" cell
            worksheet.Cells["A1"].PutValue(50);

            //Adding a sample value to "A2" cell
            worksheet.Cells["A2"].PutValue(100);

            //Adding a sample value to "A3" cell
            worksheet.Cells["A3"].PutValue(150);

            //Adding a sample value to "B1" cell
            worksheet.Cells["B1"].PutValue(60);

            //Adding a sample value to "B2" cell
            worksheet.Cells["B2"].PutValue(32);

            //Adding a sample value to "B3" cell
            worksheet.Cells["B3"].PutValue(50);

            //Adding a chart to the worksheet
            int chartIndex = worksheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 5, 0, 15, 5);

            //Accessing the instance of the newly added chart
            Aspose.Cells.Charts.Chart chart = worksheet.Charts[chartIndex];

            //Adding SeriesCollection (chart data source) to the chart ranging from "A1" cell to "B3"
            chart.NSeries.Add("A1:B3", true);

            //Setting the foreground color of the plot area
            chart.PlotArea.Area.ForegroundColor = Color.Blue;

            //Setting the foreground color of the chart area
            chart.ChartArea.Area.ForegroundColor = Color.Yellow;

            //Setting the foreground color of the 1st SeriesCollection area
            chart.NSeries[0].Area.ForegroundColor = Color.Red;

            //Setting the foreground color of the area of the 1st SeriesCollection point
            chart.NSeries[0].Points[0].Area.ForegroundColor = Color.Cyan;

            //Filling the area of the 2nd SeriesCollection with a gradient
            chart.NSeries[1].Area.FillFormat.SetOneColorGradient(Color.Lime, 1, Aspose.Cells.Drawing.GradientStyleType.Horizontal, 1);

            //Applying a dotted line style on the lines of a SeriesCollection
            chart.NSeries[0].Border.Style = Aspose.Cells.Drawing.LineType.Dot;

            //Applying a triangular marker style on the data markers of a SeriesCollection
            chart.NSeries[0].Marker.MarkerStyle = Aspose.Cells.Charts.ChartMarkerType.Triangle;

            //Setting the weight of all lines in a SeriesCollection to medium
            chart.NSeries[1].Border.Weight = Aspose.Cells.Drawing.WeightType.MediumLine;


            //Saving the Excel file
            workbook.Save(dataDir + "book1.xls");

        }
    }
}