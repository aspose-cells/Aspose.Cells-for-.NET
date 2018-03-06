using System;
using System.IO;
using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    public class AddingPictureInChart
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Open the existing file.
            Workbook workbook = new Workbook(sourceDir + "sampleAddingPictureInChart.xls");

            // Get an image file to the stream.
            FileStream stream = new FileStream(sourceDir + "sampleAddingPictureInChart.png", FileMode.Open, FileAccess.Read);

            // Get the designer chart in the second sheet.
            Worksheet sheet = workbook.Worksheets[0];
            Aspose.Cells.Charts.Chart chart = sheet.Charts[0];

            // Add a new picture to the chart.
            Aspose.Cells.Drawing.Picture pic0 = chart.Shapes.AddPictureInChart(50, 50, stream, 200, 200);

            // Get the lineformat type of the picture.
            Aspose.Cells.Drawing.LineFormat lineformat = pic0.Line;          

            // Set the dash style.
            lineformat.DashStyle = Aspose.Cells.Drawing.MsoLineDashStyle.Solid;

            // Set the line weight.
            lineformat.Weight = 4;    

            // Save the excel file.
            workbook.Save(outputDir + "outputAddingPictureInChart.xls");

            Console.WriteLine("AddingPictureInChart executed successfully.");
        }
    }
}
