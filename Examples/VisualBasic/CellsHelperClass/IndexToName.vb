Imports System

Namespace Aspose.Cells.Examples.CellsHelperClass
    Public Class IndexToName
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            Dim row As Integer = 3
            Dim column As Integer = 5
            Dim name As String = Aspose.Cells.CellsHelper.CellIndexToName(row, column)
            Console.WriteLine("Cell name: {0}", name)
            'ExEnd:1
        End Sub
    End Class
End Namespace
