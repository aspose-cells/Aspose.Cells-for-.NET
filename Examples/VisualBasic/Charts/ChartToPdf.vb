Imports Aspose.Cells.Rendering
Imports System.IO

Namespace Charts
    Public Class ChartToPdf
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load excel file containing charts
            Dim workbook As New Workbook(dataDir & Convert.ToString("Sample1.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access first chart inside the worksheet
            Dim chart As Aspose.Cells.Charts.Chart = worksheet.Charts(0)

            ' Save the chart into pdf format
            chart.ToPdf(dataDir & Convert.ToString("Output-Chart_out_.pdf"))

            ' Save the chart into pdf format in stream
            Dim ms As New MemoryStream()
            chart.ToPdf(ms)
            ' ExEnd:1
        End Sub
    End Class
End Namespace