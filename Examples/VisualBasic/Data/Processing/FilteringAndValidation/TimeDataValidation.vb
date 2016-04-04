Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Data.Processing.Processing.FilteringAndValidation
    Public Class TimeDataValidation
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Create a workbook.
            Dim workbook As New Workbook()

            ' Obtain the cells of the first worksheet.
            Dim cells As Global.Aspose.Cells.Cells = workbook.Worksheets(0).Cells

            ' Put a string value into A1 cell.
            cells("A1").PutValue("Please enter Time b/w 09:00 and 11:30 'o Clock")


            ' Set the row height and column width for the cells.
            cells.SetRowHeight(0, 31)
            cells.SetColumnWidth(0, 35)

            ' Get the validations collection.
            Dim validations As ValidationCollection = workbook.Worksheets(0).Validations

            ' Add a new validation.
            Dim validation As Validation = validations(validations.Add())

            ' Set the data validation type.
            validation.Type = ValidationType.Time

            ' Set the operator for the data validation.
            validation.Operator = OperatorType.Between

            ' Set the value or expression associated with the data validation.
            validation.Formula1 = "09:00"

            ' The value or expression associated with the second part of the data validation.
            validation.Formula2 = "11:30"

            ' Enable the error.
            validation.ShowError = True

            ' Set the validation alert style.
            validation.AlertStyle = ValidationAlertType.Information

            ' Set the title of the data-validation error dialog box.
            validation.ErrorTitle = "Time Error"

            ' Set the data validation error message.
            validation.ErrorMessage = "Enter a Valid Time"

            ' Set and enable the data validation input message.
            validation.InputMessage = "Time Validation Type"
            validation.IgnoreBlank = True
            validation.ShowInput = True

            ' Set a collection of CellArea which contains the data validation settings.
            Dim cellArea As CellArea
            cellArea.StartRow = 0
            cellArea.EndRow = 0
            cellArea.StartColumn = 1
            cellArea.EndColumn = 1

            ' Add the validation area.
            validation.AreaList.Add(cellArea)

            ' Save the Excel file.
            workbook.Save(dataDir & "output.xls")
            'ExEnd:1

        End Sub
    End Class
End Namespace