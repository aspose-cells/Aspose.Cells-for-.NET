Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Charts

Namespace Articles.ManageChartsAndShapes
    Public Class DetermineAxisInChart
        Public Shared Sub Run()
            ' ExStart:DetermineAxisInChart
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim workbook As New Workbook(dataDir & Convert.ToString("source.xlsx"))

            ' Access the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access the chart
            Dim chart As Chart = worksheet.Charts(0)

            'Determine which axis exists in chart
            Dim ret As Boolean = chart.HasAxis(AxisType.Category, True)
            Console.WriteLine("Has Primary Category Axis: " + ret)

            ret = chart.HasAxis(AxisType.Category, False)
            Console.WriteLine("Has Secondary Category Axis: " + ret)

            ret = chart.HasAxis(AxisType.Value, True)
            Console.WriteLine("Has Primary Value Axis: " + ret)

            ret = chart.HasAxis(AxisType.Value, False)
            Console.WriteLine("Has Seconary Value Axis: " + ret)
            ' ExEnd:DetermineAxisInChart
        End Sub
    End Class
End Namespace