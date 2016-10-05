using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class SaveExcelIntoPdfWithOptimizedSize
    {
        public static void Run()
        {
            // ExStart:SaveExcelIntoPdfWithOptimizedSize
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load excel file into workbook object
            Workbook workbook = new Workbook(dataDir + "SampleBook.xlsx");

            // Save into Pdf with Minimum size
            PdfSaveOptions opts = new PdfSaveOptions();
            opts.OptimizationType = Aspose.Cells.Rendering.PdfOptimizationType.MinimumSize;

            workbook.Save(dataDir + "OptimizedOutput_out_.pdf", opts);
            // ExEnd:SaveExcelIntoPdfWithOptimizedSize
        }
    }
}
