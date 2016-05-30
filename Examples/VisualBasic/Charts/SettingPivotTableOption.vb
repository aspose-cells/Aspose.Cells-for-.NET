Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Pivot

Namespace Articles
    Public Class SettingPivotTableOption
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim wb As New Workbook(dataDir & "input.xlsx")

            Dim pt As PivotTable = wb.Worksheets(0).PivotTables(0)

            ' Indicating if or not display the empty cell value
            pt.DisplayNullString = True

            ' Indicating the null string
            pt.NullString = "null"

            pt.CalculateData()

            pt.RefreshDataOnOpeningFile = False

            wb.Save(dataDir & "output.xlsx")
            ' ExEnd:1

        End Sub
    End Class
End Namespace