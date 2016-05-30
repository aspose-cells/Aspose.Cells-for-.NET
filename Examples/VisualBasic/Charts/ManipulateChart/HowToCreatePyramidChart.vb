Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports System.Drawing
Imports Aspose.Cells.Charts

Namespace Charts.ManipulateChart
    Public Class HowToCreatePyramidChart
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Adding a new worksheet to the Excel object
            Dim sheetIndex As Integer = workbook.Worksheets.Add()

            ' Obtaining the reference of the newly added worksheet by passing its sheet index
            Dim worksheet As Worksheet = workbook.Worksheets(sheetIndex)

            ' Adding a sample value to "A1" cell
            worksheet.Cells("A1").PutValue(50)

            ' Adding a sample value to "A2" cell
            worksheet.Cells("A2").PutValue(100)

            ' Adding a sample value to "A3" cell
            worksheet.Cells("A3").PutValue(150)

            ' Adding a sample value to "B1" cell
            worksheet.Cells("B1").PutValue(4)

            ' Adding a sample value to "B2" cell
            worksheet.Cells("B2").PutValue(20)

            ' Adding a sample value to "B3" cell
            worksheet.Cells("B3").PutValue(50)

            ' Adding a chart to the worksheet
            Dim chartIndex As Integer = worksheet.Charts.Add(Aspose.Cells.Charts.ChartType.Pyramid, 5, 0, 15, 5)

            ' Accessing the instance of the newly added chart
            Dim chart As Aspose.Cells.Charts.Chart = worksheet.Charts(chartIndex)

            ' Adding SeriesCollection (chart data source) to the chart ranging from "A1" cell to "B3"
            chart.NSeries.Add("A1:B3", True)

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls")

            ' ExEnd:1

        End Sub
    End Class
End Namespace
