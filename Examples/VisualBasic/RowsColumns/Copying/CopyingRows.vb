Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace RowsColumns.Copying
    Public Class CopyingRows
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open the existing excel file.
            Dim excelWorkbook1 As New Workbook(dataDir & "book1.xls")

            ' Get the first worksheet in the workbook.
            Dim wsTemplate As Worksheet = excelWorkbook1.Worksheets(0)

            ' Copy the second row with data, formattings, images and drawing objects
            ' To the 16th row in the worksheet.
            wsTemplate.Cells.CopyRow(wsTemplate.Cells, 1, 15)

            ' Save the excel file.
            excelWorkbook1.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace