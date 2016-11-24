using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class GenerateChartByProcessingSmartMarkers
    {
        public static void Run()
        {
            // ExStart:CreationOfDesignerSpreadsheet
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create an instance of Workbook
            var book = new Workbook();

            // Access the first, default Worksheet by passing its index
            var dataSheet = book.Worksheets[0];

            // Name the Worksheet for later reference
            dataSheet.Name = "ChartData";

            // Access the CellsCollection of first Worksheet
            var cells = dataSheet.Cells;

            // Insert static data (headers)
            cells["B1"].PutValue("Item 1");
            cells["C1"].PutValue("Item 2");
            cells["D1"].PutValue("Item 3");
            cells["E1"].PutValue("Item 4");
            cells["F1"].PutValue("Item 5");
            cells["G1"].PutValue("Item 6");
            cells["H1"].PutValue("Item 7");
            cells["I1"].PutValue("Item 8");
            cells["J1"].PutValue("Item 9");
            cells["K1"].PutValue("Item 10");
            cells["L1"].PutValue("Item 11");
            cells["M1"].PutValue("Item 12");


            // Place Smart Markers
            cells["A2"].PutValue("&=Sales.Year");
            cells["B2"].PutValue("&=Sales.Item1");
            cells["C2"].PutValue("&=Sales.Item2");
            cells["D2"].PutValue("&=Sales.Item3");
            cells["E2"].PutValue("&=Sales.Item4");
            cells["F2"].PutValue("&=Sales.Item5");
            cells["G2"].PutValue("&=Sales.Item6");
            cells["H2"].PutValue("&=Sales.Item7");
            cells["I2"].PutValue("&=Sales.Item8");
            cells["J2"].PutValue("&=Sales.Item9");
            cells["K2"].PutValue("&=Sales.Item10");
            cells["L2"].PutValue("&=Sales.Item11");
            cells["M2"].PutValue("&=Sales.Item12");
            // ExEnd:CreationOfDesignerSpreadsheet

            // ExStart:ProcessingDesignerSpreadsheet
            // Create an instance of DataTable and name is according to the Smart Markers
            var table = new DataTable("Sales");
            /*
             * Add columns to the newly created DataTable while specifying the column type
             * It is important that the DataTable should have at least one column for each
             * Smart Marker entry from the designer spreadsheet
            */
            table.Columns.Add("Year", typeof(string));
            table.Columns.Add("Item1", typeof(int));
            table.Columns.Add("Item2", typeof(int));
            table.Columns.Add("Item3", typeof(int));
            table.Columns.Add("Item4", typeof(int));
            table.Columns.Add("Item5", typeof(int));
            table.Columns.Add("Item6", typeof(int));
            table.Columns.Add("Item7", typeof(int));
            table.Columns.Add("Item8", typeof(int));
            table.Columns.Add("Item9", typeof(int));
            table.Columns.Add("Item10", typeof(int));
            table.Columns.Add("Item11", typeof(int));
            table.Columns.Add("Item12", typeof(int));

            // Add some rows with data to the DataTable
            table.Rows.Add("2000", 2310, 0, 110, 15, 20, 25, 30, 1222, 200, 421, 210, 133);
            table.Rows.Add("2005", 1508, 0, 170, 280, 190, 400, 105, 132, 303, 199, 120, 100);
            table.Rows.Add("2010", 0, 210, 230, 140, 150, 160, 170, 110, 1999, 1229, 1120, 2300);
            table.Rows.Add("2015", 3818, 320, 340, 260, 210, 310, 220, 0, 0, 0, 0, 122);
            // ExEnd:ProcessingDesignerSpreadsheet

            // ExStart:ProcessingOfSmartMarkers
            // Create an instance of WorkbookDesigner class
            var designer = new WorkbookDesigner();

            // Assign the Workbook property to the instance of Workbook created in first step
            designer.Workbook = book;

            // Set the data source
            designer.SetDataSource(table);

            // Call Process method to populate data
            designer.Process();
            // ExEnd:ProcessingOfSmartMarkers

            // ExStart:CreationOfChart
            /*
             * Save the number of rows & columns from the source DataTable in seperate variables. 
             * These values will be used later to identify the chart's data range from DataSheet
            */
            int chartRows = table.Rows.Count;
            int chartCols = table.Columns.Count;

            // Add a new Worksheet of type Chart to Workbook
            int chartSheetIdx = book.Worksheets.Add(SheetType.Chart);

            // Access the newly added Worksheet via its index
            var chartSheet = book.Worksheets[chartSheetIdx];

            // Name the Worksheet
            chartSheet.Name = "Chart";

            // Add a chart of type ColumnStacked to newly added Worksheet
            int chartIdx = chartSheet.Charts.Add(ChartType.ColumnStacked, 0, 0, chartRows, chartCols);

            // Access the newly added Chart via its index
            var chart = chartSheet.Charts[chartIdx];

            // Set the data range for the chart
            chart.SetChartDataRange(dataSheet.Name + "!A1:" + CellsHelper.ColumnIndexToName(chartCols - 1) + (chartRows + 1).ToString(), false);

            // Set the chart to size with window
            chart.SizeWithWindow = true;

            // Set the format for the tick labels
            chart.ValueAxis.TickLabels.NumberFormat = "$###,### K";

            // Set chart title
            chart.Title.Text = "Sales Summary";

            // Set ChartSheet an active sheet
            book.Worksheets.ActiveSheetIndex = chartSheetIdx;

            // Save the final result
            book.Save(dataDir + "report_out.xlsx");
            // ExEnd:CreationOfChart
        }
    }
}
