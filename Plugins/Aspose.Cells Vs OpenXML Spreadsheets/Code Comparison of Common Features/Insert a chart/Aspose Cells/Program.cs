// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Aspose_Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            string docName = "Insert a chart.xlsx";
            string worksheetName = "Sheet2";
            string title = "New Chart";
            string dataRange = "A1:B3";
            InsertChartInSpreadsheet(docName, worksheetName, title, dataRange);
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
