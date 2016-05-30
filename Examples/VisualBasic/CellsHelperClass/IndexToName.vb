Imports System

Namespace CellsHelperClass
    Public Class IndexToName
        Public Shared Sub Run()
            ' ExStart:1
            Dim row As Integer = 3
            Dim column As Integer = 5
            Dim name As String = Aspose.Cells.CellsHelper.CellIndexToName(row, column)
            Console.WriteLine("Cell name: {0}", name)
            ' ExEnd:1
        End Sub
    End Class
End Namespace
