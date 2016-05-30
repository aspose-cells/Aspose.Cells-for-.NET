Imports System.IO

Imports Aspose.Cells

Namespace Files.Utility
    Public Class SettingImagePrefrencesforHTML
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Specify the file path
            Dim filePath As String = dataDir & "Book1.xlsx"

            ' Load a spreadsheet to be converted
            Dim book As New Workbook(filePath)

            ' Create an instance of HtmlSaveOptions
            Dim saveOptions As New HtmlSaveOptions(SaveFormat.Html)

            ' Set the ImageFormat to PNG
            saveOptions.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg

            ' Set SmoothingMode to AntiAlias
            saveOptions.ImageOptions.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

            ' Set TextRenderingHint to AntiAlias
            saveOptions.ImageOptions.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias

            ' Save spreadsheet to HTML while passing object of HtmlSaveOptions
            book.Save(dataDir & "output.html", saveOptions)

            ' ExEnd:1
        End Sub
    End Class
End Namespace
