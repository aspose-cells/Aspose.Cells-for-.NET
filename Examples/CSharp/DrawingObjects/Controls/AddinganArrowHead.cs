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
            line2.LineFormat.ForeColor = Color.Blue;

            // Set the line style.
            line2.LineFormat.DashStyle = MsoLineDashStyle.Solid;

            // Set the weight of the line.
            line2.LineFormat.Weight = 3;

            // Set the placement.
            line2.Placement = PlacementType.FreeFloating;

            // Set the line arrows.
            line2.EndArrowheadWidth = MsoArrowheadWidth.Medium;
            line2.EndArrowheadStyle = MsoArrowheadStyle.Arrow;
            line2.EndArrowheadLength = MsoArrowheadLength.Medium;

            line2.BeginArrowheadStyle = MsoArrowheadStyle.ArrowDiamond;
            line2.BeginArrowheadLength = MsoArrowheadLength.Medium;

            // Make the gridlines invisible in the first worksheet.
            workbook.Worksheets[0].IsGridlinesVisible = false;

            // Save the excel file.
            workbook.Save(dataDir+ "book1.out.xls");
            // ExEnd:1

        }
    }
}
