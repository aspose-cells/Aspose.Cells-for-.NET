using System.IO;

using Aspose.Cells;
using System.Drawing;
using Aspose.Cells.Pivot;

namespace Aspose.Cells.Examples.PivotTableExamples
{
    public class FormattingLook
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Load a template file
            Workbook workbook = new Workbook(dataDir + "Book1.xls");

            //Get the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];
            var pivot = workbook.Worksheets[0].PivotTables[0];

            pivot.PivotTableStyleType = PivotTableStyleType.PivotTableStyleDark1;

            Style style = workbook.CreateStyle();
            style.Font.Name = "Arial Black";
            style.ForegroundColor = Color.Yellow;
            style.Pattern = BackgroundType.Solid;

            pivot.FormatAll(style);

            //Saving the Excel file
            workbook.Save(dataDir + "output.xls");

            //ExEnd:1

        }
    }
}