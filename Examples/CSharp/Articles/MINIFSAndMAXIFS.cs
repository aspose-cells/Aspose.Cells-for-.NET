using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class MINIFSAndMAXIFS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load your source workbook containing MINIFS and MAXIFS functions
            Workbook wb = new Workbook(dataDir + "sample_MINIFS_MAXIFS.xlsx");

            // Perform Aspose.Cells formula calculation
            wb.CalculateFormula();

            // Save the calculations result in pdf format
            PdfSaveOptions opts = new PdfSaveOptions();
            opts.OnePagePerSheet = true;
            wb.Save(dataDir + "output_out.pdf", opts);
            // ExEnd:1
        }
    }
}
