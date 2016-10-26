using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class CreateDynamicCharts
    {
        public static void Run()
        {
            // ExStart:CreateDynamicCharts
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create an instance of Workbook
            var book = new Workbook();
            // Access first worksheet from the collection
            var sheet = book.Worksheets[0];
            // Access cells collection of the first worksheet
            var cells = sheet.Cells;

            // Insert data column wise
            cells["A1"].PutValue("Category");
            cells["A2"].PutValue("Fruit");
            cells["A3"].PutValue("Fruit");
            cells["A4"].PutValue("Fruit");
            cells["A5"].PutValue("Fruit");
            cells["A6"].PutValue("Vegetables");
            cells["A7"].PutValue("Vegetables");
            cells["A8"].PutValue("Vegetables");
            cells["A9"].PutValue("Vegetables");
            cells["A10"].PutValue("Beverages");
            cells["A11"].PutValue("Beverages");
            cells["A12"].PutValue("Beverages");

            cells["B1"].PutValue("Food");
            cells["B2"].PutValue("Apple");
            cells["B3"].PutValue("Banana");
            cells["B4"].PutValue("Apricot");
            cells["B5"].PutValue("Grapes");
            cells["B6"].PutValue("Carrot");
            cells["B7"].PutValue("Onion");
            cells["B8"].PutValue("Cabage");
            cells["B9"].PutValue("Potatoe");
            cells["B10"].PutValue("Coke");
            cells["B11"].PutValue("Coladas");
            cells["B12"].PutValue("Fizz");

            cells["C1"].PutValue("Cost");
            cells["C2"].PutValue(2.2);
            cells["C3"].PutValue(3.1);
            cells["C4"].PutValue(4.1);
            cells["C5"].PutValue(5.1);
            cells["C6"].PutValue(4.4);
            cells["C7"].PutValue(5.4);
            cells["C8"].PutValue(6.5);
            cells["C9"].PutValue(5.3);
            cells["C10"].PutValue(3.2);
            cells["C11"].PutValue(3.6);
            cells["C12"].PutValue(5.2);

            cells["D1"].PutValue("Profit");
            cells["D2"].PutValue(0.1);
            cells["D3"].PutValue(0.4);
            cells["D4"].PutValue(0.5);
            cells["D5"].PutValue(0.6);
            cells["D6"].PutValue(0.7);
            cells["D7"].PutValue(1.3);
            cells["D8"].PutValue(0.8);
            cells["D9"].PutValue(1.3);
            cells["D10"].PutValue(2.2);
            cells["D11"].PutValue(2.4);
            cells["D12"].PutValue(3.3);

            // Create ListObject, Get the List objects collection in the first worksheet
            var listObjects = sheet.ListObjects;

            // Add a List based on the data source range with headers on
            var index = listObjects.Add(0, 0, 11, 3, true);

            sheet.AutoFitColumns();

            // Create chart based on ListObject
            index = sheet.Charts.Add(ChartType.Column, 21, 1, 35, 18);
            var chart = sheet.Charts[index];
            chart.SetChartDataRange("A1:D12", true);
            chart.NSeries.CategoryData = "A2:B12";

            // Save spreadsheet
            book.Save(dataDir + "output_out_.xlsx");
            // ExEnd:CreateDynamicCharts
        }
    }
}
