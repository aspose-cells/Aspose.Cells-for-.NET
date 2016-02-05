using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.Articles.ApplyConditionalFormatting
{
    public class ApplyConditionalFormattingCellValue
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            Worksheet sheet = workbook.Worksheets[0];

            //Adds an empty conditional formatting
            int index = sheet.ConditionalFormattings.Add();

            FormatConditionCollection fcs = sheet.ConditionalFormattings[index];

            //Sets the conditional format range.
            CellArea ca = new CellArea();

            ca.StartRow = 0;
            ca.EndRow = 0;
            ca.StartColumn = 0;
            ca.EndColumn = 0;

            fcs.AddArea(ca);

            //Adds condition.
            int conditionIndex = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "50", "100");

            //Sets the background color.
            FormatCondition fc = fcs[conditionIndex];

            fc.Style.BackgroundColor = Color.Red;

            //Saving the Excel file
            workbook.Save(dataDir+ "output.out.xls", SaveFormat.Auto);
            
            
        }
    }
}