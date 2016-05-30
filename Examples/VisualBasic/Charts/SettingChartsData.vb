Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Charts
    Public Class SettingChartsData
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

            ' Adding a sample value to "A4" cell
            worksheet.Cells("A4").PutValue(200)

            ' Adding a sample value to "B1" cell
            worksheet.Cells("B1").PutValue(60)

            ' Adding a sample value to "B2" cell
            worksheet.Cells("B2").PutValue(32)

            ' Adding a sample value to "B3" cell
            worksheet.Cells("B3").PutValue(50)

            ' Adding a sample value to "B4" cell
            worksheet.Cells("B4").PutValue(40)

            ' Adding a sample value to "C1" cell as category data
            worksheet.Cells("C1").PutValue("Q1")

            ' Adding a sample value to "C2" cell as category data
            worksheet.Cells("C2").PutValue("Q2")

            ' Adding a sample value to "C3" cell as category data
            worksheet.Cells("C3").PutValue("Y1")

            ' Adding a sample value to "C4" cell as category data
            worksheet.Cells("C4").PutValue("Y2")

            ' Adding a chart to the worksheet
            Dim chartIndex As Integer = worksheet.Charts.Add(Global.Aspose.Cells.Charts.ChartType.Column, 5, 0, 15, 5)

            ' Accessing the instance of the newly added chart
            Dim chart As Global.Aspose.Cells.Charts.Chart = worksheet.Charts(chartIndex)

            ' Adding SeriesCollection (chart data source) to the chart ranging from "A1" cell to "B4"
            chart.NSeries.Add("A1:B4", True)

            ' Setting the data source for the category data of SeriesCollection
            chart.NSeries.CategoryData = "C1:C4"

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace