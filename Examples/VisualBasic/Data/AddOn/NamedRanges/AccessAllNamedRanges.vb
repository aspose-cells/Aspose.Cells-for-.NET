Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Data.AddOn.NamedRanges
    Public Class AccessAllNamedRanges
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Opening the Excel file through the file stream
            Dim workbook As New Workbook(dataDir & "book1.xls")

            ' Getting all named ranges
            Dim range() As Range = workbook.Worksheets.GetNamedRanges()

            If range IsNot Nothing Then
                Console.WriteLine("Total Number of Named Ranges: " & range.Length)
            End If
            ' ExEnd:1
        End Sub
    End Class
End Namespace