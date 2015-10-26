//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.Charts
{
    public class ChangeChartPosition
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook workbook = new Workbook(dataDir + "chart.xls");

            Worksheet worksheet = workbook.Worksheets[1];

            //Load the chart from source worksheet
            Chart chart = worksheet.Charts[0];

            //Resize the chart
            chart.ChartObject.Width = 400;
            chart.ChartObject.Height = 300;

            //Reposition the chart
            chart.ChartObject.X = 250;
            chart.ChartObject.Y = 150;

            //Output the file
            workbook.Save(dataDir + "chart_out.xls");

        }
    }
}