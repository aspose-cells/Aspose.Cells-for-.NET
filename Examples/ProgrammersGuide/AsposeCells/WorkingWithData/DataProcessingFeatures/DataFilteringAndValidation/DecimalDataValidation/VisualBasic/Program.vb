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
Imports System

Namespace DecimalDataValidation
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

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

			' Create a validation object adding to the collection list.
			Dim validation As Validation = validations(validations.Add())

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

		End Sub
	End Class
End Namespace