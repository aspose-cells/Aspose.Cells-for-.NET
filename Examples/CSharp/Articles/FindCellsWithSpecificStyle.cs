using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class FindCellsWithSpecificStyle
    {
        public static void Main()
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string filePath = dataDir+ "TestBook.xlsx";

            Workbook workbook = new Workbook(filePath);

            Worksheet worksheet = workbook.Worksheets[0];

            //Access the style of cell A1
            Style style = worksheet.Cells["A1"].GetStyle();

            //Specify the style for searching
            FindOptions options = new FindOptions();
            options.Style = style;

            Cell nextCell = null;

            do
            {
                //Find the cell that has a style of cell A1
                nextCell = worksheet.Cells.Find(null, nextCell, options);

                if (nextCell == null)
                    break;

                //Change the text of the cell
                nextCell.PutValue("Found");

            } while (true);

            workbook.Save(dataDir+ "output.out.xlsx");
            //ExEnd:1

            
        }
    }
}
