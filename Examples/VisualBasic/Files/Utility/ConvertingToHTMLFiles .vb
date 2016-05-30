Imports System.IO

Imports Aspose.Cells

Namespace Files.Utility
    Public Class ConvertingToHTMLFiles
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Specify the file path
            Dim filePath As String = dataDir & "Book1.xlsx"

            ' Specify the HTML Saving Options
            Dim save As New HtmlSaveOptions(SaveFormat.Html)

            ' Instantiate a workbook and open the template XLSX file
            Dim wb As New Workbook(filePath)

            ' Save the MHT file
            wb.Save(dataDir & "output.html", save)
            ' ExEnd:1
        End Sub
    End Class
End Namespace
