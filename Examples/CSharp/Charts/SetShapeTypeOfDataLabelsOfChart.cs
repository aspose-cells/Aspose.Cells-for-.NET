using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    class SetShapeTypeOfDataLabelsOfChart
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load source Excel file
            Workbook wb = new Workbook(sourceDir + "sampleSetShapeTypeOfDataLabelsOfChart.xlsx");

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Access first chart
            Chart ch = ws.Charts[0];

            //Access first series
            Series srs = ch.NSeries[0];

            //Set the shape type of data labels i.e. Speech Bubble Oval
            srs.DataLabels.ShapeType = DataLabelShapeType.WedgeEllipseCallout;

            //Save the output Excel file
            wb.Save(outputDir + "outputSetShapeTypeOfDataLabelsOfChart.xlsx");

            Console.WriteLine("SetShapeTypeOfDataLabelsOfChart executed successfully.\r\n");
        }
    }
}
