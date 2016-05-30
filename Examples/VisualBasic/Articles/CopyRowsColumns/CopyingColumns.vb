Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles.CopyRowsColumns
    Public Class CopyingColumns
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
            ' Copy the first column to the third column
            cells.CopyColumn(cells, 0, 2)
            ' Save the excel file
            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1


        End Sub
    End Class
End Namespace