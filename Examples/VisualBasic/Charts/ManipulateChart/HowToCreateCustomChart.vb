Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports System.Drawing
Imports Aspose.Cells.Charts

Namespace Charts.ManipulateChart
    Public Class HowToCreateCustomChart
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
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
            worksheet.Cells("A4").PutValue(110)
            worksheet.Cells("B1").PutValue(260)
            worksheet.Cells("B2").PutValue(12)
            worksheet.Cells("B3").PutValue(50)
            worksheet.Cells("B4").PutValue(100)

            ' Adding a chart to the worksheet
            Dim chartIndex As Integer = worksheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 5, 0, 15, 5)

            ' Accessing the instance of the newly added chart
            Dim chart As Aspose.Cells.Charts.Chart = worksheet.Charts(chartIndex)

            ' Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B4"
            chart.NSeries.Add("A1:B4", True)

            ' Setting the chart type of 2nd NSeries to display as line chart
            chart.NSeries(1).Type = Aspose.Cells.Charts.ChartType.Line

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace
