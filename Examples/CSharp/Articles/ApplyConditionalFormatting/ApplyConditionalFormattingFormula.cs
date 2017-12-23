using System;
using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.ApplyConditionalFormatting
{
    public class ApplyConditionalFormattingFormula
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            Worksheet sheet = workbook.Worksheets[0];

            // Adds an empty conditional formatting
            int index = sheet.ConditionalFormattings.Add();

            FormatConditionCollection fcs = sheet.ConditionalFormattings[index];

            // Sets the conditional format range.
            CellArea ca = new CellArea();

            ca = new CellArea();

            ca.StartRow = 2;
            ca.EndRow = 2;
            ca.StartColumn = 1;
            ca.EndColumn = 1;

            fcs.AddArea(ca);

            // Adds condition.
            int conditionIndex = fcs.AddCondition(FormatConditionType.Expression);

            // Sets the background color.
            FormatCondition fc = fcs[conditionIndex];

            fc.Formula1 = "=IF(SUM(B1:B2)>100,TRUE,FALSE)";

            fc.Style.BackgroundColor = Color.Red;

            sheet.Cells["B3"].Formula = "=SUM(B1:B2)";

            sheet.Cells["C4"].PutValue("If Sum of B1:B2 is greater than 100, B3 will have Red background.");

            // Saving the Excel file
            workbook.Save(outputDir + "outputApplyConditionalFormattingFormula.xlsx");

            Console.WriteLine("ApplyConditionalFormattingFormula executed successfully.\r\n");
        }
    }
}
