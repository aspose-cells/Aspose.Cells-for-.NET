using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects.Controls
{
    public class AddingRectangleControl
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
            Workbook excelbook = new Workbook();

            // Add a rectangle control.
            Aspose.Cells.Drawing.RectangleShape rectangle = excelbook.Worksheets[0].Shapes.AddRectangle(3, 0, 2, 0, 70, 130);

            // Set the placement of the rectangle.
            rectangle.Placement = PlacementType.FreeFloating;   
            
            // Set the line weight.
            rectangle.Line.Weight = 4;
       
            // Set the dash style of the rectangle.
            rectangle.Line.DashStyle = MsoLineDashStyle.Solid;

            // Save the excel file.
            excelbook.Save(dataDir + "book1.out.xls");
            // ExEnd:1

        }
    }
}
