Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles.CopyRowsColumns
    Public Class CopyingSingleColumn
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate a new Workbook
            ' Open an existing excel file
            Dim workbook As New Workbook(dataDir & "aspose-sample.xlsx")

            ' Get the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)
            ' Get the Cells collection
            Dim cells As Global.Aspose.Cells.Cells = worksheet.Cells
            ' Copy the first column to next 10 columns
            For i As Integer = 1 To 10
                cells.CopyColumn(cells, 0, i)
            Next i
            ' Save the excel file
            workbook.Save(dataDir & "output_out_.xlsx")
            ' ExEnd:1
        End Sub
    End Class
End Namespace