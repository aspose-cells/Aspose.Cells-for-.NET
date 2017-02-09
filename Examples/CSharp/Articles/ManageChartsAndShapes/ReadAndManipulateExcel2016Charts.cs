using Aspose.Cells.Charts;
using System;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    class ReadAndManipulateExcel2016Charts
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load source excel file containing excel 2016 charts
            Workbook book = new Workbook(dataDir + "excel2016Charts.xlsx");

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
            book.Save(dataDir + "out_excel2016Charts.xlsx");
            // ExEnd:1
        }
    }
}
