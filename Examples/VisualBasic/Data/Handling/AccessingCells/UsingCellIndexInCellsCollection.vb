Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Aspose.Cells.Examples.Data.Data.Handling.AccessingCells
    Public Class UsingCellIndexInCellsCollection
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Open an existing worksheet
            Dim workbook As New Workbook(dataDir & "book1.xls")

            'Using the Sheet 1 in Workbook
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Accessing a cell using its name
            Dim cell As Cell = worksheet.Cells(0)

            Dim value As String = cell.Value.ToString()

            Console.WriteLine(value)
            'ExEnd:1
        End Sub
    End Class
End Namespace