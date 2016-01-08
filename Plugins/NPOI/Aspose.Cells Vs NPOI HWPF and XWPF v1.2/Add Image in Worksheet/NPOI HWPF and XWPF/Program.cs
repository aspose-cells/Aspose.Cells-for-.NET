using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NPOI_HWPF_and_XWPF
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorkbook wb = new XSSFWorkbook();
            ISheet sheet1 = wb.CreateSheet("First Sheet");

           //add picture data to this workbook.
            byte[] bytes = File.ReadAllBytes("../../data/aspose.png");
            int pictureIdx = wb.AddPicture(bytes, PictureType.PNG);

            ICreationHelper helper = wb.GetCreationHelper();

            // Create the drawing patriarch.  This is the top level container for all shapes.
            IDrawing drawing = sheet1.CreateDrawingPatriarch();

            // add a picture shape
            IClientAnchor anchor = helper.CreateClientAnchor();

            //set top-left corner of the picture,
            //subsequent call of Picture#resize() will operate relative to it
            anchor.Col1 = 3;
            anchor.Row1 = 2;
            IPicture pict = drawing.CreatePicture(anchor, pictureIdx);
            //auto-size picture relative to its top-left corner
            pict.Resize();

            FileStream sw = File.Create("../../data/image.xlsx");
            wb.Write(sw);
            sw.Close();
        }
    }
}
