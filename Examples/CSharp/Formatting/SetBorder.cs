using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Formatting
{
    public class SetBorder
    {
        // ExStart:1
        public static void Run()
        {
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
            fc.Style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Dashed;
            fc.Style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Dashed;
            fc.Style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Dashed;
            fc.Style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Dashed;

            fc.Style.Borders[BorderType.LeftBorder].Color = Color.FromArgb(0, 255, 255);
            fc.Style.Borders[BorderType.RightBorder].Color = Color.FromArgb(0, 255, 255);
            fc.Style.Borders[BorderType.TopBorder].Color = Color.FromArgb(0, 255, 255);
            fc.Style.Borders[BorderType.BottomBorder].Color = Color.FromArgb(255, 255, 0);
            workbook.Save(dataDir + "output.xlsx");
            // ExEnd:1

        }
    }
}