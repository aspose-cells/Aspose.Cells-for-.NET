Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Articles.ManageChartsAndShapes
    Public Class AddWordArtWatermarkToChart
        Public Shared Sub Run()
            ' ExStart:AddWordArtWatermarkToChart
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open the existing excel file.
            Dim workbook As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Get the chart in the first worksheet.
            Dim chart As Aspose.Cells.Charts.Chart = workbook.Worksheets(0).Charts(0)

            ' Add a WordArt watermark (shape) to the chart's plot area.
            Dim wordart As Aspose.Cells.Drawing.Shape = chart.Shapes.AddTextEffectInChart(MsoPresetTextEffect.TextEffect2, "CONFIDENTIAL", "Arial Black", 66, False, False, _
             1200, 500, 2000, 3000)

            ' Get the shape's fill format.
            Dim wordArtFormat As FillFormat = wordart.Fill

            ' Set the transparency.
            wordArtFormat.Transparency = 0.9

            ' Get the line format.
            Dim lineFormat As LineFormat = wordart.Line

            ' Set Line format to invisible.
            lineFormat.Weight = 0.0

            ' Save the excel file.
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:AddWordArtWatermarkToChart
        End Sub
    End Class
End Namespace