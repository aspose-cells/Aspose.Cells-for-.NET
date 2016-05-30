Imports System.IO

Imports Aspose.Cells
Imports System.Drawing
Imports Aspose.Cells.Pivot

Namespace PivotTableExamples
    Public Class ConsolidationFunctions
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook from source excel file
            Dim workbook As New Workbook(dataDir & "Book.xlsx")

            ' Access the first worksheet of the workbook
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access the first pivot table of the worksheet
            Dim pivotTable As PivotTable = worksheet.PivotTables(0)

            ' Apply Average consolidation function to first data field
            pivotTable.DataFields(0).Function = ConsolidationFunction.Average

            ' Apply DistinctCount consolidation function to second data field
            pivotTable.DataFields(1).Function = ConsolidationFunction.DistinctCount

            ' Calculate the data to make changes affect
            pivotTable.CalculateData()

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xlsx")

            ' ExEnd:1

        End Sub
    End Class
End Namespace
