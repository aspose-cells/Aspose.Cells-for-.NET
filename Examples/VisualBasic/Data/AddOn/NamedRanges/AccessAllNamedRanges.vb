Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Aspose.Cells.Examples.Data.AddOn.NamedRanges
    Public Class AccessAllNamedRanges
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiating a Workbook object
            'Opening the Excel file through the file stream
            Dim workbook As New Workbook(dataDir & "book1.xls")

            'Getting all named ranges
            Dim range() As Range = workbook.Worksheets.GetNamedRanges()

            If range IsNot Nothing Then
                Console.WriteLine("Total Number of Named Ranges: " & range.Length)
            End If

        End Sub
    End Class
End Namespace