using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    public class ReadManipulateExcel2016Charts
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            //Load source excel file containing excel 2016 charts
            Workbook wb = new Workbook(sourceDir + "sampleReadManipulateExcel2016Charts.xlsx");

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
            wb.Save(outputDir + "outputReadManipulateExcel2016Charts.xlsx");

            Console.WriteLine("ReadManipulateExcel2016Charts executed successfully.");
        }
    }
}
