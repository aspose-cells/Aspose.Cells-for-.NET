Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.RowsColumns.Copying
    Public Class CopyingColumns
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)


            'Create another Workbook.
            Dim excelWorkbook1 As New Workbook(dataDir & "book1.xls")

            'Get the first worksheet in the book.
            Dim ws1 As Worksheet = excelWorkbook1.Worksheets(0)

            'Copy the first column from the first worksheet of the first workbook into
            'the first worksheet of the second workbook.
            ws1.Cells.CopyColumn(ws1.Cells, ws1.Cells.Columns(0).Index, ws1.Cells.Columns(2).Index)

            'Autofit the column.
            ws1.AutoFitColumn(2)

            'Save the excel file.
            excelWorkbook1.Save(dataDir & "output.xls")
            'ExEnd:1

        End Sub
    End Class
End Namespace