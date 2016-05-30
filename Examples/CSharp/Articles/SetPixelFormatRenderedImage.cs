using System.IO;

using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace CSharp.Articles
{
    public class SetPixelFormatRenderedImage
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate a new Workbook
            // Load an Excel file
            Workbook wb = new Workbook(dataDir+ "Book1.xlsx");
            // Instantiate SheetRender object based on the first worksheet
            // Set the ImageOrPrintOptions with desired pixel format (24 bits per pixel) and image format type
            SheetRender sr = new SheetRender(wb.Worksheets[0], new ImageOrPrintOptions { PixelFormat = PixelFormat.Format24bppRgb, ImageFormat = ImageFormat.Tiff });
            // Save the image (first page of the sheet) with the specified options
            sr.ToImage(0, dataDir+ "outImage1.out.tiff");
 
        }
    }
}