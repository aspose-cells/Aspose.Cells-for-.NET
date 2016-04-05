Imports System
Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    'ExStart:ImplementCustomCalculationEngine
    ' Create a new class derived from AbstractCalculationEngine
    Friend Class CustomEngine
        Inherits AbstractCalculationEngine

        ' Override the Calculate method with custom logic
        Public Overrides Sub Calculate(ByVal data As CalculationData)
            'Check the forumla name and change the implementation
            If data.FunctionName.ToUpper() = "SUM" Then
                Dim val As Double = CDbl(data.CalculatedValue)
                val = val + 30

                ' Assign the CalculationData.CalculatedValue
                data.CalculatedValue = val
            End If
        End Sub
    End Class

    Friend Class ImplementCustomCalculationEngine
        Public Shared Sub Main(ByVal args() As String)
            ' Create an instance of Workbook
            Dim workbook As New Workbook()

            ' Access first Worksheet from the collection
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Access Cell A1 and put a formula to sum values of B1 to B2
            Dim a1 As Cell = sheet.Cells("A1")
            a1.Formula = "=Sum(B1:B2)"

            ' Assign values to cells B1 & B2
            sheet.Cells("B1").PutValue(10)
            sheet.Cells("B2").PutValue(10)

            ' Calculate all formulas in the Workbook 
            workbook.CalculateFormula()

            ' The result of A1 should be 20 as per default calculation engine
            Console.WriteLine("The value of A1 with default calculation engine: " & a1.StringValue)

            ' Create an instance of CustomEngine
            Dim engine As New CustomEngine()

            ' Create an instance of CalculationOptions
            Dim opts As New CalculationOptions()

            ' Assign the CalculationOptions.CustomEngine property to the instance of CustomEngine
            opts.CustomEngine = engine

            ' Recalculate all formulas in Workbook using the custom calculation engine
            workbook.CalculateFormula(opts)

            ' The result of A1 will be 50 as per custom calculation engine
            Console.WriteLine("The value of A1 with custom calculation engine: " & a1.StringValue)

            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()
        End Sub
    End Class
    'ExEnd:ImplementCustomCalculationEngine
End Namespace
