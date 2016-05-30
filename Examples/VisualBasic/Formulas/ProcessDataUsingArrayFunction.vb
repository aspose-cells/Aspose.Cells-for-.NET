Imports System.IO

Imports Aspose.Cells

Namespace Formulas
    Public Class ProcessDataUsingArrayFunction
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
            Dim worksheet As Worksheet = workbook.Worksheets(sheetIndex)

            ' Adding a value to "A1" cell
            worksheet.Cells("A1").PutValue(1)

            ' Adding a value to "A2" cell
            worksheet.Cells("A2").PutValue(2)

            ' Adding a value to "A3" cell
            worksheet.Cells("A3").PutValue(3)

            ' Adding a value to B1
            worksheet.Cells("B1").PutValue(4)

            ' Adding a value to "B2" cell
            worksheet.Cells("B2").PutValue(5)

            ' Adding a value to "B3" cell
            worksheet.Cells("B3").PutValue(6)

            ' Adding a value to C1
            worksheet.Cells("C1").PutValue(7)

            ' Adding a value to "C2" cell
            worksheet.Cells("C2").PutValue(8)

            ' Adding a value to "C3" cell
            worksheet.Cells("C3").PutValue(9)

            ' Adding a SUM formula to "A4" cell
            worksheet.Cells("A6").SetArrayFormula("=LINEST(A1:A3,B1:C3,TRUE,TRUE)", 5, 3)

            ' Calculating the results of formulas
            workbook.CalculateFormula()

            ' Get the calculated value of the cell
            Dim value As String = worksheet.Cells("A6").Value.ToString()

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace
