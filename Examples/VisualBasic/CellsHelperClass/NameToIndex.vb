Imports System

Namespace Aspose.Cells.Examples.CellsHelperClass
    Public Class NameToIndex
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            Dim name As String = "C4"
            Dim row As Integer = Nothing
            Dim column As Integer = Nothing
            Aspose.Cells.CellsHelper.CellNameToIndex(name, row, column)
            Console.WriteLine("Row: {0}, Column: {1}", row, column)
            'ExEnd:1

        End Sub
    End Class
End Namespace
