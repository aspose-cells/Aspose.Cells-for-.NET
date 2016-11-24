Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Charts

Namespace Articles.ManageChartsAndShapes
    Public Class AddCustomLabelsToDataPoints
        Public Shared Sub Run()
            ' ExStart:AddCustomLabelsToDataPointsInTheSeriesOfChart
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim workbook As New Workbook(FileFormatType.Xlsx)
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Put data
            sheet.Cells(0, 0).PutValue(1)
            sheet.Cells(0, 1).PutValue(2)
            sheet.Cells(0, 2).PutValue(3)

            sheet.Cells(1, 0).PutValue(4)
            sheet.Cells(1, 1).PutValue(5)
            sheet.Cells(1, 2).PutValue(6)

            sheet.Cells(2, 0).PutValue(7)
            sheet.Cells(2, 1).PutValue(8)
            sheet.Cells(2, 2).PutValue(9)

            ' Generate the chart
            Dim chartIndex As Integer = sheet.Charts.Add(Aspose.Cells.Charts.ChartType.ScatterConnectedByLinesWithDataMarker, 5, 1, 24, 10)
            Dim chart As Chart = sheet.Charts(chartIndex)

            chart.Title.Text = "Test"
            chart.CategoryAxis.Title.Text = "X-Axis"
            chart.ValueAxis.Title.Text = "Y-Axis"

            chart.NSeries.CategoryData = "A1:C1"

            ' Insert series
            chart.NSeries.Add("A2:C2", False)

            Dim series As Series = chart.NSeries(0)

            Dim pointCount As Integer = series.Points.Count
            For i As Integer = 0 To pointCount - 1
                Dim pointIndex As ChartPoint = series.Points(i)

                pointIndex.DataLabels.Text = "Series 1" + vbLf + "Point " + i
            Next

            ' Insert series
            chart.NSeries.Add("A3:C3", False)

            series = chart.NSeries(1)

            pointCount = series.Points.Count
            For i As Integer = 0 To pointCount - 1
                Dim pointIndex As ChartPoint = series.Points(i)

                pointIndex.DataLabels.Text = "Series 2" + vbLf + "Point " + i
            Next

            workbook.Save(dataDir & Convert.ToString("output_out.xlsx"), Aspose.Cells.SaveFormat.Xlsx)
            ' ExEnd:AddCustomLabelsToDataPointsInTheSeriesOfChart
        End Sub
    End Class
End Namespace