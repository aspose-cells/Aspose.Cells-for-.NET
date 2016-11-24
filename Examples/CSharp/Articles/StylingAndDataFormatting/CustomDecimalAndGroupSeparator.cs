using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.StylingAndDataFormatting
{
    public class CustomDecimalAndGroupSeparator
    {
        public static void Run()
        {
            // ExStart:CustomDecimalAndGroupSeparator
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook workbook = new Workbook();

            // Specify custom separators
            workbook.Settings.NumberDecimalSeparator = '.';
            workbook.Settings.NumberGroupSeparator = ' ';

            Worksheet worksheet = workbook.Worksheets[0];

            // Set cell value
            Cell cell = worksheet.Cells["A1"];
            cell.PutValue(123456.789);

            // Set custom cell style
            Style style = cell.GetStyle();
            style.Custom = "#,##0.000;[Red]#,##0.000";
            cell.SetStyle(style);

            worksheet.AutoFitColumns();

            // Save workbook as pdf
            workbook.Save(dataDir + "CustomSeparator_out.pdf");
            // ExEnd:CustomDecimalAndGroupSeparator
        }
    }
}
