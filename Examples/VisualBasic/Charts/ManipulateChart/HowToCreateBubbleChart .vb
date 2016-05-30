Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports System.Drawing
Imports Aspose.Cells.Charts

Namespace Charts.ManipulateChart
    Public Class HowToCreateBubbleChart
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Obtaining the reference of the first worksheet by passing its index
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Fill in data for chart' S series
            worksheet.Cells(0, 0).PutValue("Y Values")
            worksheet.Cells(0, 1).PutValue(2)
            worksheet.Cells(0, 2).PutValue(4)
            worksheet.Cells(0, 3).PutValue(6)
            worksheet.Cells(1, 0).PutValue("Bubble Size")
            worksheet.Cells(1, 1).PutValue(2)
            worksheet.Cells(1, 2).PutValue(3)
            worksheet.Cells(1, 3).PutValue(1)
            worksheet.Cells(2, 0).PutValue("X Values")
            worksheet.Cells(2, 1).PutValue(1)
            worksheet.Cells(2, 2).PutValue(2)
            worksheet.Cells(2, 3).PutValue(3)

            ' Adding a chart to the worksheet
            Dim chartIndex As Integer = worksheet.Charts.Add(Aspose.Cells.Charts.ChartType.Bubble, 5, 0, 15, 5)

            ' Accessing the instance of the newly added chart
            Dim chart As Aspose.Cells.Charts.Chart = worksheet.Charts(chartIndex)

            ' Adding SeriesCollection (chart data source) to the chart ranging
            chart.NSeries.Add("B1:D1", True)

            ' Set bubble sizes
            chart.NSeries(0).BubbleSizes = "B2:D2"

            ' Set X axis values
            chart.NSeries(0).XValues = "B3:D3"

            ' Set Y axis values
            chart.NSeries(0).Values = "B1:D1"

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace
