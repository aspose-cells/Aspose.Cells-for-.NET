Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingRowsColumnsCells
    Public Class HowAndWhereToUseEnumerators
        Public Shared Sub Run()
            ' ExStart:CellsEnumerator
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load a file in an instance of Workbook
            Dim book = New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Get the enumerator from Cells collection
            Dim cellEnumerator As IEnumerator = book.Worksheets(0).Cells.GetEnumerator()
            ' Traverse cells in the collection
            While cellEnumerator.MoveNext()
                Dim cell = TryCast(cellEnumerator.Current, Aspose.Cells.Cell)
                Console.WriteLine(cell.Name + " " + cell.Value)
            End While

            ' Get enumerator from an object of Row
            Dim rowEnumerator As IEnumerator = book.Worksheets(0).Cells.Rows(0).GetEnumerator()
            ' Traverse cells in the given row
            While rowEnumerator.MoveNext()
                Dim cell = TryCast(rowEnumerator.Current, Aspose.Cells.Cell)
                Console.WriteLine(cell.Name + " " + cell.Value)
            End While

            ' Get enumerator from an object of Range
            Dim rangeEnumerator As IEnumerator = book.Worksheets(0).Cells.CreateRange("A1:B10").GetEnumerator()
            ' Traverse cells in the range
            While rangeEnumerator.MoveNext()
                Dim cell = TryCast(rangeEnumerator.Current, Aspose.Cells.Cell)
                Console.WriteLine(cell.Name + " " + cell.Value)
            End While
            ' ExEnd:CellsEnumerator

            ' ExStart:RowEnumerator
            ' Get the enumerator for RowCollection
            Dim rowsEnumerator As IEnumerator = book.Worksheets(0).Cells.Rows.GetEnumerator()
            ' Traverse rows in the collection
            While rowsEnumerator.MoveNext()
                Dim row = TryCast(rowsEnumerator.Current, Aspose.Cells.Row)
                Console.WriteLine(row.Index)
            End While
            ' ExEnd:RowEnumerator

            ' ExStart:ColumnEnumerator
            ' Get the enumerator for ColumnsCollection
            Dim colsEnumerator As IEnumerator = book.Worksheets(0).Cells.Columns.GetEnumerator()
            ' Traverse columns in the collection
            While colsEnumerator.MoveNext()
                Dim col = TryCast(colsEnumerator.Current, Aspose.Cells.Column)
                Console.WriteLine(col.Index)
            End While
            ' ExEnd:ColumnEnumerator

            ' ExStart:UsingDisplayRange
            ' Get Cells collection of first worksheet
            Dim cells = book.Worksheets(0).Cells

            ' Get the MaxDisplayRange
            Dim displayRange = cells.MaxDisplayRange

            ' Loop over all cells in the MaxDisplayRange
            For row As Integer = displayRange.FirstRow To displayRange.RowCount - 1
                For col As Integer = displayRange.FirstColumn To displayRange.ColumnCount - 1
                    ' Read the Cell value
                    Console.WriteLine(displayRange(row, col).StringValue)
                Next
            Next
            ' ExEnd:UsingDisplayRange

            ' ExStart:UsingMaxDataRowAndMaxDataColumn
            ' Get Cells collection of first worksheet
            Dim cells2 = book.Worksheets(0).Cells

            ' Loop over all cells
            For row As Integer = 0 To cells2.MaxDataRow - 1
                For col As Integer = 0 To cells2.MaxDataColumn - 1
                    ' Read the Cell value
                    Console.WriteLine(cells2(row, col).StringValue)
                Next
            Next
            ' ExEnd:UsingMaxDataRowAndMaxDataColumn
        End Sub
    End Class
End Namespace