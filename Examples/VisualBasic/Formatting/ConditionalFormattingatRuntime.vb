Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Aspose.Cells.Examples.Formatting
    Public Class ConditionalFormattingatRuntime
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim filePath As String = dataDir & "Book1.xlsx"

            'Instantiating a Workbook object
            Dim workbook As New Workbook()
            Dim sheet As Worksheet = workbook.Worksheets(0)

            'Adds an empty conditional formatting
            Dim index As Integer = sheet.ConditionalFormattings.Add()
            Dim fcs As FormatConditionCollection = sheet.ConditionalFormattings(index)

            'Sets the conditional format range.
            Dim ca As New CellArea()
            ca.StartRow = 0
            ca.EndRow = 0
            ca.StartColumn = 0
            ca.EndColumn = 0
            fcs.AddArea(ca)

            ca = New CellArea()
            ca.StartRow = 1
            ca.EndRow = 1
            ca.StartColumn = 1
            ca.EndColumn = 1
            fcs.AddArea(ca)

            'Adds condition.
            Dim conditionIndex As Integer = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "=A2", "100")

            'Adds condition.
            Dim conditionIndex2 As Integer = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "50", "100")

            'Sets the background color.
            Dim fc As FormatCondition = fcs(conditionIndex)
            fc.Style.BackgroundColor = Color.Red

            'Saving the Excel file
            workbook.Save(dataDir & "output.xls")
            'ExEnd:1
        End Sub
    End Class
End Namespace
