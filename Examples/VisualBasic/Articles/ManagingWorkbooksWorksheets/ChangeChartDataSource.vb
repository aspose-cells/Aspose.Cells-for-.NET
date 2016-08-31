Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class ChangeChartDataSource
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load sample excel file
            Dim wb As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access the first sheet which contains chart
            Dim source As Worksheet = wb.Worksheets(0)

            ' Add another sheet named DestSheet
            Dim destination As Worksheet = wb.Worksheets.Add("DestSheet")

            ' Set CopyOptions.ReferToDestinationSheet to true
            Dim options As New CopyOptions()
            options.ReferToDestinationSheet = True

            ' Copy all the rows of source worksheet to destination worksheet which includes chart as well
            ' The chart data source will now refer to DestSheet
            destination.Cells.CopyRows(source.Cells, 0, 0, source.Cells.MaxDisplayRange.RowCount, options)

            ' Save workbook in xlsx format
            wb.Save(dataDir & Convert.ToString("output_out_.xlsx"), SaveFormat.Xlsx)
            ' ExEnd:1           

        End Sub
    End Class
End Namespace
