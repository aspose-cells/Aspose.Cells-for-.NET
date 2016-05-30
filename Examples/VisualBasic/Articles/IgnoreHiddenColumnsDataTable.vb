Imports System.IO
Imports Aspose.Cells

Namespace Articles
    Public Class IgnoreHiddenColumnsDataTable
        Public Shared Sub Run()
            ' ExStart:1
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim inputPath As String = dataDir & "Sample.xlsx"

            Dim workbook As Workbook = New Workbook(inputPath)

            Dim worksheet As Worksheet = workbook.Worksheets(0)

            Dim opts As ExportTableOptions = New ExportTableOptions()
            opts.PlotVisibleColumns = True

            Dim totalRows As Integer = worksheet.Cells.MaxRow + 1
            Dim totalColumns As Integer = worksheet.Cells.MaxColumn + 1

            Dim dt As DataTable = worksheet.Cells.ExportDataTable(0, 0, totalRows, totalColumns, opts)
            ' ExEnd:1

        End Sub
    End Class
End Namespace
