using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace Aspose.Cells.Examples.CSharp.Articles.UsingImageOrPrintOptions
{
    public class UseWorkbookRenderForImageConversion
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook(dataDir + "Testbook1.xlsx", new Aspose.Cells.LoadOptions(Aspose.Cells.LoadFormat.Xlsx));

            foreach (Worksheet ws in wb.Worksheets)
            {
                SheetRender sr = new SheetRender(ws, new ImageOrPrintOptions() { OnePagePerSheet = true, ImageFormat = ImageFormat.Jpeg });
                sr.ToImage(0, dataDir  + "Img_" + ws.Index + ".jpg");

            }
            // ExEnd:1
        }
    }
}
