using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.LoadingSavingConvertingAndManaging
{
    class SaveWorkbookToStrictOpenXMLSpreadsheetFormat 
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // Create workbook.
            Workbook wb = new Workbook();

            // Specify - Strict Open XML Spreadsheet - Format.
            wb.Settings.Compliance = OoxmlCompliance.Iso29500_2008_Strict;

            // Add message in cell B4 of first worksheet.
            Cell b4 = wb.Worksheets[0].Cells["B4"];
            b4.PutValue("This Excel file has Strict Open XML Spreadsheet format.");

            // Save to output Excel file.
            wb.Save(outputDir + "outputSaveWorkbookToStrictOpenXMLSpreadsheetFormat.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("SaveWorkbookToStrictOpenXMLSpreadsheetFormat executed successfully.");
        }
    }
}
