using System.IO;

using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.Drawing;

namespace Aspose.Cells.Examples.Articles.ConvertingWorksheetToImage
{
    public class ConvertWorksheettoImageFile
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create a new Workbook object
            //Open a template excel file
            Workbook book = new Workbook(dataDir+ "Testbook.xlsx");
            //Get the first worksheet.
            Worksheet sheet = book.Worksheets[0];

            //Define ImageOrPrintOptions
            ImageOrPrintOptions imgOptions = new ImageOrPrintOptions();
            //Specify the image format
            imgOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            //Render the sheet with respect to specified image/print options
            SheetRender sr = new SheetRender(sheet, imgOptions);
            //Render the image for the sheet
            Bitmap bitmap = sr.ToImage(0);

            //Save the image file
            bitmap.Save(dataDir+ "SheetImage.jpg");
            
            
        }
    }
}