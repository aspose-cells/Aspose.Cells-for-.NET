Imports System.IO

Imports Aspose.Cells

Namespace Files.Handling
    Public Class SaveInHtmlFormat
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Creating a Workbook object
            Dim workbook As New Workbook()
            ' Save in Html format
            workbook.Save(dataDir & "output.html", SaveFormat.Html)

            ' ExEnd:1
        End Sub
    End Class
End Namespace
