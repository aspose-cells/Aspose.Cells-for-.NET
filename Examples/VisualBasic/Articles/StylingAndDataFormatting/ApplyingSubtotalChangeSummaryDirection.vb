Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Articles.StylingAndDataFormatting
    Public Class ApplyingSubtotalChangeSummaryDirection
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create workbook from source Excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("Book1.xlsx"))

            'Access the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Get the Cells collection in the first worksheet
            Dim cells As Cells = worksheet.Cells

            'Create a cellarea i.e.., A2:B11
            Dim ca As CellArea = CellArea.CreateCellArea("A2", "B11")

            'Apply subtotal, the consolidation function is Sum and it will applied to
            'Second column (B) in the list
            cells.Subtotal(ca, 0, ConsolidationFunction.Sum, New Integer() {1}, True, False, _
             True)

            'Set the direction of outline summary
            worksheet.Outline.SummaryRowBelow = True

            'Save the excel file
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace