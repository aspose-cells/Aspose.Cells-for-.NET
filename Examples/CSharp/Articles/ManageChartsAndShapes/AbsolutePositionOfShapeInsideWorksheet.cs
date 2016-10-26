using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class AbsolutePositionOfShapeInsideWorksheet
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load the sample Excel file inside the workbook object
            Workbook workbook = new Workbook(dataDir + "sample.xlsx");

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access the first shape inside the worksheet
            Shape shape = worksheet.Shapes[0];

            // Displays the absolute position of the shape
            Console.WriteLine("Absolute Position of this Shape is ({0} , {1})", shape.LeftToCorner, shape.TopToCorner);
            // ExEnd:1
        }
    }
}
