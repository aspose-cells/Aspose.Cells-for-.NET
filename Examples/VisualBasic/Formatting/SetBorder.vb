Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Aspose.Cells.Examples.Formatting
    Public Class SetBorder
        'ExStart:1
        Public Shared Sub Main(ByVal args() As String)
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
            'Sets the background color.
            Dim fc As FormatCondition = fcs(conditionIndex)
            fc.Style.Borders(BorderType.LeftBorder).LineStyle = CellBorderType.Dashed
            fc.Style.Borders(BorderType.RightBorder).LineStyle = CellBorderType.Dashed
            fc.Style.Borders(BorderType.TopBorder).LineStyle = CellBorderType.Dashed
            fc.Style.Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Dashed

            fc.Style.Borders(BorderType.LeftBorder).Color = Color.FromArgb(0, 255, 255)
            fc.Style.Borders(BorderType.RightBorder).Color = Color.FromArgb(0, 255, 255)
            fc.Style.Borders(BorderType.TopBorder).Color = Color.FromArgb(0, 255, 255)
            fc.Style.Borders(BorderType.BottomBorder).Color = Color.FromArgb(255, 255, 0)
            workbook.Save(dataDir & "output.xlsx")
            'ExEnd:1

        End Sub
    End Class
End Namespace
