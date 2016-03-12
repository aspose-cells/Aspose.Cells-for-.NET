using System.IO;
using System.Drawing;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles.CopyShapesBetweenWorksheets
{
    public class CopyingPicture
    {
        public static void Main()
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create a workbook object
            //Open the template file
            Workbook workbook = new Workbook(dataDir+ "aspose-sample.xlsx");

            //Get the Picture from the "Picture" worksheet.
            Aspose.Cells.Drawing.Picture source = workbook.Worksheets["Sheet1"].Pictures[0];

            //Save Picture to Memory Stream
            MemoryStream ms = new MemoryStream(source.Data);

            //Copy the picture to the Result Worksheet
            workbook.Worksheets["Sheet2"].Pictures.Add(source.UpperLeftRow, source.UpperLeftColumn, ms, source.WidthScale, source.HeightScale);

            //Save the Worksheet
            workbook.Save(dataDir+ "Shapes.out.xlsx");
            //ExEnd:1
            
        }
    }
}
