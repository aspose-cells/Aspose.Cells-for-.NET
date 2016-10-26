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
            // ExStart:CopyPictureBetweenWorksheets
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open the template file
            Workbook workbook = new Workbook(dataDir + "sample.xlsx");

            // Get the Picture from the "Picture" worksheet.
            Aspose.Cells.Drawing.Picture picturesource = workbook.Worksheets["Picture"].Pictures[0];

            // Save Picture to Memory Stream
            MemoryStream ms = new MemoryStream(picturesource.Data);

            // Copy the picture to the Result Worksheet
            workbook.Worksheets["Result"].Pictures.Add(picturesource.UpperLeftRow, picturesource.UpperLeftColumn, ms, picturesource.WidthScale, picturesource.HeightScale);

            // Save the Worksheet
            workbook.Save(dataDir + "PictureCopied_out_.xlsx");
            // ExEnd:CopyPictureBetweenWorksheets

            // ExStart:CopyChartBetweenWorksheets
            // Get the Chart from the "Chart" worksheet.
            Aspose.Cells.Charts.Chart chartsource = workbook.Worksheets["Chart"].Charts[0];

            Aspose.Cells.Drawing.ChartShape cshape = chartsource.ChartObject;

            // Copy the Chart to the Result Worksheet
            workbook.Worksheets["Result"].Shapes.AddCopy(cshape, 20, 0, 2, 0);

            // Save the Worksheet
            workbook.Save(dataDir + "ChartCopied_out_.xlsx");
            // ExEnd:CopyChartBetweenWorksheets

            // ExStart:CopyControlsAndOtherDrawingObjects
            // Open the template file
            workbook = new Workbook(dataDir + "sample2.xlsx");

            // Get the Shapes from the "Control" worksheet.
            Aspose.Cells.Drawing.ShapeCollection shape = workbook.Worksheets["Control"].Shapes;

            // Copy the Textbox to the Result Worksheet
            workbook.Worksheets["Result"].Shapes.AddCopy(shape[0], 5, 0, 2, 0);

            // Copy the Oval Shape to the Result Worksheet
            workbook.Worksheets["Result"].Shapes.AddCopy(shape[1], 10, 0, 2, 0);

            // Save the Worksheet
            workbook.Save(dataDir + "ControlsCopied_out_.xlsx");
            // ExEnd:CopyControlsAndOtherDrawingObjects
        }
    }
}
