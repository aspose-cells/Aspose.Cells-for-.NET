Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Formatting
    Public Class SetFont
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Adds an empty conditional formatting
            Dim index As Integer = sheet.ConditionalFormattings.Add()
            Dim fcs As FormatConditionCollection = sheet.ConditionalFormattings(index)

            ' Sets the conditional format range.
            Dim ca As New CellArea()
            ca.StartRow = 0
            ca.EndRow = 5
            ca.StartColumn = 0
            ca.EndColumn = 3
            fcs.AddArea(ca)

            ' Adds condition.
            Dim conditionIndex As Integer = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "50", "100")

            ' Sets the background color.
            Dim fc As FormatCondition = fcs(conditionIndex)
            ' fc.Style.BackgroundColor = Color.Red;

            fc.Style.Font.IsItalic = True
            fc.Style.Font.IsBold = True
            fc.Style.Font.IsStrikeout = True
            fc.Style.Font.Underline = FontUnderlineType.Double
            fc.Style.Font.Color = Color.Black
            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1
        End Sub
    End Class
End Namespace
