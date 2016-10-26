Imports System.IO
Imports Aspose.Cells
Imports System.Drawing

Namespace Articles.ManageConditionalFormatting
    Public Class ApplyShadingToAlternateRowsColumns
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create an instance of Workbook or load existing
            Dim book = New Workbook()

            ' Access the Worksheet on which desired rule has to be applied
            Dim sheet = book.Worksheets(0)

            ' Add FormatConditions to the instance of Worksheet
            Dim idx As Integer = sheet.ConditionalFormattings.Add()

            ' Access the newly added FormatConditions via its index
            Dim conditionCollection = sheet.ConditionalFormattings(idx)

            ' Define a CellsArea on which conditional formatting will be applicable
            ' The code creates a CellArea ranging from A1 to I20
            Dim area = CellArea.CreateCellArea("A1", "I20")

            'Add area to the instance of FormatConditions
            conditionCollection.AddArea(area)

            ' Add a condition to the instance of FormatConditions
            ' For this case, the condition type is expression, which is based on some formula
            idx = conditionCollection.AddCondition(FormatConditionType.Expression)

            ' Access the newly added FormatCondition via its index
            Dim formatCondirion As FormatCondition = conditionCollection(idx)

            ' Set the formula for the FormatCondition
            ' Formula uses the Excel's built-in functions as discussed earlier in this article
            formatCondirion.Formula1 = "=MOD(ROW(),2)=0"

            ' Set the background color and patter for the FormatCondition's Style
            formatCondirion.Style.BackgroundColor = Color.Blue
            formatCondirion.Style.Pattern = BackgroundType.Solid

            ' Save the result on disk
            book.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace