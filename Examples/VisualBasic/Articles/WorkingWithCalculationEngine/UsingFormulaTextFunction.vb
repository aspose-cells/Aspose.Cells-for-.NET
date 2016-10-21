Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles.WorkingWithCalculationEngine
    Public Class UsingFormulaTextFunction
        Public Shared Sub Run()
            ' ExStart:UsingFormulaTextFunction
            ' Create a workbook object
            Dim workbook As New Workbook()

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Put some formula in cell A1
            Dim cellA1 As Cell = worksheet.Cells("A1")
            cellA1.Formula = "=Sum(B1:B10)"

            ' Get the text of the formula in cell A2 using FORMULATEXT function
            Dim cellA2 As Cell = worksheet.Cells("A2")
            cellA2.Formula = "=FormulaText(A1)"

            ' Calculate the workbook
            workbook.CalculateFormula()

            ' Print the results of A2, It will now print the text of the formula inside cell A1
            Console.WriteLine(cellA2.StringValue)
            ' ExEnd:UsingFormulaTextFunction
        End Sub
    End Class
End Namespace