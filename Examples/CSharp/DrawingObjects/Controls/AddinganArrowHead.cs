using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects.Controls
{
    public class AddinganArrowHead
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            // Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            // Get the first worksheet in the book.
            Worksheet worksheet = workbook.Worksheets[0];

            // Add a line to the worksheet
            Aspose.Cells.Drawing.LineShape line2 = worksheet.Shapes.AddLine(7, 0, 1, 0, 85, 250);

            // Set the line color
            line2.Line.FillType = FillType.Solid;
            line2.Line.SolidFill.Color = Color.Blue;

            // Set the weight of the line.
            line2.Line.Weight = 3;

            // Set the placement.
            line2.Placement = PlacementType.FreeFloating;

            // Set the line arrows.
            line2.Line.EndArrowheadWidth = MsoArrowheadWidth.Medium;
            line2.Line.EndArrowheadStyle = MsoArrowheadStyle.Arrow;
            line2.Line.EndArrowheadLength = MsoArrowheadLength.Medium;
            line2.Line.BeginArrowheadStyle = MsoArrowheadStyle.ArrowDiamond;
            line2.Line.BeginArrowheadLength = MsoArrowheadLength.Medium;

            // Make the gridlines invisible in the first worksheet.
            workbook.Worksheets[0].IsGridlinesVisible = false;

            // Save the excel file.
            workbook.Save(dataDir+ "book1.out.xlsx");
            // ExEnd:1
        }
    }
}
