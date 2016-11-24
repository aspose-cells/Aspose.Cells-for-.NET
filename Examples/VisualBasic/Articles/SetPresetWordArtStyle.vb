Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Articles
    Public Class SetPresetWordArtStyle
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim wb As New Workbook()

            ' Access first worksheet
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Create a textbox with some text
            Dim tb As TextBox = ws.Shapes.AddTextBox(0, 0, 0, 0, 100, 700)
            tb.Text = "Aspose File Format APIs"
            tb.Font.Size = 44

            ' Sets preset WordArt style to the text of the shape.
            Dim fntSetting As FontSetting = TryCast(tb.GetCharacters()(0), FontSetting)
            fntSetting.SetWordArtStyle(PresetWordArtStyle.WordArtStyle3)

            ' Save the workbook in xlsx format
            wb.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace