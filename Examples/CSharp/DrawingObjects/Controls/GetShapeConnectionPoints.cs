using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects.Controls
{
    public class GetShapeConnectionPoints
    {
        public static void Main()
        {
            // ExStart:1
            // Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            // Get the first worksheet in the book.
            Worksheet worksheet = workbook.Worksheets[0];

            // Add a new textbox to the collection.
            int textboxIndex = worksheet.TextBoxes.Add(2, 1, 160, 200);

            // Access your text box which is also a shape object from shapes collection
            Shape shape = workbook.Worksheets[0].Shapes[0];

            // Get all the connection points in this shape
            var ConnectionPoints = shape.GetConnectionPoints();

            // Display all the shape points
            foreach (var pt in ConnectionPoints)
            {
                System.Console.WriteLine(string.Format("X = {0}, Y = {1}", pt[0], pt[1]));
            }
            // ExEnd:1
            System.Console.WriteLine("GetShapeConnectionPoints executed successfully.\r\n");
        }
    }
}
