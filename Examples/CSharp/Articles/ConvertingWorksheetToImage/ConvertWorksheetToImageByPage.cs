using System.IO;

using Aspose.Cells;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.Articles.ConvertingWorksheetToImage
{
    public class ConvertWorksheetToImageByPage
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook book = new Workbook(dataDir+ "TestData.xlsx");
            Worksheet sheet = book.Worksheets[0];
            Aspose.Cells.Rendering.ImageOrPrintOptions options = new Aspose.Cells.Rendering.ImageOrPrintOptions();
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;
            options.ImageFormat = System.Drawing.Imaging.ImageFormat.Tiff;

            //Sheet2Image By Page conversion
            SheetRender sr = new SheetRender(sheet, options);
            for (int j = 0; j < sr.PageCount; j++)
            {

                sr.ToImage(j, dataDir+ "test" + sheet.Name + " Page" + (j + 1) + ".out.tif");
            }
 
            
                       
        }
    }
}