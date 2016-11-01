Namespace Articles.ManageChartsAndShapes
    Public Class ResizeChartDataLabelToFit
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create an instance of Workbook containing the Chart
            Dim book = New Workbook(dataDir & Convert.ToString("source.xlsx"))

            ' Access the Worksheet that contains the Chart
            Dim sheet = book.Worksheets(0)

            For Each chart As Aspose.Cells.Charts.Chart In sheet.Charts
                For index As Integer = 0 To chart.NSeries.Count - 1
                    ' Access the DataLabels of indexed NSeries
                    Dim labels = chart.NSeries(index).DataLabels

                    ' Set ResizeShapeToFitText property to true
                    labels.IsResizeShapeToFitText = True
                Next

                ' Calculate Chart
                chart.Calculate()
            Next

            ' Save the result
            book.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace