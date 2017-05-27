using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.LoadingSavingConvertingAndManaging
{
    public class ConvertExcelFileToPDFA_1a
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Create workbook object
            Workbook wb = new Workbook();

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Access cell B5 and add some message inside it
            Cell cell = ws.Cells["B5"];
            cell.PutValue("This PDF format is compatible with PDFA-1a.");

            //Create pdf save options and set its compliance to PDFA-1a
            PdfSaveOptions opts = new PdfSaveOptions();
            opts.Compliance = PdfCompliance.PdfA1a;

            //Save the output pdf
            wb.Save(outputDir + "outputCompliancePdfA1a.pdf", opts);
        }
    }
}
