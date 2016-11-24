Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Cells
Imports System
Imports Aspose.Cells.Pivot

Namespace Articles.PivotTablesAndPivotCharts
    Public Class SettingPivotTableOption
        Public Shared Sub Run()
            ' ExStart:SettingPivotTableOption
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim wb As New Workbook(dataDir & Convert.ToString("input.xlsx"))

            Dim pt As PivotTable = wb.Worksheets(0).PivotTables(0)

            ' Indicating if or not display the empty cell value
            pt.DisplayNullString = True

            ' Indicating the null string
            pt.NullString = "null"
            pt.CalculateData()

            pt.RefreshDataOnOpeningFile = False

            wb.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:SettingPivotTableOption
        End Sub
    End Class
End Namespace