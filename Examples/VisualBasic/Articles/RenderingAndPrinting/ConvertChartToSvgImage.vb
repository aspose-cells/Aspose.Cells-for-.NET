Namespace Articles.RenderingAndPrinting
    Public Class ConvertChartToSvgImage
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object from source file
            Dim workbook As New Workbook(dataDir & Convert.ToString("SampleChartBook.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access first chart inside the worksheet
            Dim chart As Aspose.Cells.Charts.Chart = worksheet.Charts(0)

            ' Set image or print options
            Dim opts As New Aspose.Cells.Rendering.ImageOrPrintOptions()
            opts.SaveFormat = SaveFormat.SVG

            ' Save the chart to svg format
            chart.ToImage(dataDir & Convert.ToString("Image_out.svg"), opts)
            ' ExEnd:1
        End Sub
    End Class
End Namespace