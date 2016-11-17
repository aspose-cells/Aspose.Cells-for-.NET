Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Charts.SettingChartsAppearance
    Public Class SettingTitlesAxes
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Adding a new worksheet to the Workbook object
            Dim sheetIndex As Integer = workbook.Worksheets.Add()

            ' Obtaining the reference of the newly added worksheet by passing its sheet index
            Dim worksheet As Worksheet = workbook.Worksheets(sheetIndex)

            ' Adding sample values to cells
            worksheet.Cells("A1").PutValue(50)
            worksheet.Cells("A2").PutValue(100)
            worksheet.Cells("A3").PutValue(150)
            worksheet.Cells("B1").PutValue(60)
            worksheet.Cells("B2").PutValue(32)
            worksheet.Cells("B3").PutValue(50)

            ' Adding a chart to the worksheet
            Dim chartIndex As Integer = worksheet.Charts.Add(Global.Aspose.Cells.Charts.ChartType.Column, 5, 0, 15, 5)

            ' Accessing the instance of the newly added chart
            Dim chart As Global.Aspose.Cells.Charts.Chart = worksheet.Charts(chartIndex)

            ' Adding SeriesCollection (chart data source) to the chart ranging from "A1" cell to "B3"
            chart.NSeries.Add("A1:B3", True)

            ' Setting the foreground color of the plot area
            chart.PlotArea.Area.ForegroundColor = Color.Blue

            ' Setting the foreground color of the chart area
            chart.ChartArea.Area.ForegroundColor = Color.Yellow

            ' Setting the foreground color of the 1st SeriesCollection area
            chart.NSeries(0).Area.ForegroundColor = Color.Red

            ' Setting the foreground color of the area of the 1st SeriesCollection point
            chart.NSeries(0).Points(0).Area.ForegroundColor = Color.Cyan

            ' Filling the area of the 2nd SeriesCollection with a gradient
            chart.NSeries(1).Area.FillFormat.SetOneColorGradient(Color.Lime, 1, Global.Aspose.Cells.Drawing.GradientStyleType.Horizontal, 1)

            ' Setting the title of a chart
            chart.Title.Text = "Title"

            ' Setting the font color of the chart title to blue
            chart.Title.Font.Color = Color.Blue

            ' Setting the title of category axis of the chart
            chart.CategoryAxis.Title.Text = "Category"

            ' Setting the title of value axis of the chart
            chart.ValueAxis.Title.Text = "Value"


            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace