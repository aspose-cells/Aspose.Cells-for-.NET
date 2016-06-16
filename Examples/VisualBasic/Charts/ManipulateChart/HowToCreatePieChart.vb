Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports System.Drawing
Imports Aspose.Cells.Charts

Namespace Charts.ManipulateChart
    Public Class HowToCreatePieChart
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Create a new Workbook.
            Dim workbook As New Workbook()

            ' Get the first worksheet.
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Set the name of worksheet
            sheet.Name = "Data"

            ' Get the cells collection in the sheet.
            Dim cells As Cells = workbook.Worksheets(0).Cells

            ' Put some values into a cells of the Data sheet.
            cells("A1").PutValue("Region")
            cells("A2").PutValue("France")
            cells("A3").PutValue("Germany")
            cells("A4").PutValue("England")
            cells("A5").PutValue("Sweden")
            cells("A6").PutValue("Italy")
            cells("A7").PutValue("Spain")
            cells("A8").PutValue("Portugal")
            cells("B1").PutValue("Sale")
            cells("B2").PutValue(70000)
            cells("B3").PutValue(55000)
            cells("B4").PutValue(30000)
            cells("B5").PutValue(40000)
            cells("B6").PutValue(35000)
            cells("B7").PutValue(32000)
            cells("B8").PutValue(10000)

            ' Add a chart sheet.
            Dim sheetIndex As Integer = workbook.Worksheets.Add(SheetType.Chart)
            sheet = workbook.Worksheets(sheetIndex)

            ' Set the name of worksheet
            sheet.Name = "Chart"

            ' Create chart
            Dim chartIndex As Integer = 0
            chartIndex = sheet.Charts.Add(Aspose.Cells.Charts.ChartType.Pie, 1, 1, 25, 10)
            Dim chart As Aspose.Cells.Charts.Chart = sheet.Charts(chartIndex)

            ' Set some properties of chart plot area.
            ' To set the fill color and make the border invisible.
            chart.PlotArea.Area.ForegroundColor = Color.Coral
            chart.PlotArea.Area.FillFormat.SetTwoColorGradient(Color.Yellow, Color.White, Aspose.Cells.Drawing.GradientStyleType.Vertical, 2)
            chart.PlotArea.Border.IsVisible = False

            ' Set properties of chart title
            chart.Title.Text = "Sales By Region"
            chart.Title.Font.Color = Color.Blue
            chart.Title.Font.IsBold = True
            chart.Title.Font.Size = 12

            ' Set properties of nseries
            chart.NSeries.Add("Data!B2:B8", True)
            chart.NSeries.CategoryData = "Data!A2:A8"
            chart.NSeries.IsColorVaried = True

            ' Set the DataLabels in the chart
            Dim datalabels As Aspose.Cells.Charts.DataLabels
            For i As Integer = 0 To chart.NSeries.Count - 1
                datalabels = chart.NSeries(i).DataLabels
                datalabels.Position = Aspose.Cells.Charts.LabelPositionType.InsideBase
                datalabels.ShowCategoryName = True
                datalabels.ShowValue = True
                datalabels.ShowPercentage = False
                datalabels.ShowLegendKey = False

            Next i

            ' Set the ChartArea.
            Dim chartarea As Aspose.Cells.Charts.ChartArea = chart.ChartArea
            chartarea.Area.Formatting = Aspose.Cells.Charts.FormattingType.Custom
            chartarea.Area.FillFormat.Texture = Aspose.Cells.Drawing.TextureType.BlueTissuePaper

            ' Set the Legend.
            Dim legend As Aspose.Cells.Charts.Legend = chart.Legend
            legend.Position = Aspose.Cells.Charts.LegendPositionType.Left
            legend.Height = 100
            legend.Width = 130
            legend.Y = 1500
            legend.Font.IsBold = True
            legend.Border.Color = Color.Blue
            legend.Area.Formatting = Aspose.Cells.Charts.FormattingType.Custom

            ' Set FillFormat.
            Dim fillformat As Aspose.Cells.Drawing.FillFormat = legend.Area.FillFormat
            fillformat.Texture = Aspose.Cells.Drawing.TextureType.Bouquet

            ' Save the excel file
            workbook.Save(dataDir & "output.xls")

            ' ExEnd:1

        End Sub
    End Class
End Namespace
