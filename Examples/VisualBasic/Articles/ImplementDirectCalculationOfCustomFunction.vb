Imports Aspose.Cells
Namespace Articles
    ' ExStart:ImplementDirectCalculationOfCustomFunction
    Class ICustomEngine
        Inherits AbstractCalculationEngine
        ' Override the Calculate method with custom logic
        Public Overrides Sub Calculate(data As CalculationData)
            ' Check the forumla name and calculate it yourself
            If data.FunctionName = "MyCompany.CustomFunction" Then
                ' This is our calculated value
                data.CalculatedValue = "Aspose.Cells."
            End If
        End Sub
    End Class
    Class ImplementDirectCalculationOfCustomFunction
        Public Shared Sub Run()
            ' Create a workbook
            Dim wb As New Workbook()

            ' Accesss first worksheet
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Add some text in cell A1
            ws.Cells("A1").PutValue("Welcome to ")

            ' Create a calculation options with custom engine
            Dim opts As New CalculationOptions()
            opts.CustomEngine = New ICustomEngine()

            ' This line shows how you can call your own custom function without
            ' a need to write it in any worksheet cell
            ' After the execution of this line, it will return
            ' Welcome to Aspose.Cells.
            Dim ret As Object = ws.CalculateFormula("=A1 & MyCompany.CustomFunction()", opts)

            ' Print the calculated value on Console
            Console.WriteLine("Calculated Value: " + ret)
        End Sub
    End Class
    ' ExEnd:ImplementDirectCalculationOfCustomFunction
End Namespace
