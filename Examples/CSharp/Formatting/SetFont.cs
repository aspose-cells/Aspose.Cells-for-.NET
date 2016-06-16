using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Formatting
{
    public class SetFont
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();
            Worksheet sheet = workbook.Worksheets[0];

            // Adds an empty conditional formatting
            int index = sheet.ConditionalFormattings.Add();
            FormatConditionCollection fcs = sheet.ConditionalFormattings[index];

            // Sets the conditional format range.
            CellArea ca = new CellArea();
            ca.StartRow = 0;
            ca.EndRow = 5;
            ca.StartColumn = 0;
            ca.EndColumn = 3;
            fcs.AddArea(ca);

            // Adds condition.
            int conditionIndex = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "50", "100");

            // Sets the background color.
            FormatCondition fc = fcs[conditionIndex];
           // fc.Style.BackgroundColor = Color.Red;

            fc.Style.Font.IsItalic = true;
            fc.Style.Font.IsBold = true;
            fc.Style.Font.IsStrikeout = true;
            fc.Style.Font.Underline = FontUnderlineType.Double;
            fc.Style.Font.Color = Color.Black;
            workbook.Save(dataDir + "output.xlsx");
            // ExEnd:1
        }
    }
}