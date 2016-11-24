using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.StylingAndDataFormatting
{
    public class ReusingStyleObjects
    {
        public static void Run()
        {
            // ExStart:ReusingStyleObjects
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
            Style styleObject = workbook.CreateStyle();
            styleObject.Font.Color = System.Drawing.Color.Red;
            styleObject.Font.Name = "Times New Roman";
            cell1.SetStyle(styleObject);
            cell2.SetStyle(styleObject);

            // Put the values inside the cell
            cell1.PutValue("Hello World!");
            cell2.PutValue("Hello World!!");

            // Save to Pdf without setting PdfSaveOptions.IsFontSubstitutionCharGranularity
            workbook.Save(dataDir + "SampleOutput_out.xlsx");
            // ExEnd:ReusingStyleObjects
        }
    }
}
