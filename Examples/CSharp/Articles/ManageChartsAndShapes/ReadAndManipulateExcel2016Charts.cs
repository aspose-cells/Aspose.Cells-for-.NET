using Aspose.Cells.Charts;
using System;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    class ReadAndManipulateExcel2016Charts
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load source excel file containing excel 2016 charts
            Workbook book = new Workbook(sourceDir + "sampleReadAndManipulateExcel2016Charts.xlsx");

            // Access the first worksheet which contains the charts
            Worksheet sheet = book.Worksheets[0];

            // Access all charts one by one and read their types
            for (int i = 0; i < sheet.Charts.Count; i++)
            {
                // Access the chart
                Chart ch = sheet.Charts[i];

                // Print chart type
                Console.WriteLine(ch.Type);

                // Change the title of the charts as per their types
                ch.Title.Text = "Chart Type is " + ch.Type.ToString();
            }

            // Save the workbook
            book.Save(outputDir + "outputReadAndManipulateExcel2016Charts.xlsx");

            Console.WriteLine("ReadAndManipulateExcel2016Charts executed successfully.\r\n");
        }
    }
}
