using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageConditionalFormatting
{
    public class ApplyShadingToAlternateRowsColumns
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create an instance of Workbook or load existing
            var book = new Workbook();

            // Access the Worksheet on which desired rule has to be applied
            var sheet = book.Worksheets[0];

            // Add FormatConditions to the instance of Worksheet
            int idx = sheet.ConditionalFormattings.Add();

            // Access the newly added FormatConditions via its index
            var conditionCollection = sheet.ConditionalFormattings[idx];

            // Define a CellsArea on which conditional formatting will be applicable
            // The code creates a CellArea ranging from A1 to I20
            var area = CellArea.CreateCellArea("A1", "I20");

            //Add area to the instance of FormatConditions
            conditionCollection.AddArea(area);

            // Add a condition to the instance of FormatConditions
            // For this case, the condition type is expression, which is based on some formula
            idx = conditionCollection.AddCondition(FormatConditionType.Expression);

            // Access the newly added FormatCondition via its index
            FormatCondition formatCondirion = conditionCollection[idx];

            // Set the formula for the FormatCondition
            // Formula uses the Excel's built-in functions as discussed earlier in this article
            formatCondirion.Formula1 = @"=MOD(ROW(),2)=0";

            // Set the background color and patter for the FormatCondition's Style
            formatCondirion.Style.BackgroundColor = Color.Blue;
            formatCondirion.Style.Pattern = BackgroundType.Solid;

            // Save the result on disk
            book.Save(dataDir + "output_out.xlsx");
            // ExEnd:1
        }
    }
}
