Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Rendering
Imports Aspose.Cells.Charts

Namespace Articles.ManageChartsAndShapes
    Public Class CreatePieChartWithLeaderLines
        Public Shared Sub Run()
            ' ExStart:CreateWorkbook
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create an instance of Workbook in XLSX format
            Dim workbook As New Workbook(FileFormatType.Xlsx)

            ' Access the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Add two columns of data
            worksheet.Cells("A1").PutValue("Retail")
            worksheet.Cells("A2").PutValue("Services")
            worksheet.Cells("A3").PutValue("Info & Communication")
            worksheet.Cells("A4").PutValue("Transport Equip")
            worksheet.Cells("A5").PutValue("Construction")
            worksheet.Cells("A6").PutValue("Other Products")
            worksheet.Cells("A7").PutValue("Wholesale")
            worksheet.Cells("A8").PutValue("Land Transport")
            worksheet.Cells("A9").PutValue("Air Transport")
            worksheet.Cells("A10").PutValue("Electric Appliances")
            worksheet.Cells("A11").PutValue("Securities")
            worksheet.Cells("A12").PutValue("Textiles & Apparel")
            worksheet.Cells("A13").PutValue("Machinery")
            worksheet.Cells("A14").PutValue("Metal Products")
            worksheet.Cells("A15").PutValue("Cash")
            worksheet.Cells("A16").PutValue("Banks")

            worksheet.Cells("B1").PutValue(10.4)
            worksheet.Cells("B2").PutValue(5.2)
            worksheet.Cells("B3").PutValue(6.4)
            worksheet.Cells("B4").PutValue(10.4)
            worksheet.Cells("B5").PutValue(7.9)
            worksheet.Cells("B6").PutValue(4.1)
            worksheet.Cells("B7").PutValue(3.5)
            worksheet.Cells("B8").PutValue(5.7)
            worksheet.Cells("B9").PutValue(3)
            worksheet.Cells("B10").PutValue(14.7)
            worksheet.Cells("B11").PutValue(3.6)
            worksheet.Cells("B12").PutValue(2.8)
            worksheet.Cells("B13").PutValue(7.8)
            worksheet.Cells("B14").PutValue(2.4)
            worksheet.Cells("B15").PutValue(1.8)
            worksheet.Cells("B16").PutValue(10.1)

            ' Create a pie chart and add it to the collection of charts
            Dim id As Integer = worksheet.Charts.Add(ChartType.Pie, 3, 3, 23, 13)

            ' Access newly created Chart instance
            Dim chart As Chart = worksheet.Charts(id)

            ' Set series data range
            chart.NSeries.Add("B1:B16", True)

            ' Set category data range
            chart.NSeries.CategoryData = "A1:A16"

            ' Turn off legend
            chart.ShowLegend = False

            ' Access data labels
            Dim dataLabels As DataLabels = chart.NSeries(0).DataLabels

            ' Turn on category names
            dataLabels.ShowCategoryName = True

            ' Turn on percentage format
            dataLabels.ShowPercentage = True

            ' Set position
            dataLabels.Position = LabelPositionType.OutsideEnd

            ' Set separator
            dataLabels.Separator = DataLablesSeparatorType.Comma
            ' ExEnd:CreateWorkbook

            ' ExStart:TurnOnLeaderLines
            ' Turn on leader lines
            chart.NSeries(0).HasLeaderLines = True

            ' Calculete chart
            chart.Calculate()

            ' You need to move DataLabels a little leftward or rightward depending on their position to show leader lines
            Dim DELTA As Integer = 100
            For i As Integer = 0 To chart.NSeries(0).Points.Count - 1
                Dim X As Integer = chart.NSeries(0).Points(i).DataLabels.X
                ' If it is greater than 2000, then move the X position a little right otherwise move the X position a little left
                If X > 2000 Then
                    chart.NSeries(0).Points(i).DataLabels.X = X + DELTA
                Else
                    chart.NSeries(0).Points(i).DataLabels.X = X - DELTA
                End If
            Next
            ' ExEnd:TurnOnLeaderLines

            ' ExStart:SaveChartInImageAndWorkbookInXLSX
            ' In order to save the chart image, create an instance of ImageOrPrintOptions
            Dim anOption As New ImageOrPrintOptions()

            ' Set image format
            anOption.ImageFormat = System.Drawing.Imaging.ImageFormat.Png

            ' Set resolution
            anOption.HorizontalResolution = 200
            anOption.VerticalResolution = 200

            ' Render chart to image
            chart.ToImage(dataDir & Convert.ToString("output_out_.png"), anOption)

            ' Save the workbook to see chart inside the Excel
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:SaveChartInImageAndWorkbookInXLSX
        End Sub
    End Class
End Namespace