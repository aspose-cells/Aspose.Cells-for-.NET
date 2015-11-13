using Aspose.Cells;
using Aspose.Cells.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worksheet_to_Image
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyDir = @"Files\";

            //Create a new Workbook object
            //Open a template excel file
            Workbook book = new Workbook(MyDir+"Sheet to Image.xls");
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
            bitmap.Save(MyDir+"SheetImage.jpg");
        }
    }
}
