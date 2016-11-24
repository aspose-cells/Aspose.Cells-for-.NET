Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles.CreatePivotTablesPivotCharts
    Public Class CreatePivotChart
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating an Workbook object
            ' Opening the excel file
            Dim workbook As New Workbook(dataDir & "pivotTable_test.xlsx")
            ' Adding a new sheet
            Dim sheet3 As Worksheet = workbook.Worksheets(workbook.Worksheets.Add(SheetType.Chart))
            ' Naming the sheet
            sheet3.Name = "PivotChart"
            ' Adding a column chart
            Dim index As Integer = sheet3.Charts.Add(Global.Aspose.Cells.Charts.ChartType.Column, 0, 5, 28, 16)
            ' Setting the pivot chart data source
            sheet3.Charts(index).PivotSource = "PivotTable!PivotTable1"
            sheet3.Charts(index).HidePivotFieldButtons = False
            ' Saving the Excel file
            workbook.Save(dataDir & "pivotChart_test_out.xlsx")
            ' ExEnd:1
        End Sub
    End Class
End Namespace