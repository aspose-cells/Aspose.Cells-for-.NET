Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Data.Processing.FilteringAndValidation
    Public Class DecimalDataValidation
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Create a workbook object.
            Dim workbook As New Workbook()

            ' Create a worksheet and get the first worksheet.
            Dim ExcelWorkSheet As Worksheet = workbook.Worksheets(0)

            ' Obtain the existing Validations collection.
            Dim validations As ValidationCollection = ExcelWorkSheet.Validations

            ' Create Cell Area
            Dim ca As CellArea = New CellArea()
            ca.StartRow = 0
            ca.EndRow = 0
            ca.StartColumn = 0
            ca.EndColumn = 0

            ' Create a validation object adding to the collection list.
            Dim validation As Validation = validations(validations.Add(ca))

            ' Set the validation type.
            validation.Type = ValidationType.Decimal

            ' Specify the operator.
            validation.Operator = OperatorType.Between

            ' Set the lower and upper limits.
            validation.Formula1 = Decimal.MinValue.ToString()
            validation.Formula2 = Decimal.MaxValue.ToString()

            ' Set the error message.
            validation.ErrorMessage = "Please enter a valid integer or decimal number"

            ' Specify the validation area of cells.
            Dim area As CellArea
            area.StartRow = 0
            area.EndRow = 9
            area.StartColumn = 0
            area.EndColumn = 0

            ' Add the area.
            validation.AreaList.Add(area)

            ' Save the workbook.
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1
        End Sub
    End Class
End Namespace