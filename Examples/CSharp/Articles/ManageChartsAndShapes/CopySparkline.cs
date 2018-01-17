using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class CopySparkline
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook from source Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleCopySparkline.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access the first sparkline group
            SparklineGroup group = worksheet.SparklineGroupCollection[0];

            // Add Data Ranges and Locations inside this sparkline group
            group.SparklineCollection.Add("D5:O5", 4, 15);
            group.SparklineCollection.Add("D6:O6", 5, 15);
            group.SparklineCollection.Add("D7:O7", 6, 15);
            group.SparklineCollection.Add("D8:O8", 7, 15);

            // Save the workbook
            workbook.Save(outputDir + "outputCopySparkline.xlsx");

            Console.WriteLine("CopySparkline executed successfully.");
        }
    }
}
