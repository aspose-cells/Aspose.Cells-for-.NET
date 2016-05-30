Imports System.IO

Imports Aspose.Cells

Namespace Formulas
    Public Class ProcessDataUsingBuiltinfunction
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If Not IsExists Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Adding a new worksheet to the Excel object
            Dim sheetIndex As Integer = workbook.Worksheets.Add()

            ' Obtaining the reference of the newly added worksheet by passing its sheet index
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Adding a value to "A1" cell
            worksheet.Cells("A1").PutValue(1)

            ' Adding a value to "A2" cell
            worksheet.Cells("A2").PutValue(2)

            ' Adding a value to "A3" cell
            worksheet.Cells("A3").PutValue(3)

            ' Adding a SUM formula to "A4" cell
            worksheet.Cells("A4").Formula = "=SUM(A1:A3)"

            ' Calculating the results of formulas
            workbook.CalculateFormula()

            ' Get the calculated value of the cell
            Dim value As String = worksheet.Cells("A4").Value.ToString()

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace
