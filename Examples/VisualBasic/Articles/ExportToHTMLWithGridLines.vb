Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Rendering
Imports System.Drawing.Imaging

Namespace Articles
    Public Class ExportToHTMLWithGridLines
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Create your workbook
            Dim wb As New Workbook()

            ' Access first worksheet
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Fill worksheet with some integer values
            For r As Integer = 0 To 9
                For c As Integer = 0 To 9
                    ws.Cells(r, c).PutValue(r * 1)
                Next
            Next

            ' Save your workbook in HTML format and export gridlines
            Dim opts As New HtmlSaveOptions()
            opts.ExportGridLines = True
            wb.Save(dataDir & Convert.ToString("ExportToHTMLWithGridLines_out_.html"), opts)
            ' ExEnd:1     

        End Sub
    End Class
End Namespace
