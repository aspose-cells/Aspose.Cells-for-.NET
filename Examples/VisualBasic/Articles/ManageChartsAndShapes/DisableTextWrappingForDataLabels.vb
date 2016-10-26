Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Charts

Namespace Articles.ManageChartsAndShapes
    Public Class DisableTextWrappingForDataLabels
        Public Shared Sub Run()
            ' ExStart:DisableTextWrappingForDataLabels
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load the sample Excel file inside the workbook object
            Dim workbook As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access the first chart inside the worksheet
            Dim chart As Chart = worksheet.Charts(0)

            ' Disable the Text Wrapping of Data Labels in all Series
            chart.NSeries(0).DataLabels.IsTextWrapped = False
            chart.NSeries(1).DataLabels.IsTextWrapped = False
            chart.NSeries(2).DataLabels.IsTextWrapped = False

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("Output_out_.xlsx"))
            ' ExEnd:DisableTextWrappingForDataLabels
        End Sub
    End Class
End Namespace