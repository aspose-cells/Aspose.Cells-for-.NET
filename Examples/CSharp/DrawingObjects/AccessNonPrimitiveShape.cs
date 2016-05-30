using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Collections;
 

namespace CSharp.DrawingObjects
{
    public class AccessNonPrimitiveShape
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

           /* string filePath = dataDir + "Book.xlsx";

            Workbook workbook = new Workbook(filePath);

            Worksheet worksheet = workbook.Worksheets[0];

            // Accessing the user defined shape
            Shape shape = worksheet.Shapes[0];
       
            if (shape.AutoShapeType == AutoShapeType.NotPrimitive)
            {
                // Access shape's data
                Aspose.Cells.Drawing.GeomPathsInfo geomPathsInfo = shape.PathsInfo;

                // Access path list
                ArrayList pathList = geomPathsInfo.PathList;

                // Access information of indvidual path info
                Aspose.Cells.Drawing.GeomPathInfo pathInfo = pathList[0] as Aspose.Cells.Drawing.GeomPathInfo;

                // Access path segment list
                ArrayList pathSegments = pathInfo.PathSegementList;

                // Access individual path segment
                MsoPathInfo pathSegment = pathSegments[0] as MsoPathInfo;

                // Access segment points
                ArrayList segmentPoints = pathSegment.PointList;

                // Access indvidual point of the segment
                System.Drawing.Point indvidualPoint = (System.Drawing.Point)segmentPoints[0];
            }
            // ExEnd:1
            */

        }
    }
}