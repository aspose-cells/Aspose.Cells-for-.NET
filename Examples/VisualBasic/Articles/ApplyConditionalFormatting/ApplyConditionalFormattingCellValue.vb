Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Articles.ApplyConditionalFormatting
    Public Class ApplyConditionalFormattingCellValue
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Adds an empty conditional formatting
            Dim index As Integer = sheet.ConditionalFormattings.Add()

            Dim fcs As FormatConditionCollection = sheet.ConditionalFormattings(index)

            ' Sets the conditional format range.
            Dim ca As New CellArea()

            ca.StartRow = 0
            ca.EndRow = 0
            ca.StartColumn = 0
            ca.EndColumn = 0

            fcs.AddArea(ca)

            ' Adds condition.
            Dim conditionIndex As Integer = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "50", "100")

            ' Sets the background color.
            Dim fc As FormatCondition = fcs(conditionIndex)

            fc.Style.BackgroundColor = Color.Red

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls", SaveFormat.Auto)
            ' ExEnd:1


        End Sub
    End Class
End Namespace