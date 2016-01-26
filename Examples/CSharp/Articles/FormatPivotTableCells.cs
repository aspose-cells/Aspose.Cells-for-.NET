using System.IO;

using Aspose.Cells;
using Aspose.Cells.Pivot;
using System.Drawing;

namespace Aspose.Cells.Examples.Articles
{
    public class FormatPivotTableCells
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string filePath = dataDir + "pivotTable_test.xlsx";

            //Create workbook object from source file containing pivot table
            Workbook workbook = new Workbook(filePath);

            //Access the worksheet by its name
            Worksheet worksheet = workbook.Worksheets["PivotTable"];

            //Access the pivot table
            PivotTable pivotTable = worksheet.PivotTables[0];

            //Create a style object with background color light blue
            Style style = workbook.CreateStyle();
            style.Pattern = BackgroundType.Solid;
            style.BackgroundColor = Color.LightBlue;

            //Format entire pivot table with light blue color
            pivotTable.FormatAll(style);

            //Create another style object with yellow color
            style = workbook.CreateStyle();
            style.Pattern = BackgroundType.Solid;
            style.BackgroundColor = Color.Yellow;

            //Format the cells of the first row of the pivot table with yellow color
            for (int col = 0; col < 5; col++)
            {
                pivotTable.Format(1, col, style);
            }

            //Save the workbook object
            workbook.Save(dataDir+ "output.xlsx");
            
        }
    }
}