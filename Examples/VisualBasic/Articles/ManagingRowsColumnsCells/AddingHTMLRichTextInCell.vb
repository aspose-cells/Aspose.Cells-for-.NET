Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingRowsColumnsCells
    Public Class AddingHTMLRichTextInCell
        Public Shared Sub Run()
            ' ExStart:AddingHTMLRichTextInCell
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim workbook As New Workbook()

            Dim worksheet As Worksheet = workbook.Worksheets(0)

            Dim cell As Cell = worksheet.Cells("A1")
            cell.HtmlString = "<Font Style=""FONT-WEIGHT: bold;FONT-STYLE: italic;TEXT-DECORATION: underline;FONT-FAMILY: Arial;FONT-SIZE: 11pt;COLOR: #ff0000;"">This is simple HTML formatted text.</Font>"

            workbook.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:AddingHTMLRichTextInCell
        End Sub
    End Class
End Namespace