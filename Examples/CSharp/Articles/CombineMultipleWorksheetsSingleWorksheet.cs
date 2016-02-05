using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class CombineMultipleWorksheetsSingleWorksheet
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string filePath = dataDir+ "SampleInput.xlsx";

            Workbook workbook = new Workbook(filePath);

            Workbook destWorkbook = new Workbook();

            Worksheet destSheet = destWorkbook.Worksheets[0];

            int TotalRowCount = 0;

            for (int i = 0; i < workbook.Worksheets.Count; i++)
            {
                Worksheet sourceSheet = workbook.Worksheets[i];

                Range sourceRange = sourceSheet.Cells.MaxDisplayRange;

                Range destRange = destSheet.Cells.CreateRange(sourceRange.FirstRow + TotalRowCount, sourceRange.FirstColumn,
                      sourceRange.RowCount, sourceRange.ColumnCount);

                destRange.Copy(sourceRange);

                TotalRowCount = sourceRange.RowCount + TotalRowCount;
            }

            destWorkbook.Save(dataDir+ "Output.out.xlsx");
            
            
        }
    }
}