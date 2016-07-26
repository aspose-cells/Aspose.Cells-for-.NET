Imports System.IO
Imports Aspose.Cells.Drawing
Imports Aspose.Cells.Drawing.Texts
Imports Aspose.Cells
Imports System.Drawing

Namespace Articles
    Public Class SetTextboxOrShapeParagraphLineSpacing
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a workbook
            Dim wb As New Workbook()

            ' Access first worksheet
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Add text box inside the sheet
            ws.Shapes.AddTextBox(2, 0, 2, 0, 100, 200)

            ' Access first shape which is a text box and set is text
            Dim shape As Shape = ws.Shapes(0)
            shape.Text = "Sign up for your free phone number." & vbLf & "Call and text online for free."

            ' Acccess the first paragraph
            Dim p As TextParagraph = shape.TextBody.TextParagraphs(1)

            ' Set the line space
            p.LineSpaceSizeType = LineSpaceSizeType.Points
            p.LineSpace = 20

            ' Set the space after
            p.SpaceAfterSizeType = LineSpaceSizeType.Points
            p.SpaceAfter = 10

            ' Set the space before
            p.SpaceBeforeSizeType = LineSpaceSizeType.Points
            p.SpaceBefore = 10

            ' Save the workbook in xlsx format
            wb.Save(dataDir & Convert.ToString("output_out_.xlsx"), SaveFormat.Xlsx)
            ' ExEnd:1
        End Sub
    End Class
End Namespace
