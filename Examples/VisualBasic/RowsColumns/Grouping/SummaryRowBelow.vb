Imports System.IO

Imports Aspose.Cells

Namespace RowsColumns.Grouping
    Public Class SummaryRowBelow
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim workbook As New Workbook(dataDir & "sample.xlsx")
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Grouping first six rows and first three columns
            worksheet.Cells.GroupRows(0, 5, True)
            worksheet.Cells.GroupColumns(0, 2, True)

            ' Setting SummaryRowBelow property to false
            worksheet.Outline.SummaryRowBelow = False

            ' Saving the modified Excel file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1
        End Sub
    End Class
End Namespace
