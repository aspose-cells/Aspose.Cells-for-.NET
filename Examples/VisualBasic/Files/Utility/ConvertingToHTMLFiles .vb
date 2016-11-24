Imports System.IO
Imports Aspose.Cells

Namespace Files.Utility
    Public Class ConvertingToHTMLFiles
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Specify the file path
            Dim filePath As String = dataDir & Convert.ToString("sample.xlsx")

            ' Load your sample excel file in a workbook object
            Dim wb As New Workbook(filePath)

            ' Save it in HTML format
            wb.Save(dataDir & Convert.ToString("ConvertingToHTMLFiles_out.html"), SaveFormat.Html)
            ' ExEnd:1
        End Sub
    End Class
End Namespace
