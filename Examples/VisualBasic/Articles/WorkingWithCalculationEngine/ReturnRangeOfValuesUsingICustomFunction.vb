Imports System.IO
Imports System.Diagnostics
Imports Aspose.Cells

Namespace Articles.WorkingWithCalculationEngine
    ' ExStart:CustomFunctionStaticValue
    Public Class CustomFunctionStaticValue
        Implements ICustomFunction
        Public Function CalculateCustomFunction(functionName As String, paramsList As ArrayList, contextObjects As ArrayList) As Object Implements ICustomFunction.CalculateCustomFunction
            Return New Object()() {New Object() {New DateTime(2015, 6, 12, 10, 6, 30), 2}, New Object() {3.0, "Test"}}
        End Function
    End Class
    ' ExEnd:CustomFunctionStaticValue

    Public Class ReturnRangeOfValuesUsingICustomFunction
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook
            Dim wb As New Workbook()
            Dim cells As Cells = wb.Worksheets(0).Cells

            ' Set formula
            Dim cell As Cell = cells(0, 0)
            cell.SetArrayFormula("=MYFUNC()", 2, 2)

            Dim style As Style = cell.GetStyle()
            style.Number = 14
            cell.SetStyle(style)

            ' Set calculation options for formula
            Dim copt As New CalculationOptions()
            copt.CustomFunction = New CustomFunctionStaticValue()
            wb.CalculateFormula(copt)

            ' Save to xlsx by setting the calc mode to manual
            wb.Settings.CalcMode = CalcModeType.Manual
            wb.Save(dataDir & Convert.ToString("output_out_.xlsx"))

            ' Save to pdf
            wb.Save(dataDir & Convert.ToString("output_out_.pdf"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace