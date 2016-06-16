using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects.Controls
{
    public class AddingLineControl
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

            // Add a new line to the worksheet.
            Aspose.Cells.Drawing.LineShape line1 = worksheet.Shapes.AddLine(5, 0, 1, 0, 0, 250);

            // Set the line dash style
            line1.LineFormat.DashStyle = MsoLineDashStyle.Solid;

            // Set the placement.
            line1.Placement = PlacementType.FreeFloating;

            // Add another line to the worksheet.
            Aspose.Cells.Drawing.LineShape line2 = worksheet.Shapes.AddLine(7, 0, 1, 0, 85, 250);

            // Set the line dash style.
            line2.LineFormat.DashStyle = MsoLineDashStyle.DashLongDash;

            // Set the weight of the line.
            line2.LineFormat.Weight = 4;

            // Set the placement.
            line2.Placement = PlacementType.FreeFloating;

            // Add the third line to the worksheet.
            Aspose.Cells.Drawing.LineShape line3 = worksheet.Shapes.AddLine(13, 0, 1, 0, 0, 250);

            // Set the line dash style
            line3.LineFormat.DashStyle = MsoLineDashStyle.Solid;

            // Set the placement.
            line3.Placement = PlacementType.FreeFloating;

            // Make the gridlines invisible in the first worksheet.
            workbook.Worksheets[0].IsGridlinesVisible = false;

            // Save the excel file.
            workbook.Save(dataDir + "book1.out.xls");
            // ExEnd:1
 
        }
    }
}
