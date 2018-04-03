using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Cells.Charts;
using System.Collections;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    class ReadAxisLabelsAfterCalculatingTheChart 
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Run()
        {
            //Load the Excel file containing chart
            Workbook wb = new Workbook(sourceDir + "sampleReadAxisLabelsAfterCalculatingTheChart.xlsx");

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Access the chart
            Chart ch = ws.Charts[0];

            //Calculate the chart
            ch.Calculate();

            //Read axis labels of category axis
            ArrayList lstLabels = ch.CategoryAxis.AxisLabels;

            //Print axis labels on console
            Console.WriteLine("Category Axis Labels: ");
            Console.WriteLine("---------------------");

            //Iterate axis labels and print them one by one
            for (int i = 0; i < lstLabels.Count; i++)
            {
                Console.WriteLine(lstLabels[i]);
            }

            Console.WriteLine("ReadAxisLabelsAfterCalculatingTheChart executed successfully.");
        }
    }

}
