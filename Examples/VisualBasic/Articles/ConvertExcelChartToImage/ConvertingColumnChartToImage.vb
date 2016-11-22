Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles.ConvertExcelChartToImage
    Public Class ConvertingColumnChartToImage
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)


            ' Open the existing excel file which contains the column chart.
            Dim workbook As New Workbook(dataDir & "ColumnChart.xlsx")

            ' Get the designer chart (first chart) in the first worksheet of the workbook.
            Dim chart As Global.Aspose.Cells.Charts.Chart = workbook.Worksheets(0).Charts(0)

            ' Convert the chart to an image file.
            chart.ToImage(dataDir & "ColumnChart.output.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg)
            ' ExEnd:1

        End Sub
    End Class
End Namespace