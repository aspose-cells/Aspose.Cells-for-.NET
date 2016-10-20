Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Charts

Namespace Articles.ManageChartsAndShapes
    Public Class ChartSetupUsingSetChartDataRange
        Public Shared Sub Run()
            ' ExStart:EasyWayToChartSetupUsingSetChartDataRange
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create new workbook
            Dim workbook As New Workbook(FileFormatType.Xlsx)

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Add data for chart

            ' Category Axis Values
            worksheet.Cells("A2").PutValue("C1")
            worksheet.Cells("A3").PutValue("C2")
            worksheet.Cells("A4").PutValue("C3")

            ' First vertical series
            worksheet.Cells("B1").PutValue("T1")
            worksheet.Cells("B2").PutValue(6)
            worksheet.Cells("B3").PutValue(3)
            worksheet.Cells("B4").PutValue(2)

            ' Second vertical series
            worksheet.Cells("C1").PutValue("T2")
            worksheet.Cells("C2").PutValue(7)
            worksheet.Cells("C3").PutValue(2)
            worksheet.Cells("C4").PutValue(5)

            ' Third vertical series
            worksheet.Cells("D1").PutValue("T3")
            worksheet.Cells("D2").PutValue(8)
            worksheet.Cells("D3").PutValue(4)
            worksheet.Cells("D4").PutValue(2)

            ' Create Column chart with easy way
            Dim idx As Integer = worksheet.Charts.Add(ChartType.Column, 6, 5, 20, 13)
            Dim ch As Chart = worksheet.Charts(idx)
            ch.SetChartDataRange("A1:D4", True)

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsx"), SaveFormat.Xlsx)
            ' ExEnd:EasyWayToChartSetupUsingSetChartDataRange
        End Sub
    End Class
End Namespace