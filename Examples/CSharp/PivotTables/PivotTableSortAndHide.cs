using System;
using Aspose.Cells.Pivot;

namespace Aspose.Cells.Examples.CSharp.PivotTables
{
    class PivotTableSortAndHide
    {
        public static void Run()
        {
            // ExStart:1
            // directories
            string sourceDir = RunExamples.Get_SourceDirectory();
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook(sourceDir + "PivotTableHideAndSortSample.xlsx");

            Worksheet worksheet = workbook.Worksheets[0];

            var pivotTable = worksheet.PivotTables[0];
            var dataBodyRange = pivotTable.DataBodyRange;
            int currentRow = 3;
            int rowsUsed = dataBodyRange.EndRow;

            // Sorting score in descending
            PivotField field = pivotTable.RowFields[0];
            field.IsAutoSort = true;
            field.IsAscendSort = false;
            field.AutoSortField = 0;

            pivotTable.RefreshData();
            pivotTable.CalculateData();

            // Hiding rows with score less than 60
            while (currentRow < rowsUsed)
            {
                Cell cell = worksheet.Cells[currentRow, 1];
                double score = Convert.ToDouble(cell.Value);
                if (score < 60)
                {
                    worksheet.Cells.HideRow(currentRow);
                }
                currentRow++;
            }

            pivotTable.RefreshData();
            pivotTable.CalculateData();

            // Saving the Excel file
            workbook.Save(outputDir + "PivotTableHideAndSort_out.xlsx");
            // ExEnd:1

            Console.WriteLine("PivotTableSortAndHide executed successfully.");
        }
    }
}
