using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class CombineMultipleWorksheetsSingleWorksheet
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
            dataDir = dataDir + "Output.out.xlsx";
            destWorkbook.Save(dataDir);
            // ExEnd:1
            Console.WriteLine("\nProcess completed successfully.\nFile saved at " + dataDir);            
        }
    }
}
