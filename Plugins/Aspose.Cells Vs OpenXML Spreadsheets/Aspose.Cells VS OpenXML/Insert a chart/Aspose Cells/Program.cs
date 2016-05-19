// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Cells for .NET API reference when the project is build. Please check https://docs.nuget.org/consume/nuget-faq for more information. If you do not wish to use NuGet, you can manually download Aspose.Cells for .NET API from http://www.aspose.com/downloads, install it and then add its reference to this project. For any issues, questions or suggestions please feel free to contact us using http://www.aspose.com/community/forums/default.aspx
*/

namespace Aspose.Plugins.AsposeVSOpenXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"..\..\..\..\Sample Files\";
            string FileName = FilePath + "Insert a chart.xlsx";
            string worksheetName = "Sheet1";
            string title = "New Chart";
            string dataRange = "A1:B3";
            InsertChartInSpreadsheet(FileName, worksheetName, title, dataRange);
        }

        private static void InsertChartInSpreadsheet(string docName, string worksheetName, string title, string dataRange)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook(docName);

            //Obtaining the reference of the worksheet by passing its Name
            Worksheet worksheet = workbook.Worksheets[worksheetName];

            //Adding a chart to the worksheet
            int chartIndex = worksheet.Charts.Add(Aspose.Cells.Charts.ChartType.Bar, 5, 0, 15, 5);

            //Accessing the instance of the newly added chart
            Aspose.Cells.Charts.Chart chart = worksheet.Charts[chartIndex];

            //Set title of the chart
            chart.Name = title;

            //Adding SeriesCollection (chart data source) to the chart ranging from "A1" cell to "B3"
            chart.NSeries.Add(dataRange, true);

            //Saving the Excel file
            workbook.Save(docName);
        }
    }
}
