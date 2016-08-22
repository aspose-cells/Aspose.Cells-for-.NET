using System.IO;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class SetDefaultFontWhileRendering
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                        
            // Create workbook object and access first worksheet.
            Workbook wb = new Workbook();
            Worksheet ws = wb.Worksheets[0];

            // Access cell B4 and add some text inside it.
            Cell cell = ws.Cells["B4"];
            cell.PutValue("This text has some unknown or invalid font which does not exist.");

            // Set the font of cell B4 which is unknown.
            Style st = cell.GetStyle();
            st.Font.Name = "UnknownNotExist";
            st.Font.Size = 20;
            cell.SetStyle(st);

            // Now save the workbook in html format and set the default font to Courier New.
            HtmlSaveOptions opts = new HtmlSaveOptions();
            opts.DefaultFontName = "Courier New";
            wb.Save(dataDir + "out_courier_new_out_.htm", opts);

            // Now save the workbook in html format once again but set the default font to Arial.
            opts.DefaultFontName = "Arial";
            wb.Save(dataDir + "out_arial_out_.htm", opts);

            // Now save the workbook in html format once again but set the default font to Times New Roman.
            opts.DefaultFontName = "Times New Roman";
            wb.Save(dataDir + "times_new_roman_out_.htm", opts);
            // ExEnd:1           
            
        }
    }
}
