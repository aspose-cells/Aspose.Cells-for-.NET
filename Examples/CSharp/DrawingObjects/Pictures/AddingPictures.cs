using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.DrawingObjects.Pictures
{
    public class AddingPictures
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Workbook object
            int sheetIndex = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[sheetIndex];

            //Adding a picture at the location of a cell whose row and column indices
            //are 5 in the worksheet. It is "F6" cell
            worksheet.Pictures.Add(5, 5, dataDir + "logo.jpg");

            //Saving the Excel file
            workbook.Save(dataDir + "output.xls");
            //ExEnd:1
        }
    }
}
