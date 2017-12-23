using System;
using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ApplyConditionalFormattingCellValue
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            Worksheet sheet = workbook.Worksheets[0];

            //Enter message in cell B4
            sheet.Cells["B4"].PutValue("Cell A1 will become Red when you will enter some value between 50 and 100.");

            // Adds an empty conditional formatting
            int index = sheet.ConditionalFormattings.Add();

            FormatConditionCollection fcs = sheet.ConditionalFormattings[index];

            // Sets the conditional format range.
            CellArea ca = new CellArea();

            ca.StartRow = 0;
            ca.EndRow = 0;
            ca.StartColumn = 0;
            ca.EndColumn = 0;

            fcs.AddArea(ca);

            // Adds condition.
            int conditionIndex = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "50", "100");

            // Sets the background color.
            FormatCondition fc = fcs[conditionIndex];

            fc.Style.BackgroundColor = Color.Red;

            // Saving the Excel file
            workbook.Save(outputDir + "outputApplyConditionalFormattingCellValue.xlsx");

            Console.WriteLine("ApplyConditionalFormattingCellValue executed successfully.\r\n");
        }
    }
}
