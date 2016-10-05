
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Articles.RenderingAndPrinting
    Public Class ExportChartToSvgWithViewBox
        Public Shared Sub Run()
            ' ExStart:ExportChartToSvgWithViewBox
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object from source file
            Dim workbook As New Workbook(dataDir & Convert.ToString("SampleChartBook.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access first chart inside the worksheet
            Dim chart As Aspose.Cells.Charts.Chart = worksheet.Charts(0)

            ' Set image or print options with SVGFitToViewPort true
            Dim opts As New Aspose.Cells.Rendering.ImageOrPrintOptions()
            opts.SaveFormat = SaveFormat.SVG
            opts.SVGFitToViewPort = True

            ' Save the chart to svg format
            chart.ToImage(dataDir & Convert.ToString("Image_out_.svg"), opts)
            ' ExEnd:ExportChartToSvgWithViewBox
        End Sub
    End Class
End Namespace
