using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class CopyShapesBetweenWorksheets
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open the template file
            Workbook workbook = new Workbook(sourceDir + "sampleCopyShapesBetweenWorksheets.xlsx");

            // Get the Picture from the "Picture" worksheet.
            Aspose.Cells.Drawing.Picture picturesource = workbook.Worksheets["Picture"].Pictures[0];

            // Save Picture to Memory Stream
            MemoryStream ms = new MemoryStream(picturesource.Data);

            // Copy the picture to the Result Worksheet
            workbook.Worksheets["Result"].Pictures.Add(picturesource.UpperLeftRow, picturesource.UpperLeftColumn, ms, picturesource.WidthScale, picturesource.HeightScale);

            // Save the Worksheet
            workbook.Save(outputDir + "outputCopyShapesBetweenWorksheets_Picture.xlsx");

            //-----------------------------------
            //-----------------------------------

            // Open the template file
            workbook = new Workbook(sourceDir + "sampleCopyShapesBetweenWorksheets.xlsx");

            // Get the Chart from the "Chart" worksheet.
            Aspose.Cells.Charts.Chart chartsource = workbook.Worksheets["Chart"].Charts[0];

            Aspose.Cells.Drawing.ChartShape cshape = chartsource.ChartObject;

            // Copy the Chart to the Result Worksheet
            workbook.Worksheets["Result"].Shapes.AddCopy(cshape, 5, 0, 2, 0);

            // Save the Worksheet
            workbook.Save(outputDir + "outputCopyShapesBetweenWorksheets_Chart.xlsx");

            //-----------------------------------
            //-----------------------------------

            // Open the template file
            workbook = new Workbook(sourceDir + "sampleCopyShapesBetweenWorksheets.xlsx");

            // Get the Shapes from the "Control" worksheet.
            Aspose.Cells.Drawing.ShapeCollection shape = workbook.Worksheets["Control"].Shapes;

            // Copy the Textbox to the Result Worksheet
            workbook.Worksheets["Result"].Shapes.AddCopy(shape[0], 5, 0, 2, 0);

            // Save the Worksheet
            workbook.Save(outputDir + "outputCopyShapesBetweenWorksheets_Control.xlsx");

            Console.WriteLine("CopyShapesBetweenWorksheets executed successfully.");
        }
    }
}
