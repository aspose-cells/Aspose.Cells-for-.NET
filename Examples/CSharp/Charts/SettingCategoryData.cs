using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Charts
{
    public class SettingCategoryData
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Excel object
            int sheetIndex = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[sheetIndex];

            //Adding a sample value to "A1" cell
            worksheet.Cells["A1"].PutValue(10);

            //Adding a sample value to "A2" cell
            worksheet.Cells["A2"].PutValue(100);

            //Adding a sample value to "A3" cell
            worksheet.Cells["A3"].PutValue(170);

            //Adding a sample value to "A4" cell
            worksheet.Cells["A4"].PutValue(200);

            //Adding a sample value to "B1" cell
            worksheet.Cells["B1"].PutValue(120);

            //Adding a sample value to "B2" cell
            worksheet.Cells["B2"].PutValue(320);

            //Adding a sample value to "B3" cell
            worksheet.Cells["B3"].PutValue(50);

            //Adding a sample value to "B4" cell
            worksheet.Cells["B4"].PutValue(40);

            //Adding a sample value to "C1" cell as category data
            worksheet.Cells["C1"].PutValue("Q1");

            //Adding a sample value to "C2" cell as category data
            worksheet.Cells["C2"].PutValue("Q2");

            //Adding a sample value to "C3" cell as category data
            worksheet.Cells["C3"].PutValue("Y1");

            //Adding a sample value to "C4" cell as category data
            worksheet.Cells["C4"].PutValue("Y2");

            //Adding a chart to the worksheet
            int chartIndex = worksheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 5, 0, 15, 5);

            //Accessing the instance of the newly added chart
            Aspose.Cells.Charts.Chart chart = worksheet.Charts[chartIndex];

            //Adding SeriesCollection (chart data source) to the chart ranging from "A1" cell to "B4"
            chart.NSeries.Add("A1:B4", true);

            //Setting the data source for the category data of SeriesCollection
            chart.NSeries.CategoryData = "C1:C4";

            //Saving the Excel file
            workbook.Save(dataDir + "output.xls");
            //ExEnd:1

        }
    }
}
