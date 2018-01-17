using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class ShowCellRangeAsDataLabels
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook from the source Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleShowCellRangeAsDataLabels.xlsx");

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access the chart inside the worksheet
            Chart chart = worksheet.Charts[0];

            // Check the "Label Contains - Value From Cells"
            DataLabels dataLabels = chart.NSeries[0].DataLabels;
            dataLabels.LinkedSource = "=Sheet1!$B$2:$B$10";
            dataLabels.ShowCellRange = true;

            // Save the workbook
            workbook.Save(outputDir + "outputShowCellRangeAsDataLabels.xlsx");

            Console.WriteLine("ShowCellRangeAsDataLabels executed successfully.");
        }
    }
}
