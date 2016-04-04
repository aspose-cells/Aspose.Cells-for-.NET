Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Aspose.Cells.Examples.Formatting
    Public Class SetPattern
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiating a Workbook object
            Dim workbook As New Workbook()
            Dim sheet As Worksheet = workbook.Worksheets(0)

            'Adds an empty conditional formatting
            Dim index As Integer = sheet.ConditionalFormattings.Add()
            Dim fcs As FormatConditionCollection = sheet.ConditionalFormattings(index)

            'Sets the conditional format range.
            Dim ca As New CellArea()
            ca.StartRow = 0
            ca.EndRow = 5
            ca.StartColumn = 0
            ca.EndColumn = 3
            fcs.AddArea(ca)

            'Adds condition.
            Dim conditionIndex As Integer = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "50", "100")
            Dim fc As FormatCondition = fcs(conditionIndex)
            fc.Style.Pattern = BackgroundType.ReverseDiagonalStripe
            fc.Style.ForegroundColor = Color.FromArgb(255, 255, 0)
            fc.Style.BackgroundColor = Color.FromArgb(0, 255, 255)

            workbook.Save(dataDir & "output.xlsx")
            'ExEnd:1

        End Sub
    End Class
End Namespace
