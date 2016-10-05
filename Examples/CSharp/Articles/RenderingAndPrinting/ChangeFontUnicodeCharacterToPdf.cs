using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class ChangeFontUnicodeCharacterToPdf
    {
        public static void Run()
        {
            // ExStart:ChangeFontUnicodeCharacterWhileSavingToPdf
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object
            Workbook workbook = new Workbook();

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access cells
            Cell cell1 = worksheet.Cells["A1"];
            Cell cell2 = worksheet.Cells["B1"];

            // Set the styles of both cells to Times New Roman
            Style style = cell1.GetStyle();
            style.Font.Name = "Times New Roman";
            cell1.SetStyle(style);
            cell2.SetStyle(style);

            // Put the values inside the cell
            cell1.PutValue("Hello without Non-Breaking Hyphen");
            cell2.PutValue("Hello" + Convert.ToChar(8209) + " with Non-Breaking Hyphen");

            // Autofit the columns
            worksheet.AutoFitColumns();

            // Save to Pdf without setting PdfSaveOptions.IsFontSubstitutionCharGranularity
            workbook.Save(dataDir + "SampleOutput_out_.pdf");

            // Save to Pdf after setting PdfSaveOptions.IsFontSubstitutionCharGranularity to true
            PdfSaveOptions opts = new PdfSaveOptions();
            opts.IsFontSubstitutionCharGranularity = true;
            workbook.Save(dataDir + "SampleOutput2_out_.pdf", opts);
            // ExEnd:ChangeFontUnicodeCharacterWhileSavingToPdf
        }
    }
}
