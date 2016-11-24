Imports Aspose.Cells.Rendering

Namespace Charts
    Public Class ChartRendering
        Public Shared Sub Run()
            ' ExStart:ChartRenderingCreatingChart
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()
            ' Adding a new worksheet to the Workbook
            Dim sheetIndex As Integer = workbook.Worksheets.Add()
            ' Obtaining the reference of the newly added worksheet by passing its index to WorksheetCollection
            Dim worksheet As Worksheet = workbook.Worksheets(sheetIndex)

            ' Adding sample values to cells
            worksheet.Cells("A1").PutValue(50)
            worksheet.Cells("A2").PutValue(100)
            worksheet.Cells("A3").PutValue(150)
            worksheet.Cells("B1").PutValue(4)
            worksheet.Cells("B2").PutValue(20)
            worksheet.Cells("B3").PutValue(50)

            ' Adding a chart to the worksheet
            Dim chartIndex As Integer = worksheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 5, 0, 15, 5)
            ' Accessing the instance of the newly added chart
            Dim chart As Aspose.Cells.Charts.Chart = worksheet.Charts(chartIndex)
            ' Adding Series Collection (chart data source) to the chart ranging from "A1" cell to "B3"
            chart.NSeries.Add("A1:B3", True)
            ' ExEnd:ChartRenderingCreatingChart

            ' ExStart:ChartRenderingChartToImage
            ' Converting chart to image
            chart.ToImage(dataDir & Convert.ToString("chartEMF_out.emf"), System.Drawing.Imaging.ImageFormat.Emf)

            ' Converting chart to Bitmap
            Dim bitmap As System.Drawing.Bitmap = chart.ToImage()
            bitmap.Save(dataDir & Convert.ToString("chartBMP_out.bmp"), System.Drawing.Imaging.ImageFormat.Bmp)
            ' ExEnd:ChartRenderingChartToImage

            ' ExStart:ChartRenderingChartToImageWithAdvancedOptions
            ' Create an instance of ImageOrPrintOptions and set a few properties
            Dim options As New ImageOrPrintOptions() With { _
             .VerticalResolution = 300, _
             .HorizontalResolution = 300, _
             .SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias _
            }
            ' Convert chart to image with additional settings
            chart.ToImage(dataDir & Convert.ToString("chartPNG_out.png"), options)
            ' ExEnd:ChartRenderingChartToImageWithAdvancedOptions

            ' ExStart:ChartRenderingChartToPDF
            ' Converting chart to PDF
            chart.ToPdf(dataDir & Convert.ToString("chartPDF_out.pdf"))
            ' ExEnd:ChartRenderingChartToPDF
        End Sub
    End Class
End Namespace