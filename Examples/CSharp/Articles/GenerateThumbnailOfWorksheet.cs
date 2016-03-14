using System.IO;

using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.Drawing;

namespace Aspose.Cells.Examples.Articles
{
    public class GenerateThumbnailOfWorksheet
    {
        public static void Main()
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Instantiate and open an Excel file
            Workbook book = new Workbook(dataDir+ "book1.xlsx");

            //Define ImageOrPrintOptions
            ImageOrPrintOptions imgOptions = new ImageOrPrintOptions();
            //Specify the image format
            imgOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            //Set the vertical and horizontal resolution
            imgOptions.VerticalResolution = 200;
            imgOptions.HorizontalResolution = 200;
            //One page per sheet is enabled
            imgOptions.OnePagePerSheet = true;

            //Get the first worksheet
            Worksheet sheet = book.Worksheets[0];
            //Render the sheet with respect to specified image/print options
            SheetRender sr = new SheetRender(sheet, imgOptions);
            //Render the image for the sheet
            Bitmap bmp = sr.ToImage(0);
            //Create a bitmap
            Bitmap thumb = new Bitmap(100, 100);
            //Get the graphics for the bitmap
            System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(thumb);

            //Draw the image
            gr.DrawImage(bmp, 0, 0, 100, 100);

            //Save the thumbnail
            thumb.Save(dataDir+ "mythumbnail.out.bmp");
            //ExEnd:1
            
            
        }
    }
}
