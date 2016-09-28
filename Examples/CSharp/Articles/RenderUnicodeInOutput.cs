using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class RenderUnicodeInOutput
    {
        public static void Run()
        {
            // ExStart:RenderUnicodeInOutput
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); 

            // Load your source excel file containing Unicode Supplementary characters
            Workbook wb = new Workbook(dataDir + "unicode-supplementary-characters.xlsx");

            // Save the workbook
            wb.Save(dataDir + "RenderUnicodeInOutput_out_.pdf");
            // ExEnd:RenderUnicodeInOutput
        }
    }
}