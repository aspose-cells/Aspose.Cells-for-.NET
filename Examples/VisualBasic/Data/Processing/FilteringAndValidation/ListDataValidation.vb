Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Data.Processing.Processing.FilteringAndValidation
    Public Class ListDataValidation
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Create a workbook object.
            Dim workbook As New Workbook()

            ' Get the first worksheet.
            Dim worksheet1 As Worksheet = workbook.Worksheets(0)

            ' Add a new worksheet and access it.
            Dim i As Integer = workbook.Worksheets.Add()
            Dim worksheet2 As Worksheet = workbook.Worksheets(i)

            ' Create a range in the second worksheet.
            Dim range As Range = worksheet2.Cells.CreateRange("E1", "E4")

            ' Name the range.
            range.Name = "MyRange"

            ' Fill different cells with data in the range.
            range(0, 0).PutValue("Blue")
            range(1, 0).PutValue("Red")
            range(2, 0).PutValue("Green")
            range(3, 0).PutValue("Yellow")

            ' Get the validations collection.
            Dim validations As ValidationCollection = worksheet1.Validations

            ' Create a new validation to the validations list.
            Dim validation As Validation = validations(validations.Add())

            ' Set the validation type.
            validation.Type = Global.Aspose.Cells.ValidationType.List

            ' Set the operator.
            validation.Operator = OperatorType.None

            ' Set the in cell drop down.
            validation.InCellDropDown = True

            ' Set the formula1.
            validation.Formula1 = "=MyRange"

            ' Enable it to show error.
            validation.ShowError = True

            ' Set the alert type severity level.
            validation.AlertStyle = ValidationAlertType.Stop

            ' Set the error title.
            validation.ErrorTitle = "Error"

            ' Set the error message.
            validation.ErrorMessage = "Please select a color from the list"

            ' Specify the validation area.
            Dim area As CellArea
            area.StartRow = 0
            area.EndRow = 4
            area.StartColumn = 0
            area.EndColumn = 0

            ' Add the validation area.
            validation.AreaList.Add(area)

            ' Save the Excel file.
            workbook.Save(dataDir & "output.out.xls")

        End Sub
    End Class
End Namespace