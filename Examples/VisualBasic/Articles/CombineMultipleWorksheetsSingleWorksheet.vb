Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles
    Public Class CombineMultipleWorksheetsSingleWorksheet
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim filePath As String = dataDir & "SampleInput.xlsx"

            Dim workbook As New Workbook(filePath)

            Dim destWorkbook As New Workbook()

            Dim destSheet As Worksheet = destWorkbook.Worksheets(0)

            Dim TotalRowCount As Integer = 0

            For i As Integer = 0 To workbook.Worksheets.Count - 1
                Dim sourceSheet As Worksheet = workbook.Worksheets(i)

                Dim sourceRange As Range = sourceSheet.Cells.MaxDisplayRange

                Dim destRange As Range = destSheet.Cells.CreateRange(sourceRange.FirstRow + TotalRowCount, sourceRange.FirstColumn, sourceRange.RowCount, sourceRange.ColumnCount)

                destRange.Copy(sourceRange)

                TotalRowCount = sourceRange.RowCount + TotalRowCount
            Next i

            destWorkbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1


        End Sub
    End Class
End Namespace