using System.IO;

using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace Aspose.Cells.Examples.Articles
{
    public class ExportRangeofCells
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string filePath = dataDir+ "aspose-sample.xlsx";

            //Create workbook from source file.
            Workbook workbook = new Workbook(filePath);

            //Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Set the print area with your desired range
            worksheet.PageSetup.PrintArea = "E12:H16";

            //Set all margins as 0
            worksheet.PageSetup.LeftMargin = 0;
            worksheet.PageSetup.RightMargin = 0;
            worksheet.PageSetup.TopMargin = 0;
            worksheet.PageSetup.BottomMargin = 0;

            //Set OnePagePerSheet option as true
            ImageOrPrintOptions options = new ImageOrPrintOptions();
            options.OnePagePerSheet = true;
            options.ImageFormat = ImageFormat.Jpeg;

            //Take the image of your worksheet
            SheetRender sr = new SheetRender(worksheet, options);
            sr.ToImage(0, dataDir+ "output.out.jpg");
            
            
        }
    }
}