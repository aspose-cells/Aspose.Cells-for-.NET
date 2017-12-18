using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class CombineMultipleWorksheetsSingleWorksheet
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook(sourceDir + "sampleCombineMultipleWorksheetsSingleWorksheet.xlsx");

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

            destWorkbook.Save(outputDir + "outputCombineMultipleWorksheetsSingleWorksheet.xlsx");

            Console.WriteLine("CombineMultipleWorksheetsSingleWorksheet executed successfully.\r\n");
        }
    }
}
