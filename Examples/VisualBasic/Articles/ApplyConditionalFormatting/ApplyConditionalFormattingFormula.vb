Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Aspose.Cells.Examples.Articles.ApplyConditionalFormatting
    Public Class ApplyConditionalFormattingFormula
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)


            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiating a Workbook object
            Dim workbook As New Workbook()

            Dim sheet As Worksheet = workbook.Worksheets(0)

            'Adds an empty conditional formatting
            Dim index As Integer = sheet.ConditionalFormattings.Add()

            Dim fcs As FormatConditionCollection = sheet.ConditionalFormattings(index)

            'Sets the conditional format range.
            Dim ca As New CellArea()

            ca = New CellArea()
            ca.StartRow = 2
            ca.EndRow = 2
            ca.StartColumn = 1
            ca.EndColumn = 1
            fcs.AddArea(ca)

            'Adds condition.
            Dim conditionIndex As Integer = fcs.AddCondition(FormatConditionType.Expression)

            'Sets the background color.
            Dim fc As FormatCondition = fcs(conditionIndex)

            fc.Formula1 = "=IF(SUM(B1:B2)>100,TRUE,FALSE)"
            fc.Style.BackgroundColor = Color.Red
            sheet.Cells("B3").Formula = "=SUM(B1:B2)"
            sheet.Cells("C4").PutValue("If Sum of B1:B2 is greater than 100, B3 will have RED background")
            'Saving the Excel file
            workbook.Save(dataDir & "output.xls", SaveFormat.Auto)
            'ExEnd:1


        End Sub
    End Class
End Namespace