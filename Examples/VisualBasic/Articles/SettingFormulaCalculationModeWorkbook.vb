Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class SettingFormulaCalculationModeWorkbook
        Public Shared Sub Main()
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Create a workbook
            Dim workbook As New Workbook()

            'Set the Formula Calculation Mode to Manual
            workbook.Settings.CalcMode = CalcModeType.Manual

            'Save the workbook
            workbook.Save(dataDir & "output.xlsx", SaveFormat.Xlsx)
            'ExEnd:1

        End Sub
    End Class
End Namespace