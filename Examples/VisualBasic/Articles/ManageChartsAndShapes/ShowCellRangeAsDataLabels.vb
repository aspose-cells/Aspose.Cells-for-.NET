Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Charts

Namespace Articles.ManageChartsAndShapes
    Public Class ShowCellRangeAsDataLabels
        Public Shared Sub Run()
            ' ExStart:ShowCellRangeAsDataLabels
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook from the source Excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("source.xlsx"))

            ' Access the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access the chart inside the worksheet
            Dim chart As Chart = worksheet.Charts(0)

            ' Check the "Label Contains - Value From Cells"
            Dim dataLabels As DataLabels = chart.NSeries(0).DataLabels
            dataLabels.ShowCellRange = True

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:ShowCellRangeAsDataLabels
        End Sub
    End Class
End Namespace