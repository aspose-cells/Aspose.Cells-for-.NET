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

Namespace WholeNumberDataValidation
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

			'Accessing the Validations collection of the worksheet
			Dim validations As ValidationCollection = workbook.Worksheets(0).Validations

			'Creating a Validation object
			Dim validation As Validation = validations(validations.Add())

			'Setting the validation type to whole number
			validation.Type = ValidationType.WholeNumber

			'Setting the operator for validation to Between
			validation.Operator = OperatorType.Between

			'Setting the minimum value for the validation
			validation.Formula1 = "10"

			'Setting the maximum value for the validation
			validation.Formula2 = "1000"

			'Applying the validation to a range of cells from A1 to B2 using the
			'CellArea structure
			Dim area As CellArea
			area.StartRow = 0
			area.EndRow = 1
			area.StartColumn = 0
			area.EndColumn = 1

			'Adding the cell area to Validation
			validation.AreaList.Add(area)


			' Save the workbook.
			workbook.Save(dataDir & "output.xls")


		End Sub
	End Class
End Namespace