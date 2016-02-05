using System.IO;

using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace Aspose.Cells.Examples.Articles
{
    public class CreateTransparentImage
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create workbook object from source file
            Workbook wb = new Workbook(dataDir+ "aspose-sample.xlsx");

            //Apply different image or print options
            var imgOption = new ImageOrPrintOptions();
            imgOption.ImageFormat = ImageFormat.Png;
            imgOption.HorizontalResolution = 200;
            imgOption.VerticalResolution = 200;
            imgOption.OnePagePerSheet = true;

            //Apply transparency to the output image
            imgOption.Transparent = true;

            //Create image after apply image or print options
            var sr = new SheetRender(wb.Worksheets[0], imgOption);
            sr.ToImage(0, dataDir+ "output.out.png");

        }
    }
}