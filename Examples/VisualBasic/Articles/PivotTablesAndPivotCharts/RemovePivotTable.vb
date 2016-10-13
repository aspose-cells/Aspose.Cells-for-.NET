Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Cells
Imports System
Imports Aspose.Cells.Pivot

Namespace Articles.PivotTablesAndPivotCharts
    Public Class RemovePivotTable
        Public Shared Sub Run()
            ' ExStart:RemovePivotTableFromWorksheet
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object from source Excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("source.xlsx"))

            ' Access the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access the first pivot table object
            Dim pivotTable As PivotTable = worksheet.PivotTables(0)

            ' Remove pivot table using pivot table object
            worksheet.PivotTables.Remove(pivotTable)

            ' OR you can remove pivot table using pivot table position by uncommenting below line
            'worksheet.PivotTables.RemoveAt(0);

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:RemovePivotTableFromWorksheet
        End Sub
    End Class
End Namespace