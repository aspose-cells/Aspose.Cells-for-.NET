using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects.Pictures.PositioningPictures
{
    public class AbsolutePositioning
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Adding a new worksheet to the Workbook object
            int sheetIndex = workbook.Worksheets.Add();

            // Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[sheetIndex];

            // Adding a picture at the location of a cell whose row and column indices
            // Are 5 in the worksheet. It is "F6" cell
            int pictureIndex = worksheet.Pictures.Add(5, 5, dataDir + "logo.jpg");

            // Accessing the newly added picture
            Aspose.Cells.Drawing.Picture picture = worksheet.Pictures[pictureIndex];

            // Absolute positioning of the picture in unit of pixels
            picture.Left = 60;
            picture.Top = 10;

            // Saving the Excel file
            workbook.Save(dataDir + "book1.out.xls");
            // ExEnd:1

        }
    }
}
