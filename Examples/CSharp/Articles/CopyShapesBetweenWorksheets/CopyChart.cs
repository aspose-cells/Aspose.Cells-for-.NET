using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.CopyShapesBetweenWorksheets
{
    public class CopyChart
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open the template file
            Workbook workbook = new Workbook(sourceDir + "sampleCopyChart.xlsx");

            Worksheet worksheet = workbook.Worksheets[0];

            // Get the Chart from the "Chart" worksheet.
            Aspose.Cells.Charts.Chart source = worksheet.Charts[0];

            Aspose.Cells.Drawing.ChartShape cshape = source.ChartObject;

            // Copy the Chart to the Result Worksheet
            worksheet.Shapes.AddCopy(cshape, 4, 0, 8, 0);

            // Save the Worksheet
            workbook.Save(outputDir + "outputCopyChart.xlsx");

            Console.WriteLine("CopyChart executed successfully.");
        }
    }
}
