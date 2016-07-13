Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Cells
Imports System

Namespace Data.Handling.AccessingCells
    Public Class UsingCellIndexInCellsCollection
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open an existing worksheet
            Dim workbook As New Workbook(dataDir & "book1.xls")

            ' Using the Sheet 1 in Workbook
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Accessing a cell using its row and column
            Dim cell As Cell = worksheet.Cells.GetCell(0, 0)

            Dim value As String = cell.Value.ToString()

            Console.WriteLine(value)
            ' ExEnd:1
        End Sub
    End Class
End Namespace