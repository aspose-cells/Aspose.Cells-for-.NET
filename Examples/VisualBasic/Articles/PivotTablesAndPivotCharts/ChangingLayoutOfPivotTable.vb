Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Cells
Imports System
Imports Aspose.Cells.Pivot

Namespace Articles.PivotTablesAndPivotCharts
    Public Class ChangingLayoutOfPivotTable
        Public Shared Sub Run()
            ' ExStart:ChangingLayoutOfPivotTable
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object from source excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("pivotTable_sample.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access first pivot table
            Dim pivotTable As PivotTable = worksheet.PivotTables(0)

            ' 1 - Show the pivot table in compact form
            pivotTable.ShowInCompactForm()

            ' Refresh the pivot table
            pivotTable.RefreshData()
            pivotTable.CalculateData()

            ' Save the output
            workbook.Save(dataDir & Convert.ToString("CompactForm_out_.xlsx"))

            ' 2 - Show the pivot table in outline form
            pivotTable.ShowInOutlineForm()

            ' Refresh the pivot table
            pivotTable.RefreshData()
            pivotTable.CalculateData()

            ' Save the output
            workbook.Save(dataDir & Convert.ToString("OutlineForm_out_.xlsx"))

            ' 3 - Show the pivot table in tabular form
            pivotTable.ShowInTabularForm()

            ' Refresh the pivot table
            pivotTable.RefreshData()
            pivotTable.CalculateData()

            ' Save the output
            workbook.Save(dataDir & Convert.ToString("TabularForm_out_.xlsx"))
            ' ExEnd:ChangingLayoutOfPivotTable
        End Sub
    End Class
End Namespace