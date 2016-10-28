Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles
    Public Class MoveRangeOfCells
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Instantiate the workbook object
            ' Open the Excel file
            Dim workbook As New Workbook(dataDir & "book1.xls")

            Dim cells As Global.Aspose.Cells.Cells = workbook.Worksheets(0).Cells

            ' Create Cell' S area
            Dim ca As New CellArea()
            ca.StartColumn = 0
            ca.EndColumn = 1
            ca.StartRow = 0
            ca.EndRow = 4

            ' Move Range
            cells.MoveRange(ca, 0, 2)

            ' Save the resultant file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1
        End Sub
    End Class
End Namespace