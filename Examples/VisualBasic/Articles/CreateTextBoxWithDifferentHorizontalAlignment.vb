Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports Aspose.Cells.Drawing.Texts

Namespace Articles
    Public Class CreateTextBoxWithDifferentHorizontalAlignment
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a workbook.
            Dim wb As New Workbook()

            ' Access first worksheet.
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Add text box inside the sheet.
            ws.Shapes.AddTextBox(2, 0, 2, 0, 80, 400)

            ' Access first shape which is a text box and set is text.
            Dim shape As Shape = ws.Shapes(0)
            shape.Text = "Sign up for your free phone number." & vbLf & "Call and text online for free." & vbLf & "Call your friends and family."

            ' Acccess the first paragraph and set its horizontal alignment to left.
            Dim p As TextParagraph = shape.TextBody.TextParagraphs(0)
            p.AlignmentType = TextAlignmentType.Left

            ' Acccess the second paragraph and set its horizontal alignment to center.
            p = shape.TextBody.TextParagraphs(1)
            p.AlignmentType = TextAlignmentType.Center

            ' Acccess the third paragraph and set its horizontal alignment to right.
            p = shape.TextBody.TextParagraphs(2)
            p.AlignmentType = TextAlignmentType.Right

            ' Save the workbook in xlsx format.
            wb.Save(dataDir & Convert.ToString("output_out.xlsx"), SaveFormat.Xlsx)
            ' ExEnd:1            
        End Sub
    End Class
End Namespace
