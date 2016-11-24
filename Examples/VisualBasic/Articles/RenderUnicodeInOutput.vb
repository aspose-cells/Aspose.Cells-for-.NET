Imports System.IO
Imports Aspose.Cells

Namespace Articles
    Public Class RenderUnicodeInOutput
        Public Shared Sub Run()
            ' ExStart:RenderUnicodeInOutput
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load your source excel file containing Unicode Supplementary characters
            Dim wb As New Workbook(dataDir & Convert.ToString("unicode-supplementary-characters.xlsx"))

            ' Save the workbook
            wb.Save(dataDir & Convert.ToString("RenderUnicodeInOutput_out.pdf"))
            ' ExEnd:RenderUnicodeInOutput
        End Sub
    End Class
End Namespace
