
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Aspose.Cells.Charts

Namespace Articles
    Public Class FindDataPointsInPieBar
        Public Shared Sub Run()
            ' ExStart:FindDataPointsInPieBar
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Load source excel file containing Bar of Pie chart
            Dim wb As New Workbook(dataDir & Convert.ToString("PieBars.xlsx"))

            ' Access first worksheet
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Access first chart which is Bar of Pie chart and calculate it
            Dim ch As Chart = ws.Charts(0)
            ch.Calculate()

            ' Access the chart series
            Dim srs As Series = ch.NSeries(0)

            ' Print the data points of the chart series and 
            ' check its IsInSecondaryPlot property to determine 
            ' if data point is inside the bar or pie 

            For i As Integer = 0 To srs.Points.Count - 1
                'Access chart point
                Dim cp As ChartPoint = srs.Points(i)

                'Skip null values
                If cp.YValue Is Nothing Then
                    Continue For
                End If

                ' Print the chart point value and see if it is inside bar or pie.
                ' If the IsInSecondaryPlot is true, then the data point is inside bar 
                ' otherwise it is inside the pie.          

                Console.WriteLine("Value: " + cp.YValue)
                Console.WriteLine("IsInSecondaryPlot: " + cp.IsInSecondaryPlot)
                Console.WriteLine()
            Next
            ' ExEnd:FindDataPointsInPieBar
        End Sub
    End Class
End Namespace
