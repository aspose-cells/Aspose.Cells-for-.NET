using Aspose.Cells;
using Aspose.Cells.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worksheet_to_image_file_by_Page
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyDir = @"Files\";
            Workbook book = new Workbook(MyDir + "Sheet to Image by Page.xls");
            Worksheet sheet = book.Worksheets[0];
            Aspose.Cells.Rendering.ImageOrPrintOptions options = new Aspose.Cells.Rendering.ImageOrPrintOptions();
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;
            options.ImageFormat = System.Drawing.Imaging.ImageFormat.Tiff;

            //Sheet2Image By Page conversion
            SheetRender sr = new SheetRender(sheet, options);
            for (int j = 0; j < sr.PageCount; j++)
            {

                Bitmap pic = sr.ToImage(j);
                pic.Save(MyDir + sheet.Name + " Page" + (j + 1) + ".tiff");
            }

        }
    }
}
