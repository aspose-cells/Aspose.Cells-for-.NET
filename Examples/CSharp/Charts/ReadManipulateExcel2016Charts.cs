using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    public class ReadManipulateExcel2016Charts
    {
        public static void Run()
        {
            // ExStart:ReadManipulateExcel2016Charts

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Load source excel file containing excel 2016 charts
            Workbook wb = new Workbook(dataDir + "excel2016Charts.xlsx");

            //Access the first worksheet which contains the charts
            Worksheet ws = wb.Worksheets[0];

            //Access all charts one by one and read their types
            for (int i = 0; i < ws.Charts.Count; i++)
            {
                //Access the chart
                Chart ch = ws.Charts[i];

                //Print chart type
                Console.WriteLine(ch.Type);

                //Change the title of the charts as per their types
                ch.Title.Text = "Chart Type is " + ch.Type.ToString();
            }

            //Save the workbook
            wb.Save(dataDir + "out_excel2016Charts.xlsx");

            // ExStart:ReadManipulateExcel2016Charts
        }
    }
}
