Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Charts

Namespace Files.Utility
    Class ConvertChartToPdf

        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Load excel file containing charts
            Dim workbook As New Workbook(dataDir & "Sample1.xls")

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access first chart inside the worksheet
            Dim chart As Chart = worksheet.Charts(0)

            ' Save the chart into pdf format
            chart.ToPdf(dataDir & "Output-Chart_out.pdf")

            ' Save the chart into pdf format in stream
            Dim ms As New MemoryStream()
            chart.ToPdf(ms)
            ' ExEnd:1
        End Sub
    End Class
End Namespace
