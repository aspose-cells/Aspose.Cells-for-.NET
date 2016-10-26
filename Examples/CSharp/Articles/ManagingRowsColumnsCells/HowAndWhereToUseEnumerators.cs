using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingRowsColumnsCells
{
    public class HowAndWhereToUseEnumerators
    {
        public static void Run()
        {
            // ExStart:CellsEnumerator
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load a file in an instance of Workbook
            var book = new Workbook(dataDir + "sample.xlsx");

            // Get the enumerator from Cells collection
            IEnumerator cellEnumerator = book.Worksheets[0].Cells.GetEnumerator();
            // Traverse cells in the collection
            while (cellEnumerator.MoveNext())
            {
                var cell = cellEnumerator.Current as Aspose.Cells.Cell;
                Console.WriteLine(cell.Name + " " + cell.Value);
            }

            // Get enumerator from an object of Row
            IEnumerator rowEnumerator = book.Worksheets[0].Cells.Rows[0].GetEnumerator();
            // Traverse cells in the given row
            while (rowEnumerator.MoveNext())
            {
                var cell = rowEnumerator.Current as Aspose.Cells.Cell;
                Console.WriteLine(cell.Name + " " + cell.Value);
            }

            // Get enumerator from an object of Range
            IEnumerator rangeEnumerator = book.Worksheets[0].Cells.CreateRange("A1:B10").GetEnumerator();
            // Traverse cells in the range
            while (rangeEnumerator.MoveNext())
            {
                var cell = rangeEnumerator.Current as Aspose.Cells.Cell;
                Console.WriteLine(cell.Name + " " + cell.Value);
            }
            // ExEnd:CellsEnumerator

            // ExStart:RowEnumerator
            // Get the enumerator for RowCollection
            IEnumerator rowsEnumerator = book.Worksheets[0].Cells.Rows.GetEnumerator();
            // Traverse rows in the collection
            while (rowsEnumerator.MoveNext())
            {
                var row = rowsEnumerator.Current as Aspose.Cells.Row;
                Console.WriteLine(row.Index);
            }
            // ExEnd:RowEnumerator

            // ExStart:ColumnEnumerator
            // Get the enumerator for ColumnsCollection
            IEnumerator colsEnumerator = book.Worksheets[0].Cells.Columns.GetEnumerator();
            // Traverse columns in the collection
            while (colsEnumerator.MoveNext())
            {
                var col = colsEnumerator.Current as Aspose.Cells.Column;
                Console.WriteLine(col.Index);
            }
            // ExEnd:ColumnEnumerator

            // ExStart:UsingDisplayRange
            // Get Cells collection of first worksheet
            var cells = book.Worksheets[0].Cells;

            // Get the MaxDisplayRange
            var displayRange = cells.MaxDisplayRange;

            // Loop over all cells in the MaxDisplayRange
            for (int row = displayRange.FirstRow; row < displayRange.RowCount; row++)
            {
                for (int col = displayRange.FirstColumn; col < displayRange.ColumnCount; col++)
                {
                    // Read the Cell value
                    Console.WriteLine(displayRange[row, col].StringValue);
                }
            }
            // ExEnd:UsingDisplayRange

            // ExStart:UsingMaxDataRowAndMaxDataColumn
            // Get Cells collection of first worksheet
            var cells2 = book.Worksheets[0].Cells;

            // Loop over all cells
            for (int row = 0; row < cells2.MaxDataRow; row++)
            {
                for (int col = 0; col < cells2.MaxDataColumn; col++)
                {
                    // Read the Cell value
                    Console.WriteLine(cells2[row, col].StringValue);
                }
            }
            // ExEnd:UsingMaxDataRowAndMaxDataColumn
        }
    }
}
