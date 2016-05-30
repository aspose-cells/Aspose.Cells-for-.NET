Imports System.IO

Imports Aspose.Cells

Namespace Files.Utility
    Public Class ConvertingToMHTMLFiles
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Specify the file path
            Dim filePath As String = dataDir & "Book1.xlsx"

            ' Specify the HTML Saving Options
            Dim sv As New HtmlSaveOptions(SaveFormat.MHtml)

            ' Instantiate a workbook and open the template XLSX file
            Dim wb As New Workbook(filePath)

            ' Save the MHT file
            wb.Save(filePath & ".output.mht", sv)
            ' ExEnd:1
        End Sub
    End Class
End Namespace