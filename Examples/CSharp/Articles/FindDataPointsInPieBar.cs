using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class FindDataPointsInPieBar
    {
        public static void Run()
        {
            // ExStart:FindDataPointsInPieBar
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Load source excel file containing Bar of Pie chart
            Workbook wb = new Workbook(dataDir + "PieBars.xlsx");

            // Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            // Access first chart which is Bar of Pie chart and calculate it
            Chart ch = ws.Charts[0];
            ch.Calculate();

            // Access the chart series
            Series srs = ch.NSeries[0];

            /* 
             * Print the data points of the chart series and 
             * check its IsInSecondaryPlot property to determine 
             * if data point is inside the bar or pie 
            */
            for (int i = 0; i < srs.Points.Count; i++)
            {
                //Access chart point
                ChartPoint cp = srs.Points[i];

                //Skip null values
                if (cp.YValue == null)
                    continue;

               /* 
                 * Print the chart point value and see if it is inside bar or pie.
                 * If the IsInSecondaryPlot is true, then the data point is inside bar 
                 * otherwise it is inside the pie. 
               */
                Console.WriteLine("Value: " + cp.YValue);
                Console.WriteLine("IsInSecondaryPlot: " + cp.IsInSecondaryPlot);
                Console.WriteLine();
            }
            // ExEnd:FindDataPointsInPieBar
        }
    }
}
