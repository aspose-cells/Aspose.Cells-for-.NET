'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace DateDataValidation
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			' Create directory if it is not already present.
			Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
			If (Not IsExists) Then
				System.IO.Directory.CreateDirectory(dataDir)
			End If

			' Create a workbook.
			Dim workbook As New Workbook()

			' Obtain the cells of the first worksheet.
			Dim cells As Cells = workbook.Worksheets(0).Cells

			' Put a string value into the A1 cell.
			cells("A1").PutValue("Please enter Date b/w 1/1/1970 and 12/31/1999")

			' Set row height and column width for the cells.
			cells.SetRowHeight(0, 31)
			cells.SetColumnWidth(0, 35)

			' Get the validations collection.
			Dim validations As ValidationCollection = workbook.Worksheets(0).Validations

			' Add a new validation.
			Dim validation As Validation = validations(validations.Add())

			' Set the data validation type.
			validation.Type = ValidationType.Date

			' Set the operator for the data validation
			validation.Operator = OperatorType.Between

			' Set the value or expression associated with the data validation.
			validation.Formula1 = "1/1/1970"

			' The value or expression associated with the second part of the data validation.
			validation.Formula2 = "12/31/1999"

			' Enable the error.
			validation.ShowError = True

			' Set the validation alert style.
			validation.AlertStyle = ValidationAlertType.Stop

			' Set the title of the data-validation error dialog box
			validation.ErrorTitle = "Date Error"

			' Set the data validation error message.
			validation.ErrorMessage = "Enter a Valid Date"

			' Set and enable the data validation input message.
			validation.InputMessage = "Date Validation Type"
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

		End Sub
	End Class
End Namespace