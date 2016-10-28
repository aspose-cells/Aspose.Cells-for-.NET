using System.IO;
using Aspose.Cells;
using System.Diagnostics;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    // ExStart:1
    public class GetWarningsForFontSubstitution : IWarningCallback
    {
        public void Warning(WarningInfo info)
        {
            if (info.WarningType == WarningType.FontSubstitution)
            {
                Debug.WriteLine("WARNING INFO: " + info.Description);
            }
        }

        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Workbook workbook = new Workbook(dataDir + "source.xlsx");

            PdfSaveOptions options = new PdfSaveOptions();
            options.WarningCallback = new GetWarningsForFontSubstitution();
            dataDir = dataDir + "output_out_.pdf";
            workbook.Save(dataDir, options);
        }
    }
    // ExEnd:1
}



            
      
