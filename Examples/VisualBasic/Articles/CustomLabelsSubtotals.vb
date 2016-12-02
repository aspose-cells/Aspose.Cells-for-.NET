Namespace Articles
    Public Class CustomLabelsSubtotals
        Public Shared Sub Run()
            ' ExStart:UsingGlobalizationSettings
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Loads an existing spreadsheet containing some data
            Dim book As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Assigns the GlobalizationSettings property of the WorkbookSettings class to the class created in first step
            book.Settings.GlobalizationSettings = New CustomSettings()

            ' Accesses the 1st worksheet from the collection which contains data resides in the cell range A2:B9
            Dim sheet As Worksheet = book.Worksheets(0)

            ' Adds Subtotal of type Average to the worksheet
            sheet.Cells.Subtotal(CellArea.CreateCellArea("A2", "B9"), 0, ConsolidationFunction.Average, New Integer() {1})

            ' Calculates Formulas
            book.CalculateFormula()

            ' Auto fits all columns
            sheet.AutoFitColumns()

            ' Saves the workbook on disc
            book.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:UsingGlobalizationSettings
        End Sub
    End Class

    ' ExStart:GlobalizationSettings
    ' Defines a custom class derived from GlobalizationSettings class
    Class CustomSettings
        Inherits GlobalizationSettings
        ' Overrides the GetTotalName method
        Public Overrides Function GetTotalName(functionType As ConsolidationFunction) As String
            ' Checks the function type used to add the subtotals
            Select Case functionType
                ' Returns custom value based on the function type used to add the subtotals
                Case ConsolidationFunction.Average
                    Return "AVG"
                Case Else
                    ' Handle other cases as per requirement
                    Return MyBase.GetTotalName(functionType)
            End Select
        End Function

        ' Overrides the GetGrandTotalName method
        Public Overrides Function GetGrandTotalName(functionType As ConsolidationFunction) As String
            ' Checks the function type used to add the subtotals
            Select Case functionType
                ' Returns custom value based on the function type used to add the subtotals
                Case ConsolidationFunction.Average
                    Return "GRD AVG"
                Case Else
                    ' Handle other cases as per requirement
                    Return MyBase.GetGrandTotalName(functionType)
            End Select
        End Function
    End Class
    ' ExEnd:GlobalizationSettings
End Namespace