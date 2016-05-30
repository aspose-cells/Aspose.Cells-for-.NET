Imports Microsoft.VisualBasic
Imports System.IO
Imports System
Imports Aspose.Cells

Namespace Data.AddOn.NamedRanges
    Public Class AccessSpecificNamedRange
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            ' Opening the Excel file through the file stream
            Dim workbook As New Workbook(dataDir & "book1.xls")

            ' Getting the specified named range
            Dim range As Range = workbook.Worksheets.GetRangeByName("TestRange")

            If range IsNot Nothing Then
                Console.WriteLine("Named Range : " & range.RefersTo)
            End If
            ' ExEnd:1
        End Sub
    End Class
End Namespace