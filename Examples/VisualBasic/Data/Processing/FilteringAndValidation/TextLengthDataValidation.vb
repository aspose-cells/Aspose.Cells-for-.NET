Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Data.Processing.FilteringAndValidation
    Public Class TextLengthDataValidation
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Create a new workbook.
            Dim workbook As New Workbook()

            ' Obtain the cells of the first worksheet.
            Dim cells As Global.Aspose.Cells.Cells = workbook.Worksheets(0).Cells

            ' Put a string value into A1 cell.
            cells("A1").PutValue("Please enter a string not more than 5 chars")


            ' Set row height and column width for the cell.
            cells.SetRowHeight(0, 31)
            cells.SetColumnWidth(0, 35)

            ' Get the validations collection.
            Dim validations As ValidationCollection = workbook.Worksheets(0).Validations

            ' Create Cell Area
            Dim ca As CellArea = New CellArea()
            ca.StartRow = 0
            ca.EndRow = 0
            ca.StartColumn = 0
            ca.EndColumn = 0

            ' Add a new validation.
            Dim validation As Validation = validations(validations.Add(ca))

            ' Set the data validation type.
            validation.Type = ValidationType.TextLength

            ' Set the operator for the data validation.
            validation.Operator = OperatorType.LessOrEqual

            ' Set the value or expression associated with the data validation.
            validation.Formula1 = "5"

            ' Enable the error.
            validation.ShowError = True

            ' Set the validation alert style.
            validation.AlertStyle = ValidationAlertType.Warning

            ' Set the title of the data-validation error dialog box.
            validation.ErrorTitle = "Text Length Error"

            ' Set the data validation error message.
            validation.ErrorMessage = " Enter a Valid String"

            ' Set and enable the data validation input message.
            validation.InputMessage = "TextLength Validation Type"
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
            ' ExEnd:1
        End Sub
    End Class
End Namespace