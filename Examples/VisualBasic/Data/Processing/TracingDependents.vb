Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Data.Processing
    Public Class TracingDependents
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim workbook As New Workbook(dataDir & "Book1.xlsx")
            Dim cells As Cells = workbook.Worksheets(0).Cells
            Dim cell As Cell = cells("B2")

            Dim ret() As Cell = cell.GetDependents(True)

            For Each c As Cell In cell.GetDependents(True)
                Console.WriteLine(c.Name)
            Next c
            ' ExEnd:1
            Console.ReadKey()
        End Sub
    End Class
End Namespace
