Imports System.IO
Imports System.Drawing
Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Articles
    Public Class SettingTextEffectsShadowOfShapeOrTextbox
        Public Shared Sub Run()
            ' ExStart:SettingTextEffectsShadowOfShapeOrTextbox
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim wb As New Workbook()

            ' Access first worksheet
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Add text box with these dimensions
            Dim tb As TextBox = ws.Shapes.AddTextBox(2, 0, 2, 0, 100, 400)

            ' Set the text of the textbox
            tb.Text = "This text has the following settings." & vbLf & vbLf & "Text Effects > Shadow > Offset Bottom"

            ' Set the font color and size of the textbox
            tb.Font.Color = Color.Red
            tb.Font.Size = 16

            ' Save the output file
            wb.Save(dataDir & Convert.ToString("SettingTextEffectsShadowOfShapeOrTextbox_out.xlsx"), SaveFormat.Xlsx)
            ' ExEnd:SettingTextEffectsShadowOfShapeOrTextbox
        End Sub
    End Class
End Namespace
