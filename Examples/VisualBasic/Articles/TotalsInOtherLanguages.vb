Namespace Articles
    Public Class TotalsInOtherLanguages
        Public Shared Sub Run()
            ' ExStart:UsingGlobalizationSettings
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load your source workbook
            Dim wb As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Set the glorbalization setting to change subtotal and grand total names
            Dim gsi As GlobalizationSettings = New GlobalizationSettingsImp()
            wb.Settings.GlobalizationSettings = gsi

            ' Access first worksheet
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Apply subtotal on A1:B10
            Dim ca As CellArea = CellArea.CreateCellArea("A1", "B10")
            ws.Cells.Subtotal(ca, 0, ConsolidationFunction.Sum, New Integer() {2, 3, 4})

            ' Set the width of the first column
            ws.Cells.SetColumnWidth(0, 40)

            ' Save the output excel file
            wb.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:UsingGlobalizationSettings
        End Sub

        ' ExStart:GlobalizationSettings
        Private Class GlobalizationSettingsImp
            Inherits GlobalizationSettings
            ' This function will return the sub total name
            Public Overrides Function GetTotalName(functionType As ConsolidationFunction) As [String]
                Return "Chinese Total - 可能的用法"
            End Function

            ' This function will return the grand total name
            Public Overrides Function GetGrandTotalName(functionType As ConsolidationFunction) As [String]
                Return "Chinese Grand Total - 可能的用法"
            End Function
        End Class
        ' ExEnd:GlobalizationSettings
    End Class
End Namespace