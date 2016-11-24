using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class ResizeChartDataLabelToFit
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create an instance of Workbook containing the Chart
            var book = new Workbook(dataDir + "source.xlsx");

            // Access the Worksheet that contains the Chart
            var sheet = book.Worksheets[0];

            foreach (Chart chart in sheet.Charts)
            {
                for (int index = 0; index < chart.NSeries.Count; index++)
                {
                    // Access the DataLabels of indexed NSeries
                    var labels = chart.NSeries[index].DataLabels;

                    // Set ResizeShapeToFitText property to true
                    labels.IsResizeShapeToFitText = true;
                }

                // Calculate Chart
                chart.Calculate();
            }

            // Save the result
            book.Save(dataDir + "output_out.xlsx");
            // ExEnd:1
        }
    }
}
