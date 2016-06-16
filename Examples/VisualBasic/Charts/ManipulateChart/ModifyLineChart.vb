Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports System.Drawing
Imports Aspose.Cells.Charts

Namespace Charts.ManipulateChart
    Public Class ModifyLineChart
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a new Workbook.
            ' Open the existing file.
            Dim workbook As New Workbook(dataDir & "Book1.xlsx")

            ' Get the designer chart in the first worksheet.
            Dim chart As Aspose.Cells.Charts.Chart = workbook.Worksheets(0).Charts(0)

            ' Add the third data series to it.
            chart.NSeries.Add("{60, 80, 10}", True)

            ' Add another data series (fourth) to it.
            chart.NSeries.Add("{0.3, 0.7, 1.2}", True)

            ' Plot the fourth data series on the second axis.
            chart.NSeries(3).PlotOnSecondAxis = True

            ' Change the Border color of the second data series.
            chart.NSeries(1).Border.Color = Color.Green

            ' Change the line color of the third data series.
            chart.NSeries(2).Border.Color = Color.Red

            ' Make the second value axis visible.
            chart.SecondValueAxis.IsVisible = True

            ' Save the excel file.
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace
