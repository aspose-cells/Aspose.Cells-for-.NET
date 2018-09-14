using System.IO;
using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class SetDefaultFontWhileRenderingSpreadsheet
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object.
            Workbook wb = new Workbook();

            // Set default font of the workbook to none
            Style s = wb.DefaultStyle;
            s.Font.Name = "";
            wb.DefaultStyle = s;

            // Access first worksheet.
            Worksheet ws = wb.Worksheets[0];

            // Access cell A4 and add some text inside it.
            Cell cell = ws.Cells["A4"];
            cell.PutValue("This text has some unknown or invalid font which does not exist.");

            // Set the font of cell A4 which is unknown.
            Style st = cell.GetStyle();
            st.Font.Name = "UnknownNotExist";
            st.Font.Size = 20;
            st.IsTextWrapped = true;
            cell.SetStyle(st);

            // Set first column width and fourth column height
            ws.Cells.SetColumnWidth(0, 80);
            ws.Cells.SetRowHeight(3, 60);

            // Create image or print options.
            ImageOrPrintOptions opts = new ImageOrPrintOptions();
            opts.OnePagePerSheet = true;
            opts.ImageType = Drawing.ImageType.Png;

            // Render worksheet image with Courier New as default font.
            opts.DefaultFont = "Courier New";
            SheetRender sr = new SheetRender(ws, opts);
            sr.ToImage(0, "out_courier_new_out.png");

            // Render worksheet image again with Times New Roman as default font.
            opts.DefaultFont = "Times New Roman";
            sr = new SheetRender(ws, opts);
            sr.ToImage(0, "times_new_roman_out.png");
            // ExEnd:1           
            
        }
    }
}
