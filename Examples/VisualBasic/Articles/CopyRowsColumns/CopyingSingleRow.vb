Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles.CopyRowsColumns
    Public Class CopyingSingleRow
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate a new workbook
            ' Open an existing excel file
            Dim workbook As New Workbook(dataDir & "aspose-sample.xlsx")

            ' Get the first worksheet cells
            Dim cells As Global.Aspose.Cells.Cells = workbook.Worksheets(0).Cells
            ' Copy the first row to next 10 rows
            For i As Integer = 1 To 10
                cells.CopyRow(cells, 0, i)
            Next i
            ' Save the excel file
            workbook.Save(dataDir & "output_out.xlsx")
            ' ExEnd:1

        End Sub
    End Class
End Namespace