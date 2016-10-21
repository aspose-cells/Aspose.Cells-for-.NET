Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles.WorkingWithCalculationEngine
    Public Class SettingFormulaCalculationModeWorkbook
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Create a workbook
            Dim workbook As New Workbook()

            ' Set the Formula Calculation Mode to Manual
            workbook.Settings.CalcMode = CalcModeType.Manual

            ' Save the workbook
            workbook.Save(dataDir & "output_out_.xlsx", SaveFormat.Xlsx)
            ' ExEnd:1
        End Sub
    End Class
End Namespace