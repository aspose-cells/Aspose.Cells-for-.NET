using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    public class ModifyPieChart
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {          
            // Open the existing file.
            Workbook workbook = new Workbook(sourceDir + "sampleModifyPieChart.xlsx");

            // Get the designer chart in the second sheet.
            Worksheet sheet = workbook.Worksheets[1];
            Aspose.Cells.Charts.Chart chart = sheet.Charts[0];

            // Get the data labels in the data series of the third data point.
            Aspose.Cells.Charts.DataLabels datalabels = chart.NSeries[0].Points[2].DataLabels;

            // Change the text of the label.
            datalabels.Text = "Unided Kingdom, 400K ";

            // Save the excel file.
            workbook.Save(outputDir + "outputModifyPieChart.xlsx");

            Console.WriteLine("ModifyPieChart executed successfully.");
        }
    }
}
