Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Aspose.Cells.Examples.Data.Processing
    Public Class TracingDependents
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim workbook As New Workbook(dataDir & "Book1.xlsx")
            Dim cells As Cells = workbook.Worksheets(0).Cells
            Dim cell As Cell = cells("B2")

            Dim ret() As Cell = cell.GetDependents(True)

            For Each c As Cell In cell.GetDependents(True)
                Console.WriteLine(c.Name)
            Next c
            'ExEnd:1
            Console.ReadKey()
        End Sub
    End Class
End Namespace
