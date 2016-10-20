Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Charts

Namespace Articles.ManageChartsAndShapes
    Public Class GetEquationTextOfChartTrendLine
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object from source Excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("source.xlsx"))

            ' Access the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access the first chart inside the worksheet
            Dim chart As Chart = worksheet.Charts(0)

            ' Calculate the Chart first to get the Equation Text of Trendline
            chart.Calculate()

            ' Access the Trendline
            Dim trendLine As Trendline = chart.NSeries(0).TrendLines(0)

            ' Read the Equation Text of Trendline
            Console.WriteLine("Equation Text: " + trendLine.DataLabels.Text)
            ' ExEnd:1
        End Sub
    End Class
End Namespace