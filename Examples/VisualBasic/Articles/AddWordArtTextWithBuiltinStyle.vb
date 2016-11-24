Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Articles
    Public Class AddWordArtTextWithBuiltinStyle
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim wb As New Workbook()

            ' Access first worksheet
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Add Word Art Text with Built-in Styles
            ws.Shapes.AddWordArt(PresetWordArtStyle.WordArtStyle1, "Aspose File Format APIs", 0, 0, 0, 0, _
             100, 800)
            ws.Shapes.AddWordArt(PresetWordArtStyle.WordArtStyle2, "Aspose File Format APIs", 10, 0, 0, 0, _
             100, 800)
            ws.Shapes.AddWordArt(PresetWordArtStyle.WordArtStyle3, "Aspose File Format APIs", 20, 0, 0, 0, _
             100, 800)
            ws.Shapes.AddWordArt(PresetWordArtStyle.WordArtStyle4, "Aspose File Format APIs", 30, 0, 0, 0, _
             100, 800)
            ws.Shapes.AddWordArt(PresetWordArtStyle.WordArtStyle5, "Aspose File Format APIs", 40, 0, 0, 0, _
             100, 800)

            ' Save the workbook in xlsx format
            wb.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace