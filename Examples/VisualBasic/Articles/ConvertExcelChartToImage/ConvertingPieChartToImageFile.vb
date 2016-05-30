Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles.ConvertExcelChartToImage
    Public Class ConvertingPieChartToImageFile
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a new workbook.
            ' Open the existing excel file which contains the pie chart.
            Dim workbook As New Workbook(dataDir & "PieChart.xlsx")

            ' Get the designer chart (first chart) in the first worksheet.
            ' Of the workbook.
            Dim chart As Global.Aspose.Cells.Charts.Chart = workbook.Worksheets(0).Charts(0)

            ' Convert the chart to an image file.
            chart.ToImage(dataDir & "PieChart.output.emf", System.Drawing.Imaging.ImageFormat.Emf)
            ' ExEnd:1



        End Sub
    End Class
End Namespace